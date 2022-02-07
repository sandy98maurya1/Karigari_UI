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
    $('#country').on("change", function () {

        if ($(this).val().length == 0) {
            $('#State').prop("disabled", true);
            $('#city').prop("disabled", true);
            $('#taluka').prop("disabled", true);
            $('#State').html('').append('<option value="">Select a State</option>');
            $('#city').html('').append('<option value="">Select a City</option>');
            $('#taluka').html('').append('<option value="">Select a Taluka</option>');
            return false;
        }
        $.post('/User/GetStateDetails', { countryId: parseInt($('#country').val()) }, function (response) {
            if (response.data.length > 0) {
                $('#State').html('');
                var options = '';
                options += '<option value="">Select a State</option>';
                for (var i = 0; i < response.data.length; i++) {
                    options += '<option value="' + response.data[i].stateId + '">' + response.data[i].name + '</option>';
                }
                $('#State').append(options);
                $('#State').prop("disabled", false);
                $('#city').prop("disabled", true);
                $('#taluka').prop("disabled", true);

            }
        }).fail(function (error) {
            alert(error);
        });

    });

    $('#State').on("change", function () {
        if ($(this).val().length == 0) {

            $('#city').prop("disabled", true);
            $('#taluka').prop("disabled", true);
            $('#city').html('').append('<option value="">Select a City</option>');
            $('#taluka').html('').append('<option value="">Select a Taluka</option>');
            return false;
        }
        $.post('/User/GetDivisionDetails', { stateId: parseInt($('#State').val()) }, function (response) {
            if (response.data.length > 0) {
                $('#city').html('');
                var options = '';
                options += '<option value="">Select a City</option>';
                for (var i = 0; i < response.data.length; i++) {
                    options += '<option value="' + response.data[i].divisionId + '">' + response.data[i].name + '</option>';
                }
                $('#city').append(options);
                $('#city').prop("disabled", false);
                $('#taluka').prop("disabled", true);

            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });

    $('#city').on("change", function () {
        if ($(this).val().length == 0) {
            $('#taluka').prop("disabled", true);
            $('#taluka').html('').append('<option value="">Select a Taluka</option>');
            return false;
        }
        $.post('/User/GetTalukaDetails', { divisionId: parseInt($('#city').val()) }, function (response) {
            if (response.data.length > 0) {
                $('#taluka').html('');
                var options = '';
                options += '<option value="">Select a Taluka</option>';
                for (var i = 0; i < response.data.length; i++) {
                    options += '<option value="' + response.data[i].TalukaId + '">' + response.data[i].name + '</option>';
                }
                $('#taluka').append(options);
                $('#taluka').prop("disabled", false);

            }
        }).fail(function (error) {
            alert(error.StatusText);
        });
    });
});
//for address popup
//click save address

$('#saveAddress').click(function () {


    if ($('#country :selected').val().length == 0) {
        alert('Please select country');
    }
    else if ($('#State :selected').val().length == 0) {
        alert('Please select state');
    }
    else if ($('#city :selected').val().length == 0) {
        alert('Please select city');
    }
    else if ($('#taluka :selected').val().length == 0) {
        alert('Please select Taluka');
    }
    else {

        $("#Address").val($('#landMark').val() + ", " + $('#taluka :selected').text() + ", " + $('#city :selected').text() + ", " + $('#State :selected').text());
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
