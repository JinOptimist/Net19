$(document).ready(function () {

    $('.quantity-controller-plus').click(function () {

        const quantityNumber = $('#Quantity').val() + 1;
       
        $('.quantity-number').text(quantityNumber);
    });

    //$('.delete-comment-button').click(DeletComment);

    //function DeletComment() {
    //    const commentId = $(this)
    //        .closest('.remove-form')
    //        .find('[name=commentId]')
    //        .val();

    //    $.get(`/api/wiki/removeComment?id=${commentId}`);

    //    $(this).closest('.comment-block').remove();
    //}

});