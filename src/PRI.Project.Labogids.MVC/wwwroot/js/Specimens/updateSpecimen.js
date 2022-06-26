let app = new Vue({
    el: "#app",
    data: {
        pageTitle: 'Monster bijwerken',
        specToUpdate: {
            name: '',
            image:'',
        },
        updatedSpec: {
            name: '',
            image:'',
        },
        token: '',
        headers: '',
        success: '',
        error: '',
        image: '',
        errorMessage: '',
        userMessage: '',
        fetchUrl: `https://localhost:44303/api/Specimens/${localStorage.getItem('specimenId')}`
    },
    created: async function () {
        this.token = localStorage.getItem('token');
        this.headers = {
            headers: {
                Authorization: `Bearer ${this.token}`
            },
        }

        this.specToUpdate = await axios.get(this.fetchUrl, this.headers);
        this.updatedSpec.name = this.specToUpdate.data.name;
        
    },
    methods: {
        updateSpec: async function () {
            this.error = false;
            this.success = false;
            let url = 'https://localhost:44303/api/Specimens';

            this.image = this.$refs.image.files[0];

            let formData = new FormData();
            formData.append('id', this.specToUpdate.data.id)
            formData.append('specimen.name', this.updatedSpec.name);
            formData.append('specimen.image', this.image);
            

            let response = await axios.put(url, formData, this.headers)
                .then(response => response)
                .catch(eror => { this.errorMessage = this.error; this.error = true })

            if (this.error === true) {
                this.userMessage = this.errorMessage;
            }
            else {
                this.success = true;
                this.userMessage = "Monster bijgewerkt!";
            }

            window.setTimeout(function () {
                window.location.href = `https://localhost:5001/Specimens/Details/${localStorage.getItem('specimenId')}`;
            }, 3000);
        },
        cancel: async function () {
            this.updatedSpec.name = this.specToUpdate.data.name;
            this.updatedSpec.image = this.labToUpdate.data.image;
            window.location.href = 'https://localhost:5001/Specimens';
        }
    }
})