let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Laboratorium bijwerken',
        labToUpdate: {
            name: '',
            address: '',
            postalCode: '',
            city: '',
            country: ''
        },
        updatedLab: {
            id: '',
            name: '',
            address: '',
            postalCode: '',
            city: '',
            country: '',
        },
        token: '',
        headers: '',
        success: '',
        error: '',
        errorMessage: '',
        userMessage: '',
        fetchUrl: `https://localhost:44303/api/Laboratories/${localStorage.getItem('laboratoryId')}`
    },
    created: async function () {
        this.token = localStorage.getItem('token');
        this.headers = {
            headers: {
                Authorization: `Bearer ${this.token}`
            },
        }
        this.labToUpdate = await axios.get(this.fetchUrl);
        this.updatedLab.name = this.labToUpdate.data.name;
        this.updatedLab.address = this.labToUpdate.data.address;
        this.updatedLab.postalCode = this.labToUpdate.data.postalCode;
        this.updatedLab.city = this.labToUpdate.data.city;
        this.updatedLab.country = this.labToUpdate.data.country;
    },

    methods:
    {
        updateLab: async function () {
            this.error = false;
            this.success = false;
            let url = 'https://localhost:44303/api/Laboratories'

            let formData = new FormData();
            formData.append('id', this.labToUpdate.data.id);
            formData.append('laboratory.name', this.updatedLab.name);
            formData.append('laboratory.address', this.updatedLab.address);
            formData.append('laboratory.postalCode', this.updatedLab.postalCode);
            formData.append('laboratory.city', this.updatedLab.city);
            formData.append('laboratory.country', this.updatedLab.country);

            let response = await axios.put(url, formData, this.headers)
                .then(response => response)
                .catch(eror => { this.errorMessage = this.error; this.error = true })

            if (this.error === true) {
                this.userMessage = this.errorMessage;
            }
            else {
                this.success = true;               
                this.userMessage = "Laboratorium bijgewerkt!";
            }

            window.setTimeout(function () {
                window.location.href = `https://localhost:5001/Laboratories/Details/${localStorage.getItem('laboratoryId')}`;
            }, 2000);
        },
        goBack: async function () {
            window.location.href = 'https://localhost:5001/Laboratories';
        },
        cancel: async function () {
            this.updatedLab.name = this.labToUpdate.data.name;
            this.updatedLab.address = this.labToUpdate.data.address;
            this.updatedLab.postalCode = this.labToUpdate.data.postalCode;
            this.updatedLab.city = this.labToUpdate.data.city;
            this.updatedLab.country = this.labToUpdate.data.country;
            window.location.href = 'https://localhost:5001/Laboratories';
        },
    }
})