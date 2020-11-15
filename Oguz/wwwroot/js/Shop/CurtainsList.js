let app = new Vue({
    el: '#app',
    data: {
        message: 'Hello Vue!',
        items: [1, 2, 3, 4, 5],
        curtainsList:[]
    },
    mounted: function () {
        let vm = this;
        vm.getCurtainsList();
    },
    methods: {
        getCurtainsList() {
            let vm = this;
            $.ajax({
                url: '/api/GetProducts',
                //data: data,
                success: function (curtainsList) {
                    vm.curtainsList = curtainsList;
                }
            });
        },

    }
})