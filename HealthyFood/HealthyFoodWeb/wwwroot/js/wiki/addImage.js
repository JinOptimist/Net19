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

    ImgCover.onchange = evt => {
        const [file] = ImgCover.files
        if (file) {
            newImg.src = URL.createObjectURL(file)
        }
    }
});
