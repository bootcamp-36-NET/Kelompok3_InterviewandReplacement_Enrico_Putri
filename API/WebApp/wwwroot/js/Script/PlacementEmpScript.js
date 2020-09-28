table = null;

$(document).ready(function () {
    debugger;
    table = $('#PlacementEmp').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/placementemp/getbyidemp",
            type: "GET",
            dataType: "json",
            dataSrc: "",
        },
        "columns": [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                    //return meta.row + 1;
                }
            },
            {
                "data": "empId"
                //"className": "getIdEmp",
                //render: function (data, type, row, meta) {
                //    debugger;
                //    var getid = row.empId;
                //    console.log(getid);
                //    //cekGetId(getid);
                //}
            },
            {
                "data": "placementDate",
                'render': function (jsonDate) {
                    //var date = new Date(jsonDate).toDateString();
                    //return date;
                    var date = new Date(jsonDate);
                    return moment(date).format('DD MMMM YYYY') + '<br> Time : ' + moment(date).format('HH: mm');
                    //return ("0" + date.getDate()).slice(-2) + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + date.getFullYear();
                }
            },
            {
                "data": "placementEndDate",
                'render': function (jsonDate) {
                    //var date = new Date(jsonDate).toDateString();
                    //return date;
                    var date = new Date(jsonDate);
                    return moment(date).format('DD MMMM YYYY') + '<br> Time : ' + moment(date).format('HH: mm');
                    //return ("0" + date.getDate()).slice(-2) + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + date.getFullYear();
                }
            },
            { "data": "site.name" },
            //{
            //    "data": "createData",
            //    'render': function (jsonDate) {
            //        //var date = new Date(jsonDate).toDateString();
            //        //return date;
            //        var date = new Date(jsonDate);
            //        return moment(date).format('DD MMMM YYYY') + '<br> Time : ' + moment(date).format('HH: mm');
            //        //return ("0" + date.getDate()).slice(-2) + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + date.getFullYear();
            //    }
            //},
            //{
            //    "data": "updateDate",
            //    'render': function (jsonDate) {
            //        //debugger;
            //        //var date = new Date(jsonDate).toDateString();
            //        //return date;
            //        var date = new Date(jsonDate);
            //        if (date.getFullYear() != 0001) {
            //            return moment(date).format('DD MMMM YYYY') + '<br> Time : ' + moment(date).format('HH: mm');
            //            //return ("0" + date.getDate()).slice(-2) + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + date.getFullYear();
            //        }
            //        return "Not updated yet";
            //    }
            //},
            //{
            //    "sortable": false,
            //    "render": function (data, type, row) {
            //        //console.log(row);
            //        $('[data-toggle="tooltip"]').tooltip();
            //        return '<button class="btn btn-outline-warning btn-circle" data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + row.id + ')" ><i class="fa fa-lg fa-edit"></i></button>'
            //            + '&nbsp;'
            //            + '<button class="btn btn-outline-danger btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.id + ')" ><i class="fa fa-lg fa-times"></i></button>'
            //    }
            //}
        ],
        //initComplete: function () {
        //    this.api().rows().every(function (rowIdx, tableLoop, rowLoop) {
        //        debugger;
        //        var rid = rowIdx;
        //        var tl = tableLoop;
        //        var rl = rowLoop;
        //cekGetId(rowLoop);
        //var column = this;
        //var select = $('<select><option value="">Department All</option></select>')
        //    .appendTo($(column.header()).empty())
        //    .on('change', function () {
        //        var val = $.fn.dataTable.util.escapeRegex(
        //            $(this).val()
        //        );

        //        column
        //            .search(val ? '^' + val + '$' : '', true, false)
        //            .draw();
        //    });

        //this.data().each(function (d, j) {
        //    debugger;
        //    $('.getIdEmp').append('<td>' + d + '</td>')
        //});
        //    });
        //}
    });
});