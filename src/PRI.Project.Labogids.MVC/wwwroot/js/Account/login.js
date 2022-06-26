let app = new Vue({
    el: '#app',
    data: {
        pageTitle: 'Login',
        error: false,
        isLoggedIn: false,
        isAdmin: false,
        userMessage: '',
        loading: false,
        apiUrl: 'https://localhost:44303/api/Accounts/auth/login',
        loginModel: {
            username: '',
            password: '',
        },
        claim: '',
    },
    methods: {
        logIn: async function () {
            this.loading = true;
            this.error = false;
            this.isLoggedIn = false;
            this.claims = [];

            let token = '';
            let errorMessage = '';
            let response = await axios.post(this.apiUrl, this.loginModel)
                .then(response => response.data)
                .catch(error => { this.error = true; errorMessage = error })
                .finally(() => { this.loading = false; })

            if (this.error === true) {
                if (errorMessage.response.data !== '') {
                    this.userMessage = errorMessage.response.data
                }
                else {
                    this.userMessage = errorMessage;
                }
            }
            else {
                this.isLoggedIn = true;
                this.userMessage = 'U bent succesvol ingelogd!';
                token = response.token;

                this.isAdmin = response.claims.includes('admin');

                localStorage.setItem('token', token);
                sessionStorage.setItem('isLoggedIn', this.isLoggedIn);
                sessionStorage.setItem('isAdmin', this.isAdmin);

                window.setTimeout(function () {
                    window.location.href = 'https://localhost:5001/Properties';
                }, 2000);
            }
        }
    }
})