// I don't know if I'm using this somewhere, but didn't bother removing it. 
$(".aUpdate").click(function (e) {
    e.preventDefault();
    var _this = $(this);
    $.get(_this.attr("href"), function (res) {
        $('#' + _this.data("target")).html(res);
    });
});

// This code is used for the first part of edit and Delete. it replaces the
// "Target" with url which stops the webpage from refreshing, creating a 
// More smooth feel for the user.
function LinkUpdate(url, target) {
    $.get(url, function (res) {
        $('#' + target).replaceWith(res);
    });
}

// This code is used for the second part of Edit. It gathers the new values,
// Sends it to the targetted Action in the specified Controller in the
// "urlPath" and then sends you back to the page you previously were on.
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

// This code gathers the value from all the inputs and sends it
// to the targetted Action in the specified Controller in "url"
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

// This works the same as LinkCreate except that it sends the filter.
function LinkFilter(url) {
    $.post(url,
        { Filter: $('#filter').val() },
        function (res) {
            $('#personList').html(res);
        });
}