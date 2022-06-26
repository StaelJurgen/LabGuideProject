let app = new Vue({
    el: "#app",
    data: {
        pageTitle: 'Registratie',
        registerModel: {
            firstName: '',
            lastName: '',
            email: '',
            dateOfBirth: '',
            address: '',
            postalCode: '',
            city: '',
            password:''
        },
        apiUrl: 'https://localhost:44303/api/Accounts/auth/register',
        error: false,
        isRegistered: false,
        userMessage: '',
        errorMessage: '',
        /*formData: '',*/
    },
    created: async function () {

    },
    methods: {
        register: async function () {
            this.error = false;
            this.isRegistered = false;
            this.userMessage = '';
            this.errorMessage = '';

            //this.formData = new FormData();
            //this.formData.append('firstName', this.registerModel.firstName);
            //this.formData.append('lastName', this.registerModel.lastName);
            //this.formData.append('email', this.registerModel.email);
            //this.formData.append('dateOfBirth', this.registerModel.dateOfBirth);
            //this.formData.append('address', this.registerModel.address);
            //this.formData.append('postalCode', this.registerModel.postalCode);
            //this.formData.append('city', this.registerModel.city);
            //this.formData.append('repeatPassword', this.registerModel.repeatPassword);
            let parsedData = {
                "firstName": this.registerModel.firstName,
                "lastName": this.registerModel.lastName,
                "userName": this.registerModel.email,
                "email": this.registerModel.email,
                "dateOfBirth": this.registerModel.dateOfBirth,
                "address": this.registerModel.address,
                "postalCode": this.registerModel.postalCode,
                "city": this.registerModel.city,
                "passWord": this.registerModel.password,
                "repeatPassword":this.registerModel.repeatPassword,
            }

            let response = await axios.post(this.apiUrl, parsedData)
                .then(response => response)
                .catch(error => { this.errorMessage = error; this.error = true })

            if (this.error === true) {
                this.userMessage = this.errorMessage;
            }
            else {
                this.isRegistered = true;
                this.userMessage = "Registratie voltooid!";
                window.setTimeout(function () {
                    window.location.href = 'https://localhost:5001/Accounts/Login';
                }, 2000);
            }
        }
    }
})