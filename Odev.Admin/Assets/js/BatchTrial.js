var baseURL = "https://llcp57u13c.execute-api.eu-central-1.amazonaws.com/Prod/";

localStorage.removeItem('AccountID');
localStorage.removeItem('NewAccountID');

document.cookie = 'CLSID' + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';

window.onload = function () {
    var json;
    function handleFileSelect(evt) {
        var files = evt.target.files;
    }
    document.getElementById('files').addEventListener('change', handleFileSelect, false);
    function handleFileSelect(evt) {
        var files = evt.target.files;
        var output = [];
        for (var i = 0, f; f = files[i]; i++) {
            var reader = new FileReader();
            reader.onload = (function (theFile) {
                return function (e) {
                    console.log('e readAsText = ', e);
                    console.log('e readAsText target = ', e.target);
                    try {
                        json = JSON.parse(e.target.result);
                        var asd = JSON.stringify(json)
                        if (json[1].AccountID) {
                            var url = baseURL + "api/trial/batchlicense";
                            var apikey = document.cookie.replace(/(?:(?:^|.*;\s*)Token\s*\=\s*([^;]*).*$)|^.*$/, "$1");
                            var xhr = new XMLHttpRequest();
                            xhr.open('POST', url, true);
                            //xhr.withCredentials=true;
                            xhr.onload = function (event) {
                                if (xhr.status == 200) {
                                    var p = JSON.parse(event.target.response);
                                    var data = "text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(p));
                                    var ekstra = document.getElementById('JsonIndir');
                                    var element = document.createElement("div");
                                    element.setAttribute("id", "FileDowload");
                                    element.setAttribute("name", "FileDowload");
                                    ekstra.appendChild(element);
                                    document.getElementById("FileDowload").innerHTML = '<a class="btn btn-info btn-sm" style="color:#FFF;" href="data:' + data + '" download="data.json">Download JSON</a>';
                                    document.getElementById("btnDowload").style.display = "none";
                                }
                            };
                            xhr.setRequestHeader('Content-Type', 'application/json');
                            xhr.setRequestHeader("Authorization", "Bearer " + apikey);
                            xhr.send(JSON.stringify(json));
                        }
                        else {
                            document.getElementById("btnDowload").style.display = "";
                            document.getElementById("btnDowload").disabled = false;
                            alert("Benim Json'ı ver");
                        }
                    } catch (ex) {
                        alert('ex when trying to parse json = ' + ex);
                    }
                }
            })(f);
            reader.readAsText(f);
        }
    }
    document.getElementById('files').addEventListener('change', handleFileSelect, false);
}