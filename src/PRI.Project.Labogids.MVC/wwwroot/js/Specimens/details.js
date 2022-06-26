let app = new Vue({
    el: "#app",
    data: {
        pageTitle: '',
        specimen: '',
        error: false,
        success: false,
        errorMessage: '',
        detailUrl: `https://localhost:44303/api/Specimens/${localStorage.getItem('specimenId')}`,
        specimenDeleted: false,
        userMessage:'',
        isAdmin: sessionStorage.getItem('isAdmin'),
    },
    created: async function () {
        this.specimen = await this.getDetails(this.detailUrl);
    },
    methods: {
        getDetails: async function (apiUrl) {
            let response = '';
            response = await axios.get(apiUrl)
                .then(response => response)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error;
                })

            if (this.error !== true) {
                this.pageTitle = response.data.name;
                return response.data;
            };
        },
        deleteSpecimen: async function () {
            this.specimenDeleted = false;
            let deleteUrl = `https://localhost:44303/api/Specimens?id=${localStorage.getItem('specimenId')}`

            let token = localStorage.getItem('token')
            if (token === null) {
                window.location.href = '/Accounts/Login';
            }
            const headers = {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            };

            await axios.delete(deleteUrl, headers)
                .then(response => response)
                .catch(error => console.log(error))
                .finally(() => this.specimenDeleted = true);

            if (this.error === true) {
                this.userMessage = errorMessage;
            }
            else {
                this.success = true;
                this.userMessage = 'Het monster werd verwijderd!';
            }

            window.setTimeout(function () {
                window.location.href = 'https://localhost:5001/Specimens';
            }, 2000);
        },
        getConfirmation: async function () {
            var retVal = confirm("Weet u zeker dat u dit monster wil verwijderen?");
            if (retVal === true) {
                this.deleteSpecimen()
            }
        },
        editSpecimen: async function () {
            window.location.href = `https://localhost:5001/Specimens/UpdateSpecimen/${localStorage.getItem('specimenId')}`;
        }
    }
})