let app = new Vue({
    el: "#app",
    data: {
        pageTitle: 'Laboratorium toevoegen',
        labToAdd: {
            name: '',
            address: '',
            postalCode: '',
            city: '',
            country: '',
        },
        addedLab: {
            name: '',
            address: '',
            postalCode: '',
            city: '',
            country: ''
        },
        token: '',
        headers: '',
        error: false,
        success: false,
        userMessage: '',
        addUrl: 'https://localhost:44303/api/Laboratories',
    },
    created: async function () {
        this.token = localStorage.getItem('token');
        this.headers = {
            headers: {
                Authorization: `Bearer ${this.token}`
            },
        }
    },
    methods: {
        addLab: async function () {
            this.error = false;
            this.success = false;

            if (this.token === null) {
                window.location.href = '/Accounts/Login';
            }

            let formData = new FormData();
            formData.append('name', this.addedLab.name);
            formData.append('address', this.addedLab.address);
            formData.append('postalCode', this.addedLab.postalCode);
            formData.append('city', this.addedLab.city);
            formData.append('country', this.addedLab.country);

            let response = await axios.post(this.addUrl, formData, this.headers)
                .then(response => response)
                .catch(error => { errorMessage = error; this.error = true; })

            if (this.error === true) {
                this.userMessage = errorMessage;
            }
            else {
                this.success = true;
                this.addedLab.name = this.labToAdd.name;
                this.addedLab.address = this.labToAdd.address;
                this.addedLab.postalCode = this.labToAdd.postalCode;
                this.addedLab.city = this.labToAdd.city;
                this.addedLab.country = this.labToAdd.country;
                this.userMessage = 'Laboratorium toegevoegd!';
            }
        },
        goBack: async function () {
            window.location.href = 'https://localhost:5001/Laboratories';
        }
    }
});