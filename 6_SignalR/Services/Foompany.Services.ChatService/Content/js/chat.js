"use strict";

//create connection (use the generic 'Glow.SignalR' hub provided by the prism server)
var connection = new signalR.HubConnectionBuilder().withUrl("/Glow.SignalR").build();


//Disable buttons until connection is established
document.getElementById("loginButton").disabled = true;
document.getElementById("sendButton").disabled = true;


//start connection
connection.start().then(function () {
    document.getElementById("loginButton").disabled = false;
});


//login button.
document.getElementById("loginButton").addEventListener("click", async function (event) {
    try {
        event.preventDefault();
        //get input
        var uname = document.getElementById("usernameInput").value;
        //Register client
        var result = await connection.invoke
            (
                "REGISTER",                                     // This is a registration operation
                "ChatService/Chat/ClientConnectionRequest",     // The path to hit for registration handling
                JSON.stringify(uname)                           // Registration request msg (json)
            );
        if (result === "ok") {
            document.getElementById("sendButton").disabled = false;
            alert("logged in!");
        }
    }
    catch (err) { alert(err); }
});


//send chat message button
document.getElementById("sendButton").addEventListener("click", async function (event) {
    try {
        event.preventDefault();
        //get input
        var dstUser = document.getElementById("dstuserInput").value;
        var message = document.getElementById("messageInput").value;
        //Send Msg
        var result = await connection.invoke("POST", "ChatService/Chat/SendMessage", "toUser=" + dstUser, JSON.stringify(message));
    }
    catch (err) { alert(err); }
});


//register event for new chat msg
connection.on("ChatMsg", function (message) {
    var li = document.createElement("li");
    li.textContent = JSON.parse(message);
    document.getElementById("messagesList").appendChild(li);
});


//register event for new notification msg
connection.on("NotificationMsg", function (message) {
    var li = document.createElement("li");
    li.textContent = "*** " + JSON.parse(message);
    document.getElementById("messagesList").appendChild(li);
});
