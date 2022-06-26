let app = new Vue({
    el: "#app",
    data: {
        pageTitle: 'Monsters',
        specimens: '',
        error: false,
        errorMessage: '',
        specimensApiUrl: 'https://localhost:44303/api/Specimens',
    },
    created: async function () {
        this.specimens = await this.getData(this.specimensApiUrl, this.headers)
    },
    methods: {
        getData: async function (apiUrl, headers) {
            let token = localStorage.getItem('token')
            if (token === null) {
                window.location.href = '/Accounts/Login';
            }
            headers = {
                headers: {
                    Authorization: `Bearer ${token}`,
                }
            };

            let response = '';
            response = await axios.get(apiUrl, headers)
                .then(response => response)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error;
                })

            if (this.error !== true) {
                return response.data;
            }
        },
        addSpecIdToLocalStorage: async function (specimenId) {
            localStorage.setItem('specimenId', `${specimenId}`);
        },
        addSpecimen: async function () {
            window.location.href = 'https://localhost:5001/Specimens/AddSpecimen';
        }
    }
})