$(function () {
    var myModal = new bootstrap.Modal(document.getElementById('myModal'), {
        keyboard: false
    })

    var hub = $.connection.envoyWebhookEventHub;
    hub.client.notifyEnvoyWebhookEvent = function (eventName, data) {
        $('#exampleModalLabel').text(eventName);
        $('#myModal .modal-body pre').text(JSON.stringify(JSON.parse(data), null, 4));
        myModal.show();
    };

    $.connection.hub.start().done(function () {
    });
});