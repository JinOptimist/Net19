$(document).ready(function () {

    $('#ImgType').on("change", function () {
        const imgType = $("#ImgType option:selected").text();
        $('.image-preview span.type').text(imgType);
    });

    $('#Year').on("keyup", function () {
        const year = $('#Year').val();
        $('.image-preview span.year').text(year);
    });

    $('#EnteredTags').on("keyup", function () {
        const enteredTags = $('#EnteredTags').val();
        $('.image-preview span.tags').text(enteredTags);
    });

    $('#ImgPath').on("keyup", function () {
        const imgPath = $('#ImgPath').val();
        $('.image-preview .preview-container img').attr('src', imgPath);
    });

});