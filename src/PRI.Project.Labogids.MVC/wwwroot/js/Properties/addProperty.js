let app = new Vue({
    el: "#app",
    data: {
        pageTitle: 'Voeg bepaling toe',
        token: '',
        headers: '',
        propertyModel: {
            name: '',
            synonyms: '',
            specimenId: '',
            storageConditions: '',      /*list int*/
            laboratoryId: '',
            requestCode: '',
            requestDefinitionId: '',
            turnAroundTime: '',
            timePeriod: '',
            referenceValues: '',        /*list int*/
        },
        laboratories: '',               /*gets all laboratories to fill select-box*/
        specimens: '',                  /*gets all specimens to fill select-box*/
        requestDefinitions: '',         /*gets all reqDefs to fill select-box*/
        referenceValueModel: {          /*creates new referenceValue*/
            minimumValue: '',
            maximumValue: '',
            unit: '',
            stringValue: '',
            sex: '',
            maximalAge: '',
            period: '',
        },
        storageConditionModel: {        /*creates new storageCondition*/
            temperature: '',
            timePeriod: '',
            timeReference: '',
        },
        timeReferences: [
            { id: 0, name: 'Min' },
            { id: 1, name: 'U' },
            { id: 2, name: 'D' },
            { id: 3, name: 'W' },
            { id: 4, name: 'M' },
            { id: 5, name: 'J' }
        ],
        sexes: [
            { id: 0, name: 'M' },
            { id: 1, name: 'F' },
        ],
        timeReferenceId: '',
        propertyId: '',
        referenceValuesToAdd: [],
        error: false,
        success: false,
        userMessage: '',
        errorMessage: '',
    },
    created: async function () {

        const referenceValuesToAdd = [];
        this.referenceValuesToAdd = referenceValuesToAdd;

        const token = localStorage.getItem('token');
        this.token = token;

        if (this.token === null) {
            window.location.href = '/Accounts/Login';
        }

        const headers = {
            headers: {
                Authorization: `Bearer ${token}`
            }
        }

        this.headers = headers;

        this.laboratories = await axios.get('https://localhost:44303/api/Laboratories', headers)
            .then(response => response.data)
            .catch(error => { this.error = true; this.userMessage = error })

        this.specimens = await axios.get('https://localhost:44303/api/Specimens', headers)
            .then(response => response.data)
            .catch(error => { this.error = true; this.userMessage = error })

        this.requestDefinitions = await axios.get('https://localhost:44303/api/RequestDefinitions', headers)
            .then(response => response.data)
            .catch(error => { this.error = true; this.userMessage = error })
    },
    methods:
    {
        addReferenceValueToList: async function () {

            this.referenceValuesToAdd.push(this.referenceValueModel);
            this.clearReferenceValues();
        },

        addProperty: async function () {
            this.error = false;
            this.success = false;
            this.userMessage = '';

            let errorMessage = '';
            let apiUrl = 'https://localhost:44303/api/Properties'

            let formData = new FormData()
            formData.append('name', this.propertyModel.name)
            formData.append('synonym', this.propertyModel.synonyms)
            formData.append('specimenId', this.propertyModel.specimenId)
            formData.append('laboratoryId', this.propertyModel.laboratoryId)
            formData.append('requestCode', this.propertyModel.requestCode)
            formData.append('requestDefinitionId', this.propertyModel.requestDefinitionId)
            formData.append('turnAroundTime', this.propertyModel.turnAroundTime)
            formData.append('timePeriod', this.propertyModel.timePeriod)

            let response = await axios.post(apiUrl, formData, this.headers)
                .then(response => response)
                .catch(error => { this.error = true; this.errorMessage = error; })

            let propertyId = response.data[0].id;
            this.propertyId = propertyId;

            if (this.error === true) {
                this.userMessage = this.errorMessage;
            }
            else {
                this.success = true;
                this.addReferences();
            }
        },
        addReferences: async function () {
            this.error = '';
            this.success = '';
            this.userMessage = '';
            this.errorMessage = '';

            let addRefValUrl = 'https://localhost:44303/api/ReferenceValues';

            for (const reference of this.referenceValuesToAdd) {

                let formData = new FormData();

                formData.append('minimumValue', reference.minimumValue);
                formData.append('maximumValue', reference.maximumValue);
                formData.append('stringValue', reference.stringValue);
                formData.append('unit', reference.unit);
                formData.append('sex', reference.sex);
                formData.append('maximalAge', reference.maximalAge);
                formData.append('propertyId', this.propertyId);
                formData.append('period', reference.period);

                let response = await axios.post(addRefValUrl, formData, this.headers)
                    .then(response => response.data)
                    .catch(error => { this.error = true; this.errorMessage = error.response.data; })
            }

            if (this.error === true) {
                this.userMessage = this.errorMessage;
            }
            else {
                this.success = true;
                this.userMessage = "Bepaling succesvol toegevoegd";
                this.propertyModel.name = '';
                this.propertyModel.synonyms = '';
                this.propertyModel.specimenId = '';
                this.propertyModel.storageConditions = '';
                this.propertyModel.laboratoryId = '';
                this.propertyModel.requestCode = '';
                this.propertyModel.requestDefinitionId = '';
                this.propertyModel.turnAroundTime = '';
                this.propertyModel.timePeriod = '';
                this.propertyModel.referenceValues = '';
            }
        },
        clearReferenceValues: async function () {

            var referenceValueModel = {
                minimumValue : '',
                maximumValue : '',
                unit : '',
                stringValue : '',
                sex : '',
                maximalAge : '',
                period : '',
            }

            this.referenceValueModel = referenceValueModel;
        }        
    }
})