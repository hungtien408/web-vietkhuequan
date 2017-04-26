(function ($) {
    $(window).load(function () {
        EqualSizer('.wrap-product .content section .item-cate .item .content');
    });
    $(window).resize(function () {
        EqualSizer('.wrap-product .content section .item-cate .item .content');
        height_img();
        height_ul_about();
    });
    $(function () {
        mymap();
        myfunload();
        height_img();
        img_absolute();
        height_ul_about();
    });
})(jQuery);
function height_img() {
    $win = $(window).height();
    n = $('#header').height();
    m = $('#footer').outerHeight();
    //console.log(n, m);
    $('.banner-absolute').height($win - (n + m));
    $('.wrap-about').outerHeight($win - (n + m));
}
function img_absolute() {
    $('.banner-absolute > img').hide();
    n = $('.banner-absolute > img').attr('src');
    $('.banner-absolute').css('background-image', 'url("' + n + '")');
}
function height_ul_about() {
    n = $('.wrap-about').height();
    m = $('.wrap-about .head').height();
    $('.wrap-about ul').css('height', (n - m));
    $('.wrap-about ul').mCustomScrollbar({
        autoHideScrollbar: true,
        theme: "dark-thick",
    });
}
//function===============================================================================================
/*=============================fun=========================================*/
function myfunload() {
    $(".panel-a").mobilepanel();
    $("#menu > li").not(".home").clone().appendTo($("#menuMobiles"));
    $("#menuMobiles input").remove();
    $("#menuMobiles > li > a").append('<span class="fa fa-chevron-circle-right iconar"></span>');
    $("#menuMobiles li li a").append('<span class="fa fa-angle-right iconl"></span>');
    //$("#menu > li:last-child").addClass("last");
    //$("#menu > li:first-child").addClass("fisrt");
    //$("#menu > li").find("ul").addClass("menu-level");

    $('#menu li').hover(function () {
        $(this).children('ul').stop(true, false, true).slideToggle(300);
    });

    /*=====  =====*/
    
}

/*=========================================================================*/
//================== scroll top
$(window).scroll(function () {
    if ($(this).scrollTop() > 100) {
        $('.scroll-to-top').fadeIn();
    } else {
        $('.scroll-to-top').fadeOut();
    }
});

$(window).scroll(function () {
    if ($(this).scrollTop() > 138) {
        $('.bot-head').addClass('bot-head-scroll');
    }
    else {
        $('.bot-head').removeClass('bot-head-scroll');
    }
});

$('.scroll-to-top').on('click', function (e) {
    e.preventDefault();
    $('html, body').animate({ scrollTop: 0 }, 800);
    return false;
});

function DoEqualSizer(myclass) {
    var heights = $(myclass).map(function() {
        $(this).height('auto');
        return $(this).height();
    }).get(),
    maxHeight = Math.max.apply(null, heights);
    $(myclass).height(maxHeight);
};
function EqualSizer_1(myclass) {
    $(document).ready(DoEqualSizer(myclass));
    window.addEventListener('resize', function () {
        DoEqualSizer(myclass);
    });
};
function EqualSizer(myclass) {
    $(document).ready(DoEqualSizer(myclass));
    window.addEventListener('resize', function() { 
        DoEqualSizer(myclass); 
    });
};
//==================
function mymap() {
    mympp();
    var timeout;
    $(window).resize(function () {
        clearTimeout(timeout);
        setTimeout(function () {
            mympp();
        }, 500);
    });
}
function mympp() {
    $('#mapwrap').remove();
    if ($(window).width() > 768) {
        $('#mapshow').append('<div id="mapwrap"><iframe id="iframe" src="map.aspx" frameborder="0" height="100%" width="100%"></iframe></div>');
    }
}

