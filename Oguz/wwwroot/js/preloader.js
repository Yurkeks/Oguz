function loadData() {
    return new Promise((resolve, reject) => {
        setTimeout(resolve, 0);
    })
}
loadData()
    .then(() => {
        setTimeout(() => {
            var preloader = $('#preloader');
            preloader.css('opacity', 0);
            preloader.css('z-index', -100);
            setTimeout(
                () => preloader.remove(),
                parseInt(preloader.css('--duration')) * 1000
            );
            document.body.style.overflowY = 'auto';
        }, 1000);

    });

//window.onload = function () { 
//var prelodaer = document.getElementById('preloader');
//prelodaer.style.display = 'none';
//}