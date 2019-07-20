
var EventsController = function () {
    var init = function () {
        $(".js-toggle-attendance").click(function (e) {
            var button = $(e.target);
            if (button.hasClass("btn-default")) {
                $.post("/api/attendances", { "EventId": button.attr("data-event-id") })
                    .done(function () {
                        button
                            .removeClass("btn-primary")
                            .addClass("btn-info")
                            .text("Going");
                    })
                    .fail(function () {
                        alert("Something failed");
                    });
            } else {
                $.ajax({
                    url: "/api/attendances/" + button.attr("data-event-id"),
                    method: "DELETE"
                })
                    .done(function () {
                        button.removeClass("btn-info").
                            addClass("btn-default")
                            .text("Going?");
                    })
                    .fail(function () {
                        alert("Something is wrong");
                    });
            }
        });

        return {
            init: init
        };
    };
}();