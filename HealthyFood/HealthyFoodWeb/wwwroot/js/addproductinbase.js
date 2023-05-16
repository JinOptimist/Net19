$(document).ready(function () {

    $('#Name').on("keyup", function () {
        const productName = $('#Name').val();
        $('.preview span.name').text(productName);
    });

    $('#Price').on("keyup", function () {
        const price = $('#Price').val();
        $('.preview span.price').text(price);
    });
       
});

