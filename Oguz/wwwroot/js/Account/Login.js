let app = new Vue({
    el: '#loginContainer',
    data: {
        login: true,
        register: false,
        isLoginActive: true,
        isRegisterActive: false
    },
    methods: {
        switchToLogin() {
            let vm = this;
            vm.login = true;
            vm.register = false;
            vm.isLoginActive = true;
            vm.isRegisterActive = false;
        },
        switchToRegistrtion() {
            let vm = this;
            vm.login = false;
            vm.register = true;
            vm.isLoginActive = false;
            vm.isRegisterActive = true;
        },
        sizesPlusEvent() {
            let vm = this;
            $.ajax({
                url: '/api/GetProduct',
                //data: data,
                success: function () {
                    if (sizesRowCount = 1) {
                        showSizes2 = 1;
                        return showSizes2;
                    }
                }
            });
        },
    }
})