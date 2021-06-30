$('.profile').on('click', function () {
    $(".HoverAbleDivCart").hide();
    $(".HoverAbleDivProfile").toggle();
});

$('.cart').on('click', function () {
    $(".HoverAbleDivProfile").hide();
    $(".HoverAbleDivCart").toggle();
});

$('#dismiss, .overlay').on('click', function () {
    $('#sidebar').removeClass('active');
    $('.overlay').removeClass('active');
});
$('#sidebarCollapse').on('click', function () {
    $('#sidebar').addClass('active');
    $('.overlay').addClass('active');
    $('.collapse.in').toggleClass('in');
    $('a[aria-expand=true').attr('aria-expanded', 'false');
});