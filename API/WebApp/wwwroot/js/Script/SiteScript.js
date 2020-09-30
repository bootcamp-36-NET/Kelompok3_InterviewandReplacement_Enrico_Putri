﻿﻿$(document).ready(function () {
    //debugger;
    table = $('#ManageSite').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/site/LoadSite",
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
            { "data": "name" },
            { "data": "supervisor_name" },
            { "data": "address" },
            { "data": "phoneNumber" },
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
            {
                "sortable": false,
                "render": function (data, type, row, meta) {
                    console.log(row);
                    console.log(data);
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-warning btn-circle" data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + row.id + ')" ><i class="fa fa-lg fa-edit"></i></button>'
                        + '&nbsp;'
                        + '<button class="btn btn-outline-danger btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.id + ')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            }
        ],
        "dom": "Bfrtip",
        "buttons": [
            {
                extend: 'excel',
                text: '<i class="fa fa-file-excel-o"></i> Excel',
                className: 'btn btn-success',
                title: 'Site Table',
                search: 'applied',
                order: 'applied',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
            },

            {
                extend: 'pdf',
                text: '<i class="fa fa-file-pdf-o"></i> PDF',
                className: 'btn btn-danger',
                title: 'Site Table',
                search: 'applied',
                order: 'applied',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
            },
            {
                extend: 'print',
                text: '<i class="fa fa-print"></i> Print',
                className: 'btn btn-primary',
                title: 'Site Table',
                search: 'applied',
                order: 'applied',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
            },
        ]
    });
});

function ClearScreen() {
    $('#Id').val('');
    $('#SiteName').val('');
    $('#SupervisorName').val('');
    $('#Address').val('');
    $('#PhoneNumber').val('');
    $('#update').hide();
    $('#add').show();
}

function GetById(id) {
    debugger;
    $.ajax({
        url: "/site/GetById/",
        data: { id: id }
    }).then((result) => {
       debugger;
        $('#Id').val(result.id);
        $('#SiteName').val(result.name);
        $('#SupervisorName').val(result.supervisor_name);
        $('#Address').val(result.address);
        $('#PhoneNumber').val(result.phoneNumber);
        $('#add').hide();
        $('#update').show();
        $('#myModal').modal('show');
    })
}

function Save() {
    debugger;
    var Site = new Object();
    Site.id = 0;
    Site.name = $('#SiteName').val();
    Site.supervisor_name = $('#SupervisorName').val();
    Site.address = $('#Address').val();
    Site.phoneNumber = $('#PhoneNumber').val();
    
    $.ajax({
        type: 'POST',
        url: "/site/InsertOrUpdate/",
        cache: false,
        dataType: "JSON",
        data: Site
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Data inserted Successfully',
                showConfirmButton: false,
                timer: 1500,
            });
            table.ajax.reload(null, false);
        } else {
            Swal.fire('Error', 'Failed to Input', 'error');
            ClearScreen();
        }
    })
}

function Update() {
      debugger;
    var Site = new Object();
    Site.id = $('#Id').val();
    Site.name = $('#SiteName').val();
    Site.supervisor_name = $('#SupervisorName').val();
    Site.address = $('#Address').val();
    Site.phoneNumber = $('#PhoneNumber').val();
    $.ajax({
        type: 'POST',
        url: "/site/InsertOrUpdate/",
        cache: false,
        dataType: "JSON",
        data: Site
    }).then((result) => {
         debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Data Updated Successfully',
                showConfirmButton: false,
                timer: 1500,
            });
            table.ajax.reload(null, false);
        } else {
            Swal.fire('Error', 'Failed to Input', 'error');
            ClearScreen();
        }
    })
}

function Delete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
    }).then((resultSwal) => {
        if (resultSwal.value) {
            //debugger;
            $.ajax({
                url: "/site/Delete/",
                data: { id: id }
            }).then((result) => {
                //debugger;
                if (result.statusCode == 200) {
                    //debugger;
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Delete Successfully',
                        showConfirmButton: false,
                        timer: 1500,
                    });
                    table.ajax.reload(null, false);
                } else {
                    Swal.fire('Error', 'Failed to Delete', 'error');
                    ClearScreen();
                }
            })
        };
    });
}