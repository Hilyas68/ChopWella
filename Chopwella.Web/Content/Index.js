<script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap.min.js"></script>
    <script src="~/Scripts/jquery-3.3.1.js"></script>
        $(document).ready(function () {
        var datatable = $('#table').DataTable();


        var table = $('#table');

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
                        {"data": "Name" },
                        {"data": "StaffNum" },
                        {
            "": "", "render": function () {
                                return "<a class='btn btn-sm btn-default'> UnSigned <a />";
                            }
                        }, {
                "": "", "render": function () {
                                return "<a class='btn btn-sm btn-default'> UnSigned <a />";
                            }
                        }, {
                    "": "", "render": function () {
                                return "<a class='btn btn-sm btn-default'> UnSigned <a />";
                            }
                        }, {
                        "": "", "render": function () {
                                return "<a class='btn btn-sm btn-default'> UnSigned <a />";
                            }
                        },

                        {
                            "": "", "render": function () {
                                return "<a class='btn btn-sm btn-default'> UnSigned <a />";
                            }
                        }
                    ],
                    "keepConditions": "true",

                    "language": {
                                "emptytable": "No Record found"
                    }
                });

                $('#table').on('click', 'a', function (e) {
                    if (confirm("Please Confirm you are signing against your name, because you can't unsign")) {
                                $(this).removeClass("btn-default").addClass("btn-success").text("Signed");
                            }

                    var data = datatable.row($(this).parents('tr')).data();
                    console.log(data);
                });

            });
        });



    });
