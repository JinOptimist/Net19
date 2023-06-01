$(document).ready(function () {

    $('.get-img-count').click(function () {
        const year = $('.img-year').val();
        const tag = $('.img-tag').val();
        const type = $("#ImgType option:selected").val();
        const url = `/api/wiki/ImagesCount?year=${year}&tag=${tag}&type=${type}`;
        $.get(url)
            .then(function (dataObj) {
                console.log(dataObj);
                $('.parent').empty();
                for (let i = 0; i < dataObj.imagesUrl.length; i++) {
                    const imageUrl = dataObj.imagesUrl[i];
                    const copyImg = $('.filter-output .template').clone();
                    copyImg.removeClass('template');
                    copyImg.attr('src', imageUrl);
                    $('.parent').append(copyImg);
                }
                $('.img-count').text(dataObj.totalImagesCount);
                $('.have-to-block').removeAttr('disabled');
                $('.loader').hide();
            });

        $('.have-to-block').attr('disabled', 'disabled');
        $('.loader').show();
    });

    $('.filter-and-images h3').click(function () {
        $(this)
            .closest('.filter-and-images')
            .find('.filter-block')
            .toggle(1000);
    });

});