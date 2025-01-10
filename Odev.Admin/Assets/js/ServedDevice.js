var baseURL = "https://llcp57u13c.execute-api.eu-central-1.amazonaws.com/Prod/";
var deviceId = "";

localStorage.removeItem('AccountID');
localStorage.removeItem('NewAccountID');

function showMe(blockId) {

    document.getElementById("CLSCode").style.display = "none";
    document.getElementById("gizlebeni").style.display = 'none';
    if (document.getElementById("AccountID").value.trim() != "") {
        var accountID = document.getElementById("AccountID").value.trim();
        document.getElementById("AccountID").value = "";
        document.getElementById("NotFound").style.display = "none";
        document.getElementById(blockId).style.display = 'none';

        var dataTable;

        dataTable = $('.dataTables-example').DataTable({
            paging: false,
            pageLength: 50,
            retrieve: true,
            responsive: true,
            dom: '<"html5buttons"B>lTfgitp',
            buttons: [
                { extend: 'excel', title: 'ExampleFile' },
                { extend: 'pdf', title: 'ExampleFile' },

                {
                    extend: 'print',
                    customize: function (win) {
                        $(win.document.body).addClass('white-bg');
                        $(win.document.body).css('font-size', '10px');

                        $(win.document.body).find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');
                    }
                }
            ],
            success: GetCLS(accountID)
        });

        function GetCLS(account) {
            var url = baseURL + "api/device/GetAutoProvisionedServer/" + account;
            var apikey = document.cookie.replace(/(?:(?:^|.*;\s*)Token\s*\=\s*([^;]*).*$)|^.*$/, "$1");
            var xhr = new XMLHttpRequest();
            xhr.open('GET', url, true);
            //xhr.withCredentials=true;
            xhr.onload = function (event) {
                if (xhr.status == 200) {
                    var p = JSON.parse(event.target.response);
                    deviceId = p;

                    
                    document.getElementById("CLSCode").innerHTML = "<strong>" + "CLS ID : " + p + "</strong>";

                    Data(deviceId);
                }
            }
            xhr.setRequestHeader('Content-Type', 'application/json');
            xhr.setRequestHeader("Authorization", "Bearer " + apikey);
            xhr.send();
        }
    }
    else if (document.getElementById("CLSID").value.trim() != "") {

        var clsID = document.getElementById("CLSID").value.trim();
        document.getElementById("CLSID").value = "";
        document.getElementById("NotFound").style.display = "none";
        document.getElementById(blockId).style.display = 'none';

        var dataTable;

        dataTable = $('.dataTables-example').DataTable({
            paging: false,
            pageLength: 50,
            retrieve: true,
            responsive: true,
            dom: '<"html5buttons"B>lTfgitp',
            buttons: [
                { extend: 'excel', title: 'ExampleFile' },
                { extend: 'pdf', title: 'ExampleFile' },

                {
                    extend: 'print',
                    customize: function (win) {
                        $(win.document.body).addClass('white-bg');
                        $(win.document.body).css('font-size', '10px');

                        $(win.document.body).find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');
                    }
                }
            ],
            success: Data(clsID)
        });

    }
    else {
        document.getElementById(blockId).style.display = 'none';
        document.getElementById("CLSID").value = "";
        document.getElementById("NotFound").style.display = "";
    }

    function Data(result) {
        var a = 0;
        var url = baseURL + "api/device/getserveddevices2/" + result;
        var token = document.cookie.match(new RegExp('(^| )' + "Token" + '=([^;]+)'));
        var request = new XMLHttpRequest();
        request.open('GET', url, true);
        //request.withCredentials=true;
        request.onload = function () {
            if (this.status >= 200) {
                var p = JSON.parse(this.response);
                dataTable.clear();
                var asd = _.groupBy(p, "hostName");
                for (var prop in asd) {
                    dataTable.row.add([
                        asd[prop][0].hostid.hostidValue,
                        asd[prop][0].hostName,
                        new Date(asd[prop][0].expiry).toLocaleDateString('tr-TR').slice(0, 10),
                        new Date(asd[prop][0].updateTime).toLocaleDateString('tr-TR').slice(0, 10),
                        '<button  data-id=' + asd[prop][0].id + ' data-post-id=' + result + '  class="btn btn-danger">Remove Device</button> '
                    ]);
                }

                dataTable.draw();
                document.getElementById(blockId).style.display = '';
                document.getElementById("CLSCode").style.display = "";

            } else {
                alert("Hata");
            }

        };

        request.setRequestHeader('Content-Type', 'application/json');
        request.setRequestHeader("Authorization", "Bearer " + token[2]);
        request.send();
    }
}

