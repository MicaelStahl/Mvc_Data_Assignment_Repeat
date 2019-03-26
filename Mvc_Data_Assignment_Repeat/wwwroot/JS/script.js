$(".aUpdate").click(function (e) {
    e.preventDefault();
    var _this = $(this);
    $.get(_this.attr("href"), function (res) {
        $('#' + _this.data("target")).html(res);
    });
});