var dataTable;
$(document).ready(function () {

    dataTable = $('#staffTb').DataTable({
        //configuration settings for the table
        "ajax": {
            "url": "http://localhost:60532/api/chopwella/staff",
            "type": "GET",
            "dataType": "json",
            "dataSrc": "" //render as array not json
        },
        "columns":
            [

                { "data": "Name" },
                { "data": "StaffNum" },
                { "data": "Email" },
                { "data": "Category.Name" },
                {
                    "data": "Id",
                    "render": function (data) {
                        return '<button data-target="#EditModal" data-toggle="modal" onclick="Edit(' + data + ')" data-staff-id="data" class="btn-edit btn btn-success" type="button"><i class = fa fa - pencil" ></i>Edit</button>'
                            + '          ' + '<a data-staff-id="data" class="btn btn-danger dude" onclick="Delete(' + data + ')" type="button">Delete</a>';

                    }

                }
            ],

        "bDestroy": true,

        "language": {
            "emptyTable": "Table is empty"
        }
    });

    $("#AddStaff").click(function (e) {
        e.preventDefault();
        var formData = {};

        formData.Name = $('#inputStaffName').val();
        formData.StaffNum = $('#inputStaffNumber').val();
        formData.Email = $('#email').val();
        formData.CategoryId = $('#category option:selected').val();

        $.ajax({
            url: 'http://localhost:60532/api/chopwella/AddStaff',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function () {
                alert('Success');
                $('#AddModal').modal('hide');
                dataTable.ajax.reload();

            },
            error: function (jqXHR) {
                alert(`${jqXHR.responseText}`);
            }
        });
    });




});

function Delete(id) {
    if (confirm("Are you sure you want to delete this staff?")) {
        $.ajax({
            url: "http://localhost:60532/api/chopwella/deleteStaff/" + id,
            method: "DELETE",
            success: function () {

                alert('Deleted Successfully');

                dataTable.ajax.reload();
            },
            error: function (jqXHR) {
                alert(`${jqXHR.responseText}`);
            }
        });

    }

}
