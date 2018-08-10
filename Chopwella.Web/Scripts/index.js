var datatable;
$(document).ready(function () {
    datatable = $('#checkinTb').DataTable();


    var table = $('#checkinTb');

    $(".catId").change(function (event) {
        var catId = $(this).val();
        $(function () {
            datatable.destroy();
            datatable = table.DataTable({
                "ajax": {
                    "url": "http://localhost:60532/api/chopwella/staffbyCat/" + catId,
                    "type": "GET",
                    "dataType": "json",
                    "dataSrc": "",
                    "destroy": "true",
                    "stateSave": "true"
                },
                "columns": [
                    { "data": "Name" },
                    { "data": "StaffNum" },
                    {
                        "data": "Monday", "render": function (data) {
                            if (data == false) {
                                return "<a class='btn btn-sm btn-default' > UnSigned <a/>";
                            } else {
                                return "<input  class='btn btn-sm btn-success ' type = 'button' value = 'Signed'/>";

                            }
                        }
                    }, {
                        "data": "Tuesday", "render": function (data) {
                            if (data == false) {
                                return "<a class='btn btn-sm btn-default' > UnSigned <a/>";
                            } else {
                                return "<input  class='btn btn-sm btn-success ' type = 'button' value = 'Signed'/>";

                            }
                        }
                    }, {
                        "data": "Wednesday", "render": function (data) {
                            if (data == false) {
                                return "<a class='btn btn-sm btn-default' > UnSigned <a/>";
                            } else {
                                return "<input  class='btn btn-sm btn-success ' type = 'button' value = 'Signed'/>";

                            }
                        }
                    }, {
                        "data": "Thursday", "render": function (data) {
                            if (data == false) {
                                return "<a class='btn btn-sm btn-default' > UnSigned <a/>";
                            } else {
                                return "<input  class='btn btn-sm btn-success ' type = 'button' value = 'Signed'/>";

                            }
                        }
                    },

                    {
                        "data": "Friday", "render": function (data) {
                            if (data == false) {
                                return "<a class='btn btn-sm btn-default' > UnSigned <a/>";
                            } else {
                                return "<input  class='btn btn-sm btn-success ' type = 'button' value = 'Signed'/>";

                            }
                        }
                    }
                ],



                rowId: 'extn',
                select: true,
                dom: 'Bfrtip',
                "keepConditions": "true",

                "language": {
                    "checkinTb": "No Record found"
                }
            });

            //var clickedValue;

            //$('#checkinTb').on('click', 'a', function (e) {

            //    if (confirm("Please Confirm you are signing against your name, because you can't unsign")) {
            //        var data = datatable.row($(this).parents('tr')).data();

            //        clickedValue = $(this).parent().index();
            //        console.log(clickedValue);
            //        $.ajax({
            //            type: 'POST',
            //            url: 'http://localhost:60532/api/chopwella/AddtoCheckin',
            //            data: {

            //                'Id': data.Id,
            //                'CategoryId': data.CategoryId,
            //                'Email': data.Email,
            //                'Name': data.Name,
            //                'StaffNum': data.StaffNum,
            //                'Day': clickedValue
            //            },
            //            context: this,
            //            success: function () {
            //                $(this).removeClass("btn-default").addClass("btn-success").text("Signed");
            //            }
            //        });

            //        $('.btn-success').prop('disabled', true);

            //    }


            //});


        });
    });

});

function Reset() {
    if (confirm("Are you sure you want to reset staff records?")) {
        $.ajax({
            url: "http://localhost:60532/api/chopwella/reset",
            method: "PUT",
            success: function () {

                alert('Reset Successfully');

                datatable.ajax.reload();
            },
            error: function (jqXHR) {
                alert(`${jqXHR.responseText}`);
            }
        });

    }
};


