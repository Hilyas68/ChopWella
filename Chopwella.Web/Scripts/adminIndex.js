$(document).ready(function () {

    $.ajaxSetup({
        beforeSend: function () {
            $('#loader').show();
        },
        complete: function () {
            $('#loader').hide();

        }
    });



    $("#AddLogin").click(function (e) {
        e.preventDefault();
        var formData = {};

        formData.UserName = $('#username').val();
        formData.Password = $('#password').val();
        formData.ConfirmPassword = $('#ConfirmPassword').val();
        formData.RoleName = $('#role option:selected').text();

        $.ajax({
            url: 'http://localhost:60532/api/user/create',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function () {
                alert('Created Successfully');
                $('#loginModal').modal('hide');
            },
            error: function (jqXHR) {
                alert(`${jqXHR.responseText}`);
            }
        });
    });

});