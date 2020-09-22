$(document).ready(function () {
    debugger;
    table = $('#Jobseeker').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/employees/LoadJobSeeker",
            type: "GET",
            dataType: "json",
            dataSrc: "",
        },
        "columns": [
            {
                "data": "id",
                //render: function (data, type, row, meta) {
                //    //console.log(row);
                //    return meta.row + meta.settings._iDisplayStart + 1;
                //}
            },
            { "data": "name" },
            //{ "data": "joblistName" },
            //{ "data": "phone" },
            //{
            //    "data": "createData",
            //    'render': function (jsonDate) {
            //        //debugger;
            //        var date = new Date(jsonDate);
            //        if (date.getFullYear() != 0001) {
            //            return moment(date).format('DD MMMM YYYY') + '<br> Time : ' + moment(date).format('HH:mm');
            //        }
            //        return "Not updated yet";
            //    }
            //},
            {
                "sortable": false,
                "render": function (data, type, row, meta) {
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-info btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Detail" onclick="return GetById(' + meta.row + ')" ><i class="fa fa-lg fa-info"></i></button>'

                }
            }
        ],

    });
});