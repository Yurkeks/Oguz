
Vue.component("tab-data", {
    data: {

    },
    template: `
    <div class="mt-4 ">
        <h3> Мои данные </h3>
        <div class="row mt-4">
            <label class="control-label col-3 mt-3">Email: </label>
            <input class="form-control col-4" />
        </div>

        <div class="row">
            <label class="control-label col-3 mt-3">ФИО: </label>
            <input class="form-control col-4" />
        </div>

        <div class="row">
            <label class="control-label col-3 mt-3">Телефон: </label>
            <input class="form-control col-4" />
        </div>

        <div class="row">
            <label class="control-label col-3 mt-3">Город: </label>
            <input class="form-control col-4" />
        </div>

        <div class="row">
            <label class="control-label col-3 mt-3">Отделение Новой Почты: </label>
            <input class="form-control col-4" />
        </div>
    </div>
  `
});
Vue.component("tab-orders", {
    data: {
        clientOrders: [{ name: "nazvanie" }, {name: "wooow"}]
    },
    mounted() {
        let vm = this;
        let table = new Tabulator("#clientOrders-table", {
            data: vm.clientOrders,           //load row data from array
            layout: "fitColumns",      //fit columns to width of table
            responsiveLayout: "hide",  //hide columns that dont fit on the table
            tooltips: true,            //show tool tips on cells
            addRowPos: "top",          //when adding a new row, add it to the top of the table
            history: true,             //allow undo and redo actions on the table
            pagination: "local",       //paginate the data
            paginationSize: 7,         //allow 7 rows per page of data
            movableColumns: true,      //allow column order to be changed
            resizableRows: true,       //allow row order to be changed
            initialSort: [             //set the initial sort order of the data
                { column: "name", dir: "asc" },
            ],
            columns: [                 //define the table columns
                { title: "Name", field: "name", editor: "input" },
                //{ title: "Task Progress", field: "progress", hozAlign: "left", formatter: "progress", editor: true },
                //{ title: "Gender", field: "gender", width: 95, editor: "select", editorParams: { values: ["male", "female"] } },
                //{ title: "Rating", field: "rating", formatter: "star", hozAlign: "center", width: 100, editor: true },
                //{ title: "Color", field: "col", width: 130, editor: "input" },
                //{ title: "Date Of Birth", field: "dob", width: 130, sorter: "date", hozAlign: "center" },
                //{ title: "Driver", field: "car", width: 90, hozAlign: "center", formatter: "tickCross", sorter: "boolean", editor: true },
            ],
        });
    },
    template: `<div>
                    <h3> Мои заказы</h3>
                    <div id="clientOrders-table" class="mt-4"></div>
               </div>`
});
Vue.component("tab-discounts", {
    template: "<div>Archive component</div>"
});


let vue = new Vue({
    el: '#profileId',
    data: {
        currentTab: { tab: "data", name: "Профиль" },
        tabs: [{ tab: "data", name: "Профиль" }, { tab: "orders", name: "Заказы" },{ tab: "discounts", name: "Скидки" }],
    },
    computed: {
        currentTabComponent: function () {
            return "tab-" + this.currentTab.tab.toLowerCase();
        },
    },
    methods: {

    }
})

