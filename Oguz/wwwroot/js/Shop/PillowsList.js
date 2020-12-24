let app = new Vue({
    el: '#app',
    data: {
        message: 'Hello Vue!',
        items: [1, 2, 3, 4, 5],
        pillowsList: []
    },
    mounted: function () {
        let vm = this;
        vm.getPillowsList();
    },
    methods: {
        getPillowsList() {
            let vm = this;
            $.ajax({
                url: '/api/GetProduct',
                //data: data,
                success: function (pillowsList) {
                    vm.pillowsList = pillowsList;
                }
            });
        },

    }
})