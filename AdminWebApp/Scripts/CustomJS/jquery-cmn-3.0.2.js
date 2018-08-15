$(document).ready(function () {
    $(".Calender").datepicker({
        showAnim: "slideDown",
        changeMonth: true,
        changeYear: true,
        yearRange: "-100:+0",
       
    });
    $(document).ajaxStart(function () {
        $('.ajax-loader').css("visibility", "visible");
    });
    $(document).ajaxComplete(function () {
        $('.ajax-loader').css("visibility", "hidden");
    });
});

function GetDatatableFor(id) {
    $('#' + id + '').DataTable({
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": true
    });
}
function toastrMsg(msg, method) {
    toastr.options = {
        "positionClass": "toast-bottom-right",
        "preventDuplicates": true,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
    return toastr[method](msg);
}
function toastrContinueMsg(msg, method) {
    toastr.options = {
        "positionClass": "toast-bottom-right",
        "preventDuplicates": true,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "6000000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
    return toastr[method](msg);
}
var sessionInterval = 0;
var sessionTimeOut;
var popupTimeOut;
var globalTimeOut = 0;
function SessionExpireAlert(timeout) {
    globalTimeOut = timeout;
    timeout = timeout * 1000 * 60;
    var seconds = timeout / 1000;

    sessionInterval = setInterval(function () {
        seconds--;
        $('#second').text(seconds);
    }, 1000);

    popupTimeOut = setTimeout(function () {
        //Show Popup before 60 seconds of timeout.
        var command = "Your Session will expire in <span id='second'></span> second. <br /><button type='button' id='okBtn' class='btn btn-primary' onclick='ResetSession()'>Reset Session</button>";
        toastrContinueMsg(command, "info");
        $('#second').text(seconds);
    }, timeout - 60 * 1000);

    sessionTimeOut = setTimeout(function () {
        $.ajax({
            url: "/Account/SessionTimeout",
            type: 'GET',
            dataType: 'json', // added data type
            success: function (res) {
                if (res) {
                    window.location = "/Account/Login";
                }
            }
        });
    }, timeout);
}
function ResetSession() {
    //Redirect to refresh Session.
    window.location = window.location.href;
    //$.ajax({
    //    url: "/Account/ResetSessionTimeout",
    //    type: 'GET',
    //    dataType: 'json', // added data type
    //    success: function (res) {
    //        if (res) {
    //            toastrMsg("Success! Your Session reset Succesfully!", "success");
    //            clearInterval(sessionInterval);
    //            clearTimeout(sessionTimeOut);
    //            clearTimeout(popupTimeOut);
    //            SessionExpireAlert(globalTimeOut);
    //        }
    //    }
    //});
}

function reset() {
    $('#frm')[0].reset();
    $('#btnSubmit').value("Submit");
}

function validateDec(key) {
    //getting key code of pressed key
    var keycode = key.which ? key.which : key.keyCode;
    //comparing pressed keycodes
    if (!(keycode === 8 || keycode === 46) && (keycode < 48 || keycode > 57)) {
        return false;
    }
    else {
        var parts = key.srcElement.value.split('.');
        if (parts.length > 1 && keycode === 46)
            return false;
        return true;
    }
}
function validateAlp(key) {
    var keyAlp = key.which ? key.which : key.keyCode;
    if (keyAlp >= 48 && keyAlp <= 57) {
        return false;
    }
}
function validateInt(key) {
    //getting key code of pressed key
    var keycode = key.which ? key.which : key.keyCode;
    //comparing pressed keycodes
    if (keycode !== 8 && (keycode < 48 || keycode > 57)) {
        return false;
    }
    else {
        return true;
    }
}
function GetUserDetailText(UserId) {
    $.ajax({
        url: "/Account/GetUser",
        type: 'POST',
        data: { UserId: UserId },
        dataType: 'json', // added data type
        success: function (res) {
            if (res !== false) {
                $('#UserId').text(res.UserId);
                $('.FirstName').text(res.FirstName);
                $('#LastName').text(res.LastName);
                $('#FullName').text(res.FullName);
                $('#Email').text(res.Email);
                $('#PhoneNo').text(res.PhoneNo);
                $("#UserRoles").text(res.UserRoles);
                $("#DOB").text($.datepicker.formatDate('dd MM yy', new Date(res.DOB)));
            }
            else {
                toastrMsg("Unable to get the user!", "error");
            }
        }
    });
}
//Confirm Email
function ResendEmail(id) {
    UserId = id;
    $.ajax({
        url: "/Account/ConfirmYourEmail",
        type: 'POST',        
        data: { UserId: UserId },
        dataType: 'json', // added data type
        success: function (res) {
            if (res) {
                toastrMsg("Email Resend" + " Successfully!", "success");
                $('#ConfirmYourEmail').hide();
                $('#EmailResend').show();
            }
            else {
                toastrMsg("An error occured, Email does not sent!", "error");
                $('#ConfirmYourEmail').hide();
                $('#EmailResend').hide();
                $('#EmailError').show();
            }
        }
        
    });
}
// Go To Top Button
window.onscroll = function () { scrollFunction() };
function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("myBtn").style.display = "block";
    } else {
        document.getElementById("myBtn").style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}
// Go To Top Button End
