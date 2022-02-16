// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var textBox = document.getElementById("SendMessageText")

$("#SendMessageText").keypress(async function (event) {
    if (event.which == 13) {
        event.preventDefault();
        await console.log(textBox.value);
        await resetTextBox(textBox);
    }
    
});

function resetTextBox(textBox) {
    textBox.value = "";
}

//$.post(sendMessage, {
//    type: "POST",
//    url: "/Home/Send",
//    dataType: string,

//})