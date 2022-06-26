let app = new Vue({
    el: "#app",
    data: {
        pageTitle: 'Laboratoria',
        laboratories: '',
        error: false,
        errorMessage: '',
        laboratoriesApiUrl: 'https://localhost:44303/api/Laboratories',
    },
    created: async function () {

        this.laboratories = await this.getData(this.laboratoriesApiUrl, this.headers)
    },
    methods: {
        getData: async function (apiUrl, headers) {

            let token = localStorage.getItem('token')
            if (token === null) {
                window.location.href = '/Accounts/Login';
            }
            headers = {
                headers: {
                    Authorization: `Bearer ${token}`
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
        addLabIdToLocalStorage: async function (laboratoryId) {
            localStorage.setItem('laboratoryId', `${laboratoryId}`);
        },
        addLaboratory: async function () {
            window.location.href = '/Laboratories/AddLaboratory';
        }
    }
})