document.addEventListener('DOMContentLoaded', colorHandler);
document.addEventListener('DOMContentLoaded', setDefaultColor);


function colorHandler() {
    var colors = document.querySelectorAll('.color');
    var colorId = document.getElementById('ColorId');
    colors.forEach((color) => {
        color.onclick = function () {
            setActiveColor(colors, this);
            colorId.value = color.id;
        }
    });
}

function setActiveColor(colors, currentColor) {
    colors.forEach((color) => {
        color.classList.remove('active-color');
    });
    currentColor.classList.add('active-color');
}

function setDefaultColor() {
    var colors = document.querySelectorAll('.color');
    var colorId = document.getElementById('ColorId');
    for (i = 0; i < colors.length; i++) {
        colors[i].classList.add('active-color');
        colorId.value = colors[i].id;
        break;
    }
}