"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", async function (user, message) {

    var messageDivRow = document.createElement("div");
    var messageDivCol = document.createElement("div");
    var messageDivEmpty = document.createElement("div");

    var chatContainer = document.getElementById("chatContainer");
    var currentUser = await connection.invoke("GetCurrentUser");
    var sentMessage = `${user} : ${message}`;

 
    

    if (currentUser == user) {
        messageDivRow.className = "row mt-3 mb-3 justify-content-end";
        messageDivCol.className = "col-5 rounded ml-5 mr-3 p-3 bg-info text-white";
        messageDivEmpty.className = "col-5 mr-1";

        messageDivRow.appendChild(messageDivEmpty);
        messageDivRow.appendChild(messageDivCol);
        chatContainer.appendChild(messageDivRow);

        messageDivCol.textContent = sentMessage;

        chatContainer.scrollTo(0, chatContainer.offsetHeight);
    }
    else {
        messageDivRow.className = "row mt-3 mb-3 justify-content-start";
        messageDivCol.className = "col-5 rounded ml-3 mr-5 p-3 bg-success text-white";
        messageDivEmpty.className = "col-5 ml-1";

        messageDivRow.appendChild(messageDivCol);
        messageDivRow.appendChild(messageDivEmpty);
        chatContainer.appendChild(messageDivRow);

        messageDivCol.textContent = sentMessage;
    }
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;

    var message = document.getElementById("messageInput").value;

    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });



    //DotNet.invokeMethodAsync('BugTrackerTry', 'ArchiveMessageAsync', {message, user});
    event.preventDefault();
});