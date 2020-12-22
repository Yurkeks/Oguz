let app = new Vue({
    el: '#app',
    data: {
        message: 'Hello, Vue!',
        sizes: [],
        showSizes2: 0,
        showSizes3: 0,
        showSizes4: 0,
        showSizes5: 0,
        showPlus: 0,
        sizesRowCount: 1
    },
    methods: {
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