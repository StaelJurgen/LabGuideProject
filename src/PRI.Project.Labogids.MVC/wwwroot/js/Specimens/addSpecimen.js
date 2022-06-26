let app = new Vue({
    el: "#app",
    data: {
        pageTitle: 'Monster toevoegen',
        addedSpec: {
            name: '',
        },
        specToAdd: {
            name: '',
        },
        token: '',
        headers: '',
        error: false,
        success: false,
        userMessage: '',
        addUrl: 'https://localhost:44303/api/Specimens',
/*        noImg: 'No image.png',*/
        image: '',
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
        addSpec: async function () {
            this.error = false;
            this.success = false;

            if (this.token === null) {
                window.location.href = '/Accounts/Login';
            }

            let image = this.$refs.image.files[0];

            //if (image == null) {
            //    this.error = true;
            //    this.errorMessage = "Er werd geen afbeelding geselecteerd";
            //    this.success = false;
            //}

            let formData = new FormData();
            formData.append('name', this.addedSpec.name);
            formData.append('image', image);

            let response = await axios.post(this.addUrl, formData, this.headers)
                .then(response => response)
                .catch(error => { errorMessage = error; this.error = true; })

            if (this.error === true) {
                this.userMessage = errorMessage;
            }
            else {
                this.success = true;
                this.addedSpec.name = this.specToAdd.name;
                image.name = "";
                this.userMessage = 'Monster toegevoegd!';
            }
        },
        goBack: async function () {
            window.location.href = 'https://localhost:5001/Specimens';
        }
    }
});