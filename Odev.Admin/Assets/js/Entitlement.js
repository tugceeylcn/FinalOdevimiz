var baseURL = "https://llcp57u13c.execute-api.eu-central-1.amazonaws.com/Prod/";


localStorage.removeItem('AccountID');
localStorage.removeItem('NewAccountID');
document.cookie = 'CLSID' + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';

function showMe(blockId) {

    document.getElementById("CLSCode").style.display = "none";
    document.getElementById("gizlebeni").style.display = 'none';
    if (document.getElementById("AccountID").value.trim() != "") {
        var accountID = document.getElementById("AccountID").value.trim();
        var dataTable;
        dataTable = $('.dataTables-example').DataTable({
            paging: false,
            retrieve: true,
            responsive: true,
            dom: '<"html5buttons"B>lTfgitp',
            buttons: [
                { extend: 'excel', title: 'Entitlement' + accountID },
                { extend: 'pdf', title: 'Entitlement' + accountID },
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
            success: Data()
        });

        document.getElementById("gizlebeni2").style.display = 'none';
        function Data() {
            var url = baseURL + "api/entitlement/getentitlementbyaccountid/" + accountID;
            var token = document.cookie.match(new RegExp('(^| )' + "Token" + '=([^;]+)'));
            var request = new XMLHttpRequest();
            request.open('GET', url, true);
            //request.withCredentials=true;
            request.onload = function () {
                if (this.status >= 200) {
                    var p = JSON.parse(this.response);
                    dataTable.clear();
                    for (var i = 0; i < p.length; i++) {
                        dataTable.row.add([
                            '<a style="color:#36757f;" onclick="LineItem(\'' + p[i].EntitlementId + '\',\'' + accountID + '\')">' + p[i].EntitlementId + '</a> ',
                            p[i].SoldTo,
                            p[i].EntitlementState,
                            new Date(p[i].LastModifiedDateTime).toLocaleDateString('tr-TR').slice(0, 10),
                            new Date(p[i].CreatedOnDateTime).toLocaleDateString('tr-TR').slice(0, 10)
                        ]);

                        LineItem(p[0].EntitlementId, accountID);
                    }
                    dataTable.draw();
                    document.getElementById(blockId).style.display = '';
                    GetCLS();
                } else {
                    alert("Hata");
                }
            };
            request.setRequestHeader('Content-Type', 'application/json');
            request.setRequestHeader("Authorization", "Bearer " + token[2]);
            //request.setRequestHeader("")
            request.send();
        }
        function GetCLS() {
            var apiUrl = baseURL + "api/device/GetAutoProvisionedServer/" + accountID;
            var apikey = document.cookie.replace(/(?:(?:^|.*;\s*)Token\s*\=\s*([^;]*).*$)|^.*$/, "$1");
            var xhr = new XMLHttpRequest();
            xhr.open('GET', apiUrl, true);
            //xhr.withCredentials=true;
            xhr.onload = function (event) {
                if (xhr.status == 200) {
                    var p = JSON.parse(event.target.response);
                    document.getElementById("CLSCode").style.display = "";
                    document.getElementById("CLSCode").innerHTML = "<strong>" + "CLS ID : " + p + "</strong>";
                    document.getElementById("loader").style.display = "none";
                    document.getElementById("myDiv").style.display = "block";
                }
            }
            xhr.setRequestHeader('Content-Type', 'application/json');
            xhr.setRequestHeader("Authorization", "Bearer " + apikey);
            
            xhr.send();
        }
    }
    else {
        document.getElementById(blockId).style.display = 'none';
        document.getElementById("AccountID").value = "";
    }
}

function LineItem(e, accountID) {
    document.getElementById("gizlebeni2").style.display = 'none';
    var dataTable2;
    dataTable2 = $('.dataTables-example2').DataTable({
        paging: false,
        retrieve: true,
        responsive: true,
        dom: '<"html5buttons"B>lTfgitp',
        buttons: [
            { extend: 'excel', title: 'Line Items' + accountID },
            { extend: 'pdf', title: 'Line Items' + accountID },
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
        success: LineItemData(e, accountID)
    });
    function LineItemData(e, accountID) {
        var url = baseURL + "api/entitlement/getentitlementbyaccountid/" + accountID;
        var token = document.cookie.match(new RegExp('(^| )' + "Token" + '=([^;]+)'));
        var request = new XMLHttpRequest();
        request.open('GET', url, true);
        //request.withCredentials=true;
        request.onload = function () {
            if (this.status >= 200) {
                var p = JSON.parse(this.response);
                dataTable2.clear();
                for (var i = 0; i < p.length; i++) {
                    if (p[i].EntitlementId == e) {
                        for (var j = 0; j < p[i].LineItems.length; j++) {
                            if (new Date(p[i].LineItems[j].Expire).toLocaleDateString('tr-TR').slice(0, 10) == "01.01.1") {
                                dataTable2.row.add([
                                    p[i].LineItems[j].ActivationId,
                                    p[i].LineItems[j].Product,
                                    "Permenant",
                                    p[i].LineItems[j].Quantity,
                                    p[i].LineItems[j].State
                                ]);
                            }
                            else {
                                dataTable2.row.add([
                                    p[i].LineItems[j].ActivationId,
                                    p[i].LineItems[j].Product,
                                    new Date(p[i].LineItems[j].Expire).toLocaleDateString('tr-TR').slice(0, 10),
                                    p[i].LineItems[j].Quantity,
                                    p[i].LineItems[j].State
                                ]);
                            }
                            
                        }
                    }
                }
                dataTable2.draw();
                document.getElementById("gizlebeni2").style.display = '';

            } else {
                alert("Hata");
            }
        };
        request.setRequestHeader('Content-Type', 'application/json');
        request.setRequestHeader("Authorization", "Bearer " + token[2]);

        request.send();
    }
}