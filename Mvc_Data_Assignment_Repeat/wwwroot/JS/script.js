$(".aUpdate").click(function (e) {
    e.preventDefault();
    var _this = $(this);
    $.get(_this.attr("href"), function (res) {
        $('#' + _this.data("target")).html(res);
    });
});

function LinkUpdate(url, target) {
    $.get(url, function (res) {
        $('#' + target).replaceWith(res);
    });
}

function LinkEdit(url, target, personId) {
    $.post(url,
        {
            Id: personId,
            Name: $('#' + target + 'Name').val(),
            PhoneNumber: $('#' + target + 'PhoneNumber').val(),
            City: $('#' + target + 'City').val()
        },
        function (res) {
            $('#' + target).replaceWith(res);
        });
}

function LinkCreate(url) {
    $.post(url,
        {
            Name: $('#createName').val(),
            PhoneNumber: $('#createPhoneNumber').val(),
            City: $('#createCity').val()
        },
        function (res) {
            $('#allPersons').append(res);
        });
}