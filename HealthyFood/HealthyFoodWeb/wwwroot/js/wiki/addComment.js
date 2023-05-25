$(document).ready(function () {

    $('.add-comment').click(function () {
        const userText = $("[name=newComment]").val();
        const blockId = $('[name=blockId]').val();
        $.get(`/api/wiki/AddComment?comment=${userText}&blockId=${blockId}`)
            .then(function (commentId) {
                const copyOfCommentBlock = $(".comment-block.template").clone();

                copyOfCommentBlock.removeClass('template');

                copyOfCommentBlock
                    .find('.comment-text')
                    .text(userText);

                copyOfCommentBlock
                    .find('.remove-form [name=commentId]')
                    .val(commentId);

                $('.comments-container').append(copyOfCommentBlock);
            });

        $("[name=newComment]").val('');
    });

    $('.remove-form .delete-comment-button').click(function () {
        const commentId = $(this)
            .closest('.remove-form')
            .find('[name=commentId]')
            .val();

        $.get(`/api/wiki/removeComment?id=${commentId}`);

        $(this).closest('.comment-block').remove();
    });
});