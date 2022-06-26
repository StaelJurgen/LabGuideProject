let app = new Vue({
    el: '#app',
    data: {
        pageTitle: '',
        laboratory: '',
        laboratoryLoaded: false,
        error: false,
        success: false,
        errorMessage: '',
        detailUrl: `https://localhost:44303/api/Laboratories/${localStorage.getItem('laboratoryId')}`,
        laboratoryDeleted: false,
        isAdmin: '',
        isLoggedIn: '',
    },
    created: async function () {
        this.laboratory = await this.getDetails(this.detailUrl);
        this.isAdmin = sessionStorage.getItem('isAdmin');
        this.isLoggedIn = sessionStorage.getItem('isLoggedIn')
    },
    methods:
    {
        getDetails: async function (apiUrl) {
            let response = '';
            response = await axios.get(apiUrl)
                .then(response => response)
                .catch(error => {
                    this.error = true;
                    this.errorMessage = error;
                })
                .finally(() => {
                    this.laboratoryLoaded = true;
                })
            if (this.error !== true) {
                this.pageTitle = response.data.name;
                return response.data
            };
        },
        deleteLaboratory: async function () {
            this.laboratyDeleted = false;
            let deleteUrl = `https://localhost:44303/api/Laboratories?id=${localStorage.getItem('laboratoryId')}`

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
                .finally(() => this.laboratoryDeleted = true);

            if (this.error === true) {
                this.userMessage = errorMessage;
            }
            else {
                this.success = true;
                this.userMessage = 'Het laboratorium werd verwijderd!';
            }

            window.setTimeout(function () {
                window.location.href = 'https://localhost:5001/Laboratories';
            }, 2000);
        },
        getConfirmation: async function () {
            var retVal = confirm("Weet u zeker dat u dit laboratorium wil verwijderen?");
            if (retVal === true) {
                this.deleteLaboratory()
            }
        },
        editLaboratory: async function () {
            window.location.href = `https://localhost:5001/Laboratories/UpdateLaboratory/${localStorage.getItem('laboratoryId')}`;
        }
    },
});