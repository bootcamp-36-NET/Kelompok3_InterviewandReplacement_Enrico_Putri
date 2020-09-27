table = null;

$(document).ready(function () {
    //debugger;
    table = $('#testajaduluds').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/interviewscheduleemp/getbyidemp",
            type: "GET",
            dataType: "json",
            dataSrc: "",
        },
        "columns": [
            {
                "data": "id",
                render: function (data, type, row, meta) {
                    return meta.row + 1;
                }
            },
            {
                "data": "interview_date",
                'render': function (jsonDate) {
                    //var date = new Date(jsonDate).toDateString();
                    //return date;
                    var date = new Date(jsonDate);
                    return moment(date).format('DD MMMM YYYY') + '<br> Time : ' + moment(date).format('HH: mm');
                    //return ("0" + date.getDate()).slice(-2) + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + date.getFullYear();
                }
            },
            { "data": "empId" },
            //{ "data": "joblist.name" },
            //{ "data": "site.name" }
            {
                "render": function (data, type, row) {
                    console.log(row.joblist.name);
                    return row.joblist.name;
                }
            },
            {
                "render": function (data, type, row) {
                    return row.site.name;
                }
            },
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
    });

    //$.ajax({
    //    url: "/interviewscheduleemp/getbyidemp/",
    //    type: "GET",
    //    dataType: "json",
    //}).then((res) => {
    //    console.log(res.interview_date);
    //    console.log(res.empId);
    //    console.log(res.joblist.name);
    //    console.log(res.site.name);
    //    var date = new Date(res.interview_date);
    //    var getDate = moment(date).format('DD MMM YYYY') + '<br />' + moment(date).format('LTS');
    //    $('#getData').html('<th>' + getDate + '</th><th>' + res.empId + '</th><th>' + res.joblist.name + '</th><th>' + res.site.name +'</th>');
    //});

});