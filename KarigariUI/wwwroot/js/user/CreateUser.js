// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.
$(document).ready(function () {
    $('body').on('focus', "#DateOfBirth", function () {
        $(this).datepicker({ dateFormat: 'dd-mm-yy' });
    });

    if (window.matchMedia("(max-width: 767px)").matches) {
        // The viewport is less than 768 pixels wide
        $('.mb-3').css(' margin-left', '');
    } else {
        // The viewport is at least 768 pixels wide
        $('.mb-3').css(' margin-left', '20%');
    }



    $('#exampleModalCenter').modal({
        backdrop: 'static'
    });

    $("#Labour").click(function () {
        window.location.href = '/User/Create';
    });
});


//for address popup
$(function () {
    $('#Address_Country').on("change", function () {
        if ($(this).val().length == 0) {
            $('#Address_State').prop("disabled", true);
            $('#Address_City').prop("disabled", true);
            $('#Address_Taluka').prop("disabled", true);
            $('#Address_State').html('').append('<option value="">Select a State</option>');
            $('#Address_City').html('').append('<option value="">Select a City</option>');
            $('#Address_Taluka').html('').append('<option value="">Select a Taluka</option>');
            return false;
        }
        $.post('/User/GetStateDetails', { countryId: parseInt($('#Address_Country').val()) }, function (response) {
            if (response.data.length > 0) {
                $('#Address_State').html('');
                var options = '';
                options += '<option value="">Select a State</option>';
                for (var i = 0; i < response.data.length; i++) {
                    options += '<option value="' + response.data[i].stateId + '">' + response.data[i].name + '</option>';
                }
                $('#Address_State').append(options);
                $('#Address_State').prop("disabled", false);
                $('#Address_City').prop("disabled", true);
                $('#Address_Taluka').prop("disabled", true);

            }
        }).fail(function (error) {
            alert(error);
        });

    });

    $('#Address_State').on("change", function () {
        if ($(this).val().length == 0) {

            $('#Address_City').prop("disabled", true);
            $('#Address_Taluka').prop("disabled", true);
            $('#Address_City').html('').append('<option value="">Select a City</option>');
            $('#Address_Taluka').html('').append('<option value="">Select a Taluka</option>');
            return false;
        }
        $.post('/User/GetDivisionDetails', { stateId: parseInt($('#Address_State').val()) }, function (response) {
            if (response.data.length > 0) {
                $('#Address_City').html('');
                var options = '';
                options += '<option value="">Select a City</option>';
                for (var i = 0; i < response.data.length; i++) {
                    options += '<option value="' + response.data[i].divisionId + '">' + response.data[i].name + '</option>';
                }
                $('#Address_City').append(options);
                $('#Address_City').prop("disabled", false);
                $('#Address_Taluka').prop("disabled", true);

            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });

    $('#Address_City').on("change", function () {
        if ($(this).val().length == 0) {
            $('#Address_Taluka').prop("disabled", true);
            $('#Address_Taluka').html('').append('<option value="">Select a Taluka</option>');
            return false;
        }
        $.post('/User/GetTalukaDetails', { divisionId: parseInt($('#Address_City').val()) }, function (response) {
            if (response.data.length > 0) {
                $('#Address_Taluka').html('');
                var options = '';
                options += '<option value="">Select a Taluka</option>';
                for (var i = 0; i < response.data.length; i++) {
                    options += '<option value="' + response.data[i].TalukaId + '">' + response.data[i].name + '</option>';
                }
                $('#Address_Taluka').append(options);
                $('#Address_Taluka').prop("disabled", false);

            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });
});
//for address popup
//click save address

$('#saveAddress').click(function () {

    var formCollection = $('form').serialize()

    if ($('#Address_Country :selected').val().length == 0) {
        alert('Please select country');
    }
    else if ($('#Address_State :selected').val().length == 0) {
        alert('Please select state');
    }
    else if ($('#Address_City :selected').val().length == 0) {
        alert('Please select city');
    }
    else if ($('#Address_Taluka :selected').val().length == 0) {
        alert('Please select Taluka');
    }
    else {

        $("#Address").val($('#Address_Village').val() + ", " + $('#Address_Taluka :selected').text() + ", " + $('#Address_City :selected').text() + ", " + $('#Address_State :selected').text());
        $("#exampleModal").modal("hide");
    }

});

$('#CreateUser').click(function () {

    if ($('#FirstName').val().length == 0) {
        alert('please enter First Name');
        return false;

    }
    else if ($('#LastName').val().length == 0) {
        alert('please enter Last Name');
        return false;

    }
    else if ($('#Contact').val().length == 0) {
        alert('please enter Phone Numbar');
        return false;

    }
    else if ($('#DateOfBirth').val().length == 0) {
        alert('please select Date Of Birth');
        return false;

    }
    else if ($('#Password').val().length == 0) {
        alert('please enter Password');
        return false;

    }
    else if ($('#Address').val().length == 0) {
        alert('please enter Address');
        return false;
    }

});
