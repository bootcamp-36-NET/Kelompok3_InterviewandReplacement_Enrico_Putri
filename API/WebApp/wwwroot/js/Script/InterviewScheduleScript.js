var arrJoblist = [];
var arrEmployee = [];
var arrSite = [];

$(document).ready(function () {
    debugger;
    $('#ManageJoblists').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/interviewschedule/LoadInterviewSchedule",
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
            { "data": "interview_date" },
            {
                "data": "empId"
                //,
                //render: function GetById(meta) {
                //    //debugger;
                //    var id = table.row(meta).data().id;
                //    $.ajax({
                //        url: "/account/GetById/",
                //        data: { id: id }
                //    }).then((result) => {
                //        //debugger;
                //        $('#Name').val(result.name);
                //    })
                //    return val;
                //}
            },
            { "data": "joblist.name" },
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
            {
                "sortable": false,
                "render": function (data, type, row) {
                    //console.log(row);
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-warning btn-circle" data-placement="left" data-toggle="tooltip" data-animation="false" title="Edit" onclick="return GetById(' + row.id + ')" ><i class="fa fa-lg fa-edit"></i></button>'
                        + '&nbsp;'
                        + '<button class="btn btn-outline-danger btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.id + ')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            }
        ]
    });
});

function ClearScreen() {
    $('#Id').val('');
    $('#Name').val('');
    $('#update').hide();
    $('#add').show();
}

//load joblist
function LoadJoblist(element) {
    //debugger;
    if (arrJoblist.length === 0) {
        $.ajax({
            type: "Get",
            url: "/joblists/LoadJoblist",
            success: function (data) {
                arrJoblist = data;
                renderJoblist(element);
            }
        });
    }
    else {
        renderJoblist(element);
    }
}

function renderJoblist(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Joblist').hide());
    $.each(arrJoblist, function (i, val) {
        $option.append($('<option/>').val(val.id).text(val.name))
    });
}

LoadJoblist($('#JoblistOption'))

//load employee
function LoadEmp(element) {
    //debugger;
    if (arrEmployee.length === 0) {
        $.ajax({
            type: "Get",
            url: "/account/LoadEmp",
            success: function (data) {
                arrEmployee = data;
                renderEmp(element);
            }
        });
    }
    else {
        renderEmp(element);
    }
}

function renderEmp(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Employee').hide());
    $.each(arrEmployee, function (i, val) {
        $option.append($('<option/>').val(val.id).text(val.name))
    });
}

LoadEmp($('#EmployeeOption'))

//Load Site
function LoadSite(element) {
    //debugger;
    if (arrSite.length === 0) {
        $.ajax({
            type: "Get",
            url: "/site/LoadSite",
            success: function (data) {
                arrSite = data;
                renderSite(element);
            }
        });
    }
    else {
        renderSite(element);
    }
}

function renderSite(element) {
    var $option = $(element);
    $option.empty();
    $option.append($('<option/>').val('0').text('Select Site').hide());
    $.each(arrSite, function (i, val) {
        $option.append($('<option/>').val(val.id).text(val.name))
    });
}

LoadSite($('#SiteOption'))

function GetById(id) {
    //debugger;
    $.ajax({
        url: "/interviewschedule/GetById/",
        data: { id: id }
    }).then((result) => {
        //debugger;
        $('#Id').val(result.id);
        $('#Name').val(result.name);
        $('#add').hide();
        $('#update').show();
        $('#myModal').modal('show');
    })
}

function Save() {
    debugger;
    var InterviewSchedule = new Object();
    InterviewSchedule.Id = 0;
    InterviewSchedule.interview_date = $('#interviewdate').val();
    InterviewSchedule.empId = $('#EmployeeOption').val();
    InterviewSchedule.joblistId = $('#JoblistOption').val();
    InterviewSchedule.siteId = $('#SiteOption').val();
    $.ajax({
        type: 'POST',
        url: "/InterviewSchedule/InsertOrUpdate/",
        cache: false,
        dataType: "JSON",
        data: InterviewSchedule
    }).then((result) => {
        //debugger;
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
    //debugger;
    var Dept = new Object();
    Dept.Id = $('#Id').val();
    Dept.Name = $('#Name').val();
    $.ajax({
        type: 'POST',
        url: "/interviewschedule/InsertOrUpdate/",
        cache: false,
        dataType: "JSON",
        data: Dept
    }).then((result) => {
        //debugger;
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
                url: "/interviewschedule/Delete/",
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