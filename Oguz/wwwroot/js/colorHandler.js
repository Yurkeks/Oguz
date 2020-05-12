document.addEventListener('DOMContentLoaded', colorHandler);
function colorHandler() {
    var colors = document.querySelectorAll('.color');
    var colorId = document.getElementById('ColorId');
    colors.forEach((color) => {
        color.onclick = function () {
            colorId.value = color.id;
        }
    });
}

