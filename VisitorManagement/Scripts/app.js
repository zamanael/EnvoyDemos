$(function () {
    var myModal = new bootstrap.Modal(document.getElementById('myModal'), {
        keyboard: false
    })

    var hub = $.connection.envoyWebhookEventHub;
    hub.client.notifyEnvoyWebhookEvent = function (eventName, data) {
        $('#exampleModalLabel').text(eventName);
        $('#myModal .modal-body .prettyprint').text(JSON.stringify(JSON.parse(data), null, '\r\n'));
        myModal.show();
    };

    $.connection.hub.start().done(function () {
    });
});