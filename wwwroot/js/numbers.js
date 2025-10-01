function sendAction(action) {
    $.post(`/Numbers/${action}`, {}, function (data) {
        $('#numberContainer').html(data);
    });
}