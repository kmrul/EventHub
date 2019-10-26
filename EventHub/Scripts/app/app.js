
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


$(function () {
    //$('#ImageUpload').change(function () {
    //    console.log("test action");
    //    var reader = new FileReader();

    //    reader.onload = function (e) {
    //        // get loaded data and render thumbnail.
    //        document.getElementById("eventImage").src = e.target.result;
    //    };

    //    // read the image file as a data URL.
    //    reader.readAsDataURL(this.files[0]);
    //});

    document.getElementById("eventImageUpload").onchange = function () {
        var reader = new FileReader();
        console.log("test image action");
        reader.onload = function (e) {
            // get loaded data and render thumbnail.
            document.getElementById("eventImage").src = e.target.result;
        };

        // read the image file as a data URL.
        reader.readAsDataURL(this.files[0]);
    };
});