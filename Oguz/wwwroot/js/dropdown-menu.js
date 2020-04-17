window.onload = DropDown();

function DropDown() {

    if ($(window).width() > 990) {
        $('li.dropdown').hover(function () {
            $(this).find('.dropdown-menu').stop(true, true).fadeIn(500);
        }, function () {
            $(this).find('.dropdown-menu').stop(true, true).delay(200).fadeOut(500);
        });
    }

    if ($(window).width() < 990) {
        var dropDown = document.getElementsByClassName('dropdown');
        Array.from(dropDown).forEach((el) => {
            el.addEventListener('touchstart',
                function () {
                    $(this).find('.dropdown-menu').stop(true, true).fadeIn(500);
                    $(document).mouseup(function (e) {
                        if ($(dropDown).has(e.target).length === 0) {
                            $(dropDown).find('.dropdown-menu').stop(true, true).delay(200).fadeOut(500);;
                        }
                    });
                });
        });
        $(document).ready(function () { touchHover(); });
    };
}


function touchHover() {
    $('[data-hover]').click(function (e) {
        e.preventDefault();
        var $this = $(this);
        var onHover = $this.attr('data-hover');
        var linkHref = $this.attr('href');
        if (linkHref && $this.hasClass(onHover)) {
            location.href = linkHref;
            return false;
        }
        $this.toggleClass(onHover);
    });
}


