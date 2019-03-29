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

function LinkEdit(urlPath, target, personId) {
    $.ajax({
        url: urlPath,
        data: {
            Id: personId,
            Name: $('#' + target + 'Name').val(),
            PhoneNumber: $('#' + target + 'PhoneNumber').val(),
            City: $('#' + target + 'City').val()
        },
        method: "POST",
        //dataType: "text",
        success: function (data) {
            console.log('Ajax was successfully called');
            $('#' + target).replaceWith(data);
        },
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
            $('#personList').append(res);
        });
}

function LinkFilter(url) {
    $.post(url,
        { Filter: $('#filter').val() },
        function (res) {
            $('#personList').html(res);
        });
}