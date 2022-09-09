$(function () {
    var myModal = new bootstrap.Modal(document.getElementById('myModal'), {
        keyboard: false
    });

    document.getElementById('myModal').addEventListener('hidden.bs.modal', function (event) {
        $('#myModal .modal-body pre').empty();
    });

    var hub = $.connection.envoyWebhookEventHub;
    hub.client.notifyEnvoyWebhookEvent = function (eventName, data) {
        $('#exampleModalLabel').text(eventName);
        $('#myModal .modal-body pre').append(JSON.stringify(JSON.parse(data), null, 4) + '\r\n\r\n' );
        myModal.show();
    };

    $.connection.hub.start().done(function () {
    });
});