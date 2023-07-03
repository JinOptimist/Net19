$(document).ready(function () {

    $('.quantity-controller-plus').click(function () {

        const quantityNumber = $('#Quantity').val() + 1;
       
        $('.quantity-number').text(quantityNumber);
    });

});