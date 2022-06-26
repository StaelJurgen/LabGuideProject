let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Bepalingen',
        properties: '',
        propertiesLoaded: false,
        propertyLoaded: false,
        error: false,
        errorMessage: '',
        propertiesApiUrl: 'https://localhost:44303/api/Properties',
        property: '',
        needle: '',
        isAdmin: sessionStorage.getItem('isAdmin'),
    },
    created: async function () {
        this.properties = await this.getData(this.propertiesApiUrl)
    },
    methods: {
        getData: async function (apiUrl) {
            let response = '';
            response = await axios.get(apiUrl)
                .then(response => response)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error;
                })
                .finally(() => { this.propertiesLoaded = true; })
            if (this.error !== true) {
                return response.data
            }
        },
        addToLocalStorage: async function (propertyId) {
            localStorage.setItem('propertyId', `${propertyId}`)
        },
        getSelection: async function () {

            let apiUrl = `${this.propertiesApiUrl}/${this.needle}`;
            //call the getData function
            let response = await this.getData(apiUrl);
            this.properties = response;
        },
        addProperty: async function () {
            window.location.href = '/Properties/AddProperty'
        },
        checkExist: async function (e) {
            let element = document.getElementById('searchInput');
            let value = element.value;
            let apiUrl = `${this.propertiesApiUrl}/${value}`;
            let response = await this.getData(apiUrl);
            this.properties = response;
        }
    },
});