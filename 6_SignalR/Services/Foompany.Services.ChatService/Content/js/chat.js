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
        //create request 
        var request = { Username: uname };
        //Register client
        var result = await connection.invoke
            (
                "REGISTER",                                     // This is a registration operation
                "ChatService/Chat/ClientConnectionRequest",     // The path to hit for registration handling
                request                                         // Registration request
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
        var message = { Text: document.getElementById("messageInput").value };
        //Send Msg
        var res = await connection.invoke("CALL", "ChatService/Chat/SendMessage", "toUser=" + dstUser, message);
        console.log(res);
    }
    catch (err) { alert(err); }
});


//register event for new chat msg
connection.on("ChatMsg", function (message) {
    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("messagesList").appendChild(li);
});


//register event for new notification msg
connection.on("NotificationMsg", function (message) {
    var li = document.createElement("li");
    li.textContent = "*** " + message;
    document.getElementById("messagesList").appendChild(li);
});
