$(document).ready(function () {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();

    $('img').click(function () {
        hubConnection.invoke("SendMessage", "Image was clicked");
    });

    hubConnection.on("Receive", function (message, author) {
        console.log(author + ": " + message);
    });

    hubConnection.start();
});