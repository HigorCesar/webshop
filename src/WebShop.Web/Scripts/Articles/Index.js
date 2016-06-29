function bindAddToCart() {
    $(".add-to-cart").click(function () {
        var articleId = $(this).attr('x-article-id');
        $.ajax({
            method: 'POST',
            url: '/ShoppingCart/AddItem',
            data: { "id": articleId },
            success: function (data) {
                $("#shopping-cart-count").html(data);
            }
        });
    });
}