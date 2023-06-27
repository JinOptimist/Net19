$(document).ready(function () {

    $('#NewReview').on("keyup", function () {
        const textReview = $('#NewReview').val();
        $('.new-review span.user-review').text(textReview);
    });

});