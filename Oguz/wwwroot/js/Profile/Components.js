vue.use(window.vuelidate.default);
const { required, minlength, maxlength } = window.validators;

vue.component('UserData', {
    template: 'UserDataTemplate',
    data: function () {
    }
})
vue.component('UserOrders', {
    template: 'UserOrdersTemplate',
    data: function () {
    }
})
vue.component('UserDiscounts', {
    template: 'UserDiscountsTemplate',
    data: function () {
    }
})