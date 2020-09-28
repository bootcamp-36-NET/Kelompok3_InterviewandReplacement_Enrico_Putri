var arrEmployee = [];
var arrSite = [];
var table = null;

$(document).ready(function () {
    //debugger;
    table = $('#ReplacementApproval').DataTable({
        "processing": true,
        "responsive": true,
        "pagination": true,
        "stateSave": true,
        "ajax": {
            url: "/Replacement/LoadReplacement",
            type: "GET",
            dataType: "json",
            dataSrc: "",
            cache: false
        },
        columns: [
            {
                data: "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                    //return meta.row + 1;
                }
            },
            {
                data: "empId"
            },
            { data: "site.name" },
            { data: "replacement_reason" },   
            {
                data: "createData",
                'render': function (jsonDate) {
                    //var date = new Date(jsonDate).toDateString();
                    //return date;
                    var date = new Date(jsonDate);
                    return moment(date).format('DD MMMM YYYY') + '<br> Time : ' + moment(date).format('HH: mm');
                    //return ("0" + date.getDate()).slice(-2) + '-' + ("0" + (date.getMonth() + 1)).slice(-2) + '-' + date.getFullYear();
                }
            },
            {
                
                "sortable": false,
                //data: "id",
                "render": function (data, type, row, meta) {
                    //console.log(row);
                    $('[data-toggle="tooltip"]').tooltip();
                    return '<button class="btn btn-outline-success btn-circle" data-placement="left" data-toggle="tooltip" data-animation="false" title="Approve" onclick="return Approve(' + meta.row + ')" ><i class="fa fa-lg fa-check"></i></button>'
                        + '&nbsp;'
                        + '<button class="btn btn-outline-danger btn-circle" data-placement="right" data-toggle="tooltip" data-animation="false" title="Reject" onclick="return Reject(' + meta.row + ')" ><i class="fa fa-lg fa-times"></i></button>'
                }
            }
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

function ClearScreen() {
    $('#Id').val('');
    $('#EmployeeOption').val('');
    $('#SiteOption').val('');
    $('#replacement_reason').val('');
    $('#update').hide();
    $('#add').show();
}

function cekGetId(empId) {
    debugger;
    //var id = table.row(empId).data().empId;
    $.ajax({
        url: "/account/GetById/",
        data: { id: empId },
        success: function (data) {
            $(".getIdEmp").val(data.name);
        }
    })
}
//cekGetId("emp001");

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
    debugger;
    $.ajax({
        url: "/Replacement/GetById/",
        data: { id: id }
    }).then((result) => {
        debugger;
        $('#Id').append(result.jobSId);
        $('#Name').append(result.name);
        $('#Gender').append(result.gender);
        $('#BirthDate').append(result.birth_Date);
        $('#Address').append(result.address);
        $('#Religion').append(result.religion);
        $('#MaritalStatus').append(result.marital_Status);
        $('#Nasionality').append(result.nationality);
        $('#LastEducation').append(result.last_Education);
        $('#GPA').append(result.gpa);
        //$('#Id').val(result.id);
        //$('#EmployeeOption').val(result.empId);
        //$('#replacement_reason').val(result.replacement_reason);
        //$('#SiteOption').val(result.siteId);
        $('#add').hide();
        //$('#update').show();
        $('#myModal').modal('show');
    })
}

function Approve(idx) {
    debugger;
    var ApproveVM = new Object();
    ApproveVM.id = table.row(idx).data().id
    ApproveVM.empId = table.row(idx).data().empId
    //{
    //    //id: table.row(idx).data().id,
    //    empId: table.row(idx).data().empId
    //};
    $.ajax({
        type: 'POST',
        url: "ApproveRejectReplacement/ApproveRequest/",
        cache: false,
        dataType: "JSON",
        data: ApproveVM
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Replacement Has Been Approved',
                showConfirmButton: false,
                timer: 1500,
            });
            table.ajax.reload(null, false);
        } else {
            Swal.fire('Error', 'Failed to Approve', 'error');
            ClearScreen();
        }
    })
}

function Reject(idx) {
    debugger;
    var RejectVM = new Object();
    RejectVM.id = table.row(idx).data().id
    RejectVM.empId = table.row(idx).data().empId
    //{
    //    //id: table.row(idx).data().id,
    //    empId: table.row(idx).data().empId
    //};
    $.ajax({
        type: 'POST',
        url: "ApproveRejectReplacement/RejectRequest/",
        cache: false,
        dataType: "JSON",
        data: RejectVM
    }).then((result) => {
        debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Replacement Has Been Rejected',
                showConfirmButton: false,
                timer: 1500,
            });
            table.ajax.reload(null, false);
        } else {
            Swal.fire('Error', 'Failed to Reject', 'error');
            ClearScreen();
        }
    })
}
//function Approve(id) {
//    Swal.fire({
//        title: 'Are you sure?',
//        text: "You won't be able to revert this!",
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Yes, Approve it!',
//    }).then((resultSwal) => {
//        if (resultSwal.value) {
//            debugger;
//            $.ajax({
//                url: "ApproveRejectReplacement/Reject/",
//                data: { id: id }
//            }).then((result) => {
//                debugger;
//                if (result.statusCode == 200) {
//                    debugger;
//                    Swal.fire({
//                        position: 'center',
//                        icon: 'success',
//                        title: 'Replacement Has Been Rejected',
//                        showConfirmButton: false,
//                        timer: 1500,
//                    });
//                    table.ajax.reload(null, false);
//                } else {
//                    Swal.fire('Error', 'Failed to Reject', 'error');
//                    ClearScreen();
//                }
//            })
//        };
//    });
//}
