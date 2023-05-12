var secretNum;
var attempts;
function sendMessage() {
    var recId = document.receiver.receiverID.value;
    var senderID = document.receiver.senderID.value;
    var message = document.receiver.sentmessage.value;
    attempts = 0;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            var parser = new DOMParser();
            var xmlDoc = parser.parseFromString(xhttp.responseText, "text/xml");
            var result = xmlDoc.getElementsByTagName("string")[0].textContent;
            secretNum = result;
            document.getElementById("attempts").innerHTML = attempts;
        }
    };
    xhttp.open("GET", "http://localhost:50719/Service1.svc/SendMessage/" + senderID + "/" + recId + "/" + message, true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
}

function genSecretNum() {
    var lower = document.game.lowerLimit.value;
    var upper = document.game.upperLimit.value;
    attempts = 0; 
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            var parser = new DOMParser();
            var xmlDoc = parser.parseFromString(xhttp.responseText, "text/xml");
            var result = xmlDoc.getElementsByTagName("int")[0].textContent;
            secretNum = result;
            document.getElementById("attempts").innerHTML = attempts;
        }
    };
    xhttp.open("GET", "http://localhost:50719/Service1.svc/secretNum?lower="+lower+"&upper="+upper, true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
}

function play_Game() {
    var guess = document.game.userGuess.value;
    attempts++;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            var result = xhttp.responseText;
            document.getElementById("result").innerHTML = result;
            document.getElementById("attempts").innerHTML = attempts; 
        }
    };
    xhttp.open("GET", "http://localhost:50719/Service1.svc/checkNum?userNum="+guess+"&secretNum="+secretNum, true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
}

