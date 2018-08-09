var dataTable;
$(document).ready(function () {

    dataTable = $('#example1').DataTable({
        //configuration settings for the table
        "ajax": {
            "url": "http://localhost:60532/api/chopwella/category",
            "type": "GET",
            "dataType": "json",
            "dataSrc": "" //render as array not json
        },
        "columns":
            [

                { "data": "Name" },
                {
                    "data": "Id",
                    "render": function (data) {
                        return '<button class="btn-edit btn btn-success" type="button">Edit</button>'
                            + ' ' + '<a data-staff-id="data" class="btn btn-danger" onclick="Delete(' + data + ')" type="button">Delete</a>';

                    }

                }
            ],
        "bDestroy": true,

        "language": {
            "emptyTable": "Table is empty"
        }
    });

    $('#AddCategory').click(function (e) {
        e.preventDefault();
        var formData = {};
        formData.Name = $('#inputCategoryName').val();

        $.ajax({
            url: 'http://localhost:60532/api/chopwella/addCategory',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function () {
                alert('Added Successfully');
                $('#AddModalCategory').modal('hide');
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
            url: "http://localhost:60532/api/chopwella/deleteCategory/" + id,
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