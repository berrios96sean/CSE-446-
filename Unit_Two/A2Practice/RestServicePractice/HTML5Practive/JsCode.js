function add2Nos() {
    document.sum.z.value = parseInt(document.sum.x.value) + parseInt(document.sum.y.value)
}

function multiply2Nos() {
    document.sum.z.value = parseInt(document.sum.x.value) * parseInt(document.sum.y.value)
}

function ServiceCall() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            var parser = new DOMParser();
            var xmlDoc = parser.parseFromString(xhttp.responseText, "text/xml");
            var result = xmlDoc.getElementsByTagName("int")[0].textContent;
            document.sum.s.value = result;
        }
    };
    xhttp.open("GET", "http://localhost:60331/Service1.svc/add2?x=" + document.sum.x.value + "&y=" + document.sum.y.value, true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();

}