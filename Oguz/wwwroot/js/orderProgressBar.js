document.addEventListener("DOMContentLoaded", createProgressBar);

function createProgressBarContainer() {
    var progressBarContainer = document.createElement('div');
    progressBarContainer.classList.add('container-fluid');
    progressBarContainer.classList.add('ProgressBarContainer');
    progressBarContainer.setAttribute('id', 'orderProgressBar');
    return progressBarContainer;
}

function setActiveToCurrentStep(stepName, stepBlock) {
    var currentStepName = document.getElementById('prgoressBarStep').value;
    if (stepName == currentStepName) {
        stepBlock.classList.add('active_step');
    }
}

function createProgressStep(stepNumber, stepName) {
    var progressStep = document.createElement('li');
    var stepInner = document.createElement('div');
    stepInner.classList.add('progressBar_step');
    stepInner.innerText = +stepNumber + 1;
    var stepInnerName = document.createElement('span');
    stepInnerName.classList.add('progressBar_step-text');
    stepInnerName.innerText = stepName;
    setActiveToCurrentStep(stepName, stepInner);
    progressStep.insertAdjacentElement('beforeend', stepInner);
    progressStep.insertAdjacentElement('beforeend', stepInnerName);
    return progressStep;
}

function createThroughStepsLine() {
    var throughStepsLine = document.createElement('span');
    throughStepsLine.classList.add('progressLine');
    return throughStepsLine;
}

function createProgressBarList() {
    var stepsNames = ['Стиль', 'Ткань', 'Цвет', 'Размер', 'Завершение'];
    var ulClasses = ['progressBar_container', 'container'];

    var progressBar = document.createElement('ul');
    for (var i = 0; i < ulClasses.length; i++) {
        progressBar.classList.add(ulClasses[i]);
    }
    for (var j = 0; j < stepsNames.length; j++) {
        var step = createProgressStep(j, stepsNames[j]);
        progressBar.insertAdjacentElement('beforeend', step);
    }
    return progressBar;

}

function createProgressBar() {
    var progressBarElement = document.getElementById('progressBar');
    var progressBarContainer = createProgressBarContainer();
    var progressBar = createProgressBarList();
    progressBar.firstChild.insertAdjacentElement('afterEnd', createThroughStepsLine());
    progressBarContainer.insertAdjacentElement('beforeend', progressBar);
    progressBarElement.insertAdjacentElement('beforeend', progressBarContainer);
}