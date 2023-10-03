$(document).ready(function () {
    bindDatatable();
    (function () {
        var forms = document.querySelectorAll('.needs-validation')
        Array.prototype.slice.call(forms)
            .forEach(function (form) {
                form.addEventListener('submit', function (event) {
                    if (!form.checkValidity()) {
                        event.preventDefault()
                        event.stopPropagation()
                    } if (form.checkValidity()) {
                        Create_Vendor();
                    }
                    form.classList.add('was-validated')
                }, false)
            })
    })()

});

//data table
function bindDatatable()
{
    datatable = $('#Vendor_Table')
        .DataTable
        ({
                    "sAjaxSource": "/Vendor/GetData",
                    "bServerSide": true,
                    "bProcessing": true,
                    "bSearchable": true,
                    "filter": true,
                    "language": {
                        "emptyTable": "No record found.",
                        "processing":
                            '<i class="fa fa-spinner fa-spin fa-3x fa-fw" style="color:#2a2b2b;"></i><span class="sr-only">Loading...</span> '
                    },
                    "columns": [
                        {
                            
                            "data": "vid",
                            render: function (data, type, row, meta) {
                                return row.vId
                            }
                        },
                        {
                            "data": "vname",
                            render: function (data, type, row, meta) {
                                return '<a href="#" data-bs-toggle="tooltip" style="text-decoration:none; color: black" onclick="Emp_Edit(' + row.vid + ')">' + row.vName + '</a>';
                            }
                        },
                        {
                            
                            "data": "vcode",
                            render: function (data, type, row, meta) {
                                return row.vCode
                            }
                        },
                        {
                           
                            "data": "cname",
                            render: function (data, type, row, meta) {
                                return row.cName
                            }
                        },
                        {
                           
                            "data": "vcontact_No",
                            render: function (data, type, row, meta) {
                                return row.vContact_No
                            }
                        },

                        //{
                        //    "searchable": true,
                        //    render: function (data, type, row, meta) {
                        //        return '<button type="button" class="button3" onclick = "DeleteCall(' + row.emp_No + ')" >Delete </button>';
                        //    }
                        //},
                        //{
                        //    "searchable": true,
                        //    render: function (data, type, row, meta) {
                        //        return '<button type="button" class="button2" onclick = "Add_Salary(' + row.emp_No + ')" > Add Salary</button> | <button type="button" class="button2" onclick = "sal_details(' + row.emp_No + ')" > Salary Details</button>';
                        //    }
                        //},
                    ]
        }); 
}

//list table
$("#addToList").click(function() { 
        if ($.trim($("#iname").val()) == "" || $.trim($("#icode").val()) == "" || $.trim($("#uprice").val()) == "")return;
        var iname = $("#iname").val(),
            icode = $("#icode").val(),
            uprice = $("#uprice").val(),
            ItemTable = $("#ItemTable tbody");
        var productItem ='<tr><td>' + iname + '</td><td>' + icode + '</td><td>' + uprice + '</td><td><a data-itemId="0" href="#" class="deleteItem">Remove</a></td></tr>';
        ItemTable.append(productItem);
        clearItem();
    });

//remove item
function clearItem() {
        $("#iname").val('');
        $("#icode").val('');
        $("#uprice").val('');
    }
$(document).on('click', 'a.deleteItem', function (e) {
        e.preventDefault();
        var $self = $(this);
        if ($(this).attr('data-itemId') == "0") {
            $(this).parents('tr').css("background-color", "#ff6347").fadeOut(800, function () {
                $(this).remove();
            });
        }
    });

//sand and save data into controller
function Create_Item() {
    var orderArr = [];
    orderArr.length = 0;

    $.each($("#ItemTable tbody tr"), function () {
        orderArr.push({
            IName: $(this).find('td:eq(0)').html(),
            ICode: $(this).find('td:eq(1)').html(),
            IPrice: $(this).find('td:eq(2)').html(),
        }); 
    });
    cons
    }


function saveOrder(data) {
    return $.ajax({
        dataType: 'json',
        type: 'POST',
        data: data,
        url: "/Vendor/SaveOrder",
        
        success: function (result) {
            alert(result);
            window.location.replace("/vendor/Index");
        },
        error: function () {
            alert("Error!")
        }
    });
}

function Create_Vendor() {
  

    var orderArr = [];
    orderArr.length = 0;

    $.each($("#ItemTable tbody tr"), function () {
        orderArr.push({
            IName: $(this).find('td:eq(0)').html(),
            ICode: $(this).find('td:eq(1)').html(),
            IPrice: $(this).find('td:eq(2)').html(),
        });
    });

    var data = {
        VName: $("#vname").val(),
        VCode: $("#vcode").val(),
        CName: $("#cname").val(),
        VContact_No: $("#vcontact_No").val(),
        itemss: orderArr
    };
    $.when(saveOrder(data)).then(function (response) {
        console.log(response);
    }).fail(function (err) {
        console.log(err);
    });
}








