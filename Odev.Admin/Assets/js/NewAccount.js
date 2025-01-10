var baseURL = "https://llcp57u13c.execute-api.eu-central-1.amazonaws.com/Prod/";
localStorage.removeItem('AccountID');

document.cookie = 'CLSID' + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
$(document).ready(function () {
    var mem = $('#data_1 .input-group.date').datepicker({
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        autoclose: true,
        format: "mm/dd/yyyy"
    });
    var account = localStorage.getItem('NewAccountID');
    if (account != null) {
        document.getElementById("AccountID").value = account;
        document.getElementById("TempData").style.display = "block";
        document.getElementById("btnCLSid").disabled = false;
    }
    else {
        document.getElementById("TempData").style.display = "none";
        document.getElementById("btnCLSid").disabled = true;
    }
});
function showPage() {
    document.getElementById("loader").style.display = "none";
    document.getElementById("TempData").style.display = "none";
    document.getElementById("myDiv").style.display = "block";
}
document.getElementById('btnCLSid').onclick = function () {
    GetCLS();
}
function GetCLS() {
    var account = localStorage.getItem('NewAccountID');
    var url = baseURL + "api/device/GetAutoProvisionedServer/" + account;
    var apikey = document.cookie.replace(/(?:(?:^|.*;\s*)Token\s*\=\s*([^;]*).*$)|^.*$/, "$1");
    var xhr = new XMLHttpRequest();
    xhr.open('GET', url, true);
    //xhr.withCredentials=true;
    xhr.onload = function (event) {
        if (xhr.status == 200) {
            var p = JSON.parse(event.target.response);
            var pp = JSON.stringify(p);
            document.getElementById("CLSCode").style.display = "";
            document.getElementById("CLSCode2").style.display = "";
            document.getElementById("CLSCode").innerHTML = "<strong>" + "Device ID : " + p + "</strong>";
            document.getElementById("CLSCode2").innerHTML = "<strong>" + "Device ID : " + p + "</strong>";
        }
    }
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.setRequestHeader("Authorization", "Bearer " + apikey);
    xhr.send();
}
function formKontrol() {
    document.getElementById("loader").style.display = "";
    var veri = document.getElementById("AccountID").value;
    localStorage.setItem('NewAccountID', document.getElementById("AccountID").value.trim());
    var url = baseURL + "api/account/checkaccountbyid";
    var apikey = document.cookie.replace(/(?:(?:^|.*;\s*)Token\s*\=\s*([^;]*).*$)|^.*$/, "$1");
    var xhr = new XMLHttpRequest();
    xhr.open('POST', url, true);
    xhr.onload = function (event) {
        if (xhr.status == 200) {
            var p = JSON.parse(event.target.response);
            if (p == 0) {
                document.getElementById("Bilgi").style.display = "";
                document.getElementById("Hata").style.display = "none";
                document.getElementById("CLSCode").style.display = "none";
                document.getElementById("CLSCode2").style.display = "none";
                document.getElementById("bilgimesaj").innerHTML = "<i style='color:green; font-size:30px;' class='fa fa-check-circle'></i>";
                document.getElementById("AccountName").disabled = false;
                document.getElementById("Product1").disabled = false;
                document.getElementById("Product2").disabled = false;
                document.getElementById("Duration").disabled = false;
                document.getElementById("Version").disabled = false;
                document.getElementById("seats").disabled = false;
                document.getElementById("sendButton").disabled = false;
                document.getElementById("btnCLSid").disabled = true;
                showPage();
            }
            else {
                document.getElementById("Bilgi").style.display = "none";
                document.getElementById("CLSCode").style.display = "none";
                document.getElementById("CLSCode2").style.display = "none";
                document.getElementById("Hata").style.display = "";
                document.getElementById("bilgimesaj").innerHTML = "<i style='color:red; font-size:30px;' class='fa fa-exclamation-triangle'></i>";
                document.getElementById("AccountName").disabled = true;
                document.getElementById("Product1").disabled = true;
                document.getElementById("Product2").disabled = true;
                document.getElementById("Duration").disabled = true;
                document.getElementById("Version").disabled = true;
                document.getElementById("seats").disabled = true;
                document.getElementById("sendButton").disabled = true;
                document.getElementById("btnCLSid").disabled = false;
                showPage();
            }
        }
    };
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.setRequestHeader("Authorization", "Bearer " + apikey);
    xhr.send(JSON.stringify({ AccountID: veri }));
};






$(document).ready(function () {
    $("#Version").change(function () {
        var donen = $("#Version").val();
        if (donen == "4.0") {
            document.getElementById("Product1").style.display = "";
            document.getElementById("Product2").style.display = "none";
        }
        else {
            document.getElementById("Product2").style.display = "";
            document.getElementById("Product1").style.display = "none";
        }
    });
});