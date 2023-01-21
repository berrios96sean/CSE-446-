function add2Nos() {
    document.sum.z.value = parseInt(document.sum.x.value) + parseInt(document.sum.y.value)
}

function multiply2Nos() {
    document.sum.z.value = parseInt(document.sum.x.value) * parseInt(document.sum.y.value)
}

function ServiceCall() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange == function () {
        if (xhttp.readyState == 4 && xhttp.status == 200)
            document.sum.s.value = xhttp.responseText;
    }
    xhttp.open("GET", "http://localhost:60331/Service1.svc/add2?x=4&y=4", true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
}