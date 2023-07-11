$(document).ready(function () {

    $('#Name').on("keyup", function () {
        const nameOfSimilarGame = $('#NameOfSimilarGame').val();
        $('.preview span.nameOfSimilarGame').text(nameOfSimilarGame);
    });

    $('#Price').on("keyup", function () {
        const url = $('#Url').val();
        $('.preview span.url').text(url);
    });

    $('#CoverUrl').on("keyup", function () {
        const linkForPicture = $('#LinkForPicture').val();
        $('.preview .preview-container img').attr('src', linkForPicture);
    });
});