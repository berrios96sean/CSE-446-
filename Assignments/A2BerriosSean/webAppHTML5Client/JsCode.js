function genSecretNum() {
    console.log("test");
    var lower = document.game.lowerLimit.value;
    var upper = document.game.upperLimit.value; 
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            var parser = new DOMParser();
            var xmlDoc = parser.parseFromString(xhttp.responseText, "text/xml");
            var result = xmlDoc.getElementsByTagName("int")[0].textContent;
            document.game.userGuess.value = result; 
        }
    };
    xhttp.open("GET", "http://localhost:50719/Service1.svc/secretNum?lower=1&upper=10", true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
}

function playGame() {

}