$.ajax({
    url: '/api/ChartApi',
    type: 'GET',
    data: { chartName: 'FirstAbsencesChart' },
    success: function (chartData) {
        $(document).ready(function () {
            var chartId1 = document.getElementById('Chart1');
            var chart1 = new Chart(chartId1, {
                type: 'horizontalBar',
                data: {
                    labels: chartData.dataLabels,
                    datasets: [{
                        label: chartData.datasetsLabels[0],
                        backgroundColor: '#20c964',
                        borderColor: '#20c964',
                        data: [20, 15, 21]
                    }]
                },
                options: {
                    scales: {
                        xAxes: [{
                            ticks: {
                                beginAtZero: true,
                                stepSize: 2
                            }
                        }]
                    },
                    legend: {
                        position: 'right',
                        align: 'start'
                    }
                }
            });
        });
    }
});

$.ajax({
    url: '/api/ChartApi',
    type: 'GET',
    data: { chartName: 'SecondAbsencesChart' },
    success: function (chartData) {
        $(document).ready(function () {
            var chartId2 = document.getElementById('Chart2');
            var chart2 = new Chart(chartId2, {
                type: 'bar',
                data: {
                    labels: chartData.dataLabels,
                    datasets: [{
                        label: chartData.datasetsLabels[0],
                        backgroundColor: '#20c964',
                        borderColor: '#20c964',
                        data: [3, 2, 0, 1, 2, 0, 5, 2, 0, 1, 7, 5]
                    }]
                },
                options: {

                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                                stepSize: 2
                            }
                        }]
                    },
                }
            });
        });
    }
});

$.ajax({
    url: '/api/ChartApi',
    type: 'GET',
    data: { chartName: 'ThirdAbsencesChart' },
    success: function (chartData) {
        $(document).ready(function () {
            var chartId3 = document.getElementById('Chart3');
            var chart3 = new Chart(chartId3, {
                type: 'bar',
                data: {
                    labels: chartData.dataLabels,
                    datasets: [{
                        label: chartData.datasetsLabels[0],
                        backgroundColor: '#9575cd',
                        borderColor: '#9575cd',
                        data: [21, 22, 24, 25, 25, 25, 25, 25, 25, 25, 25, 25]
                    }]
                },
                options: {

                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true,
                                stepSize: 2
                            }
                        }]
                    },
                }
            });
        });
    }
});

$.ajax({
    url: '/api/ChartApi',
    type: 'GET',
    data: { chartName: 'FourthAbsencesChart' },
    success: function (chartData) {
        $(document).ready(function () {
            var chartId4 = document.getElementById('Chart4');
            var chart4 = new Chart(chartId4, {
                type: 'pie',
                data: {
                    labels: chartData.dataLabels,
                    datasets: [{
                        label: chartData.datasetsLabels[0],
                        backgroundColor: ['#B3219D ', '#FF5733 ', '#EFEE1A ', '#18FF00  ', '#003CFF  ', '#FF005C  '],
                        data: [18, 3, 1, 16, 25, 86]
                    }]
                },
            });
        });
    }
});



