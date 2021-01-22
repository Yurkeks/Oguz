let clients = new Vue({
    el: '#clientsList',
    data: {
        clientsList: [],
    },
    created: function () {
        let vm = this;
        var table = new Tabulator("#clientsTabulator", {
            data: vm.clientsList,           //load row data from array
            responsiveLayout: "hide",  //hide columns that dont fit on the table
            tooltips: true,            //show tool tips on cells
            addRowPos: "top",          //when adding a new row, add it to the top of the table
            pagination: "local",       //paginate the data
            paginationSize: 20,         //allow 7 rows per page of data
            movableColumns: true,      //allow column order to be changed
            //initialSort: [             //set the initial sort order of the data
            //    { column: "name", dir: "asc" },
            //],
            columns: [                 //define the table columns
                { title: "Имя", field: "firstName", editor: "input", headerFilter: "input", sorter: "string" },
                { title: "Task Progress", field: "cityId", hozAlign: "left", formatter: "progress", editor: true, sorter: "string"  },
                { title: "Gender", field: "email", width: 95, editorParams: { values: ["male", "female"] } },
                { title: "Rating", field: "rating", formatter: "star", hozAlign: "center", width: 100, editor: true, sorter: "string"  },
                { title: "Color", field: "col", width: 130, editor: "input" },
                { title: "Date Of Birth", field: "dob", width: 130, sorter: "date", hozAlign: "center", sorter: "string"  },
                { title: "Driver", field: "car", width: 90, hozAlign: "center", formatter: "tickCross", sorter: "boolean", editor: true },
            ],
        });
        vm.loadClients();
    },
    methods: {

        loadClients() {
            let vm = this;
            $.ajax({
                url: '/Admin/GetAllClients',
                success: function (resultList) {
                    vm.clientsList = resultList;
                }
            });
        },
    }
})