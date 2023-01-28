var secNum; 
function genSecNum() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200 ) {
            var parser = new DOMParser();
            var xmlDoc = parser.parseFromString(xhttp.responseText, "text/html");
            var result = xmlDoc.getElementsByTagName("int")[0].textContent;
            console.log(result);
            secNum = result;
            document.game.upperLimit.value = secNum;
        }
    };

    xhttp.open("GET", "http://localhost:50719/Service1.svc/secretNum?lower=1&upper=10", true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
   
}

function playGame() {

}