$(document).ready(function () {
    var clsID = document.cookie.replace(/(?:(?:^|.*;\s*)CLSID\s*\=\s*([^;]*).*$)|^.*$/, "$1");
    if (clsID != "") {
        document.getElementById("CLSID").value = "";
        document.getElementById("NotFound").style.display = "none";
        document.getElementById("gizlebeni").style.display = 'none';

        var dataTable;

        dataTable = $('.dataTables-example').DataTable({
            paging: false,
            pageLength: 50,
            retrieve: true,
            responsive: true,
            dom: '<"html5buttons"B>lTfgitp',
            buttons: [
                { extend: 'excel', title: 'ExampleFile' },
                { extend: 'pdf', title: 'ExampleFile' },

                {
                    extend: 'print',
                    customize: function (win) {
                        $(win.document.body).addClass('white-bg');
                        $(win.document.body).css('font-size', '10px');

                        $(win.document.body).find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');
                    }
                }
            ],
            success: Data(clsID)
        });

        function Data(result) {
            var a = 0;
            var url = baseURL + "api/device/getserveddevices2/" + result;
            var token = document.cookie.match(new RegExp('(^| )' + "Token" + '=([^;]+)'));
            var request = new XMLHttpRequest();
            request.open('GET', url, true);
            //request.withCredentials=true;
            request.onload = function () {
                if (this.status >= 200) {
                    var p = JSON.parse(this.response);
                    dataTable.clear();
                    var asd = _.groupBy(p, "hostName");
                    for (var prop in asd) {
                        dataTable.row.add([
                            asd[prop][0].hostid.hostidValue,
                            asd[prop][0].hostName,
                            new Date(asd[prop][0].expiry).toLocaleDateString('tr-TR').slice(0, 10),
                            new Date(asd[prop][0].updateTime).toLocaleDateString('tr-TR').slice(0, 10),
                            '<button  data-id=' + asd[prop][0].id + ' data-post-id=' + result + '  class="btn btn-danger">Remove Device</button> '
                        ]);
                    }

                    dataTable.draw();
                    document.getElementById("gizlebeni").style.display = '';

                } else {
                    alert("Hata");
                }

            };

            request.setRequestHeader('Content-Type', 'application/json');
            request.setRequestHeader("Authorization", "Bearer " + token[2]);
            request.send();
        }
    }

    $("#ServedDeviceList").on("click", "button", function () {
        var dataId = $(this).data("id");
        var dataClsId = $(this).data("post-id");
        var data = {
            Id: dataId,
            CLSID: dataClsId
        };

        swal({
            title: "Are you sure?",
            text: "Please wait a minute after pressing the delete button !!!!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Remove",
            cancelButtonText: "Cancel",
            closeOnConfirm: false,
            closeOnCancel: false,

        },
            function (isConfirm) {
                if (isConfirm) {
                    $.ajax({
                        type: "POST",
                        url: "/ServedDevice/Delete/",
                        data: data,
                        success: function (mahmt) {
                            if (mahmt) {

                                swal({
                                    title: "Remove is Successful.",
                                    type: "success",
                                    confirmButtonText: "OK",
                                    closeOnConfirm: false
                                }, function () {
                                    location.reload();
                                });
                            }
                            else {
                                alert("Something went wrong")
                            }

                        }
                    });
                } else {
                    swal({
                        title: "It is cancelled.",
                        type: "error",
                        confirmButtonText: "OK",
                        closeOnConfirm: false,

                    });
                }
            });
    });
});

