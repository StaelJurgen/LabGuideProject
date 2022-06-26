let sharedLayout = new Vue({
    el: '#sharedLayout',
    data: {
        isLoggedIn: sessionStorage.getItem('isLoggedIn'),
    },
})


