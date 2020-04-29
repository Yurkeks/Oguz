$(document).ready(function () {
    var subscribeButton = document.getElementById('SubscribeButton');
    subscribeButton.addEventListener('click', Subscribe);
});

function Subscribe() {
    var subscribeBlock = document.getElementById('Subscribe');
    $.ajax({
        type: 'Get',
        dataType: 'json',
        url: '/home/subscribe',
        data: {
            email: subscribeBlock.value
        },
        success: function () {
            subscribeBlock.value = 'Well done!';
        },
        failure: function (jqXHR, textStatus, errorThrown) {
            alert('Status: ' + jqXHR.status + '; Error: ' + jqXHR.responseText);
        }
    });
}