app.controller('CompanyCompareController', function ($scope, $http) {
    $scope.LoadDate = function () {
        $http({
            method: 'GET',
            url: '/api/CompanyInfo/GetCompanyInfoes'
        }).then(function successCallback(response) {
            if (response.data.success) {
                $scope.Infos = response.data.rows;
            }
            else {
                alert(response.data.message);
            }
        }, function errorCallback(response) {

        });
    }
    $scope.LoadDate();

    $scope.arryId = [];
    $scope.Select = function (id) {
        var obj = document.getElementById("ck" + id);
        if (obj.checked) {
            $scope.arryId.push(id);
        }
        else {
            $scope.arryId.splice($.inArray(id, $scope.arryId), 1);
        }
    }

    //数据比较
    $scope.Compare = function (compareClass) {
        $.post('/api/CompanyCompare/CompanyCompare',
            {
                Ids: $scope.arryId.join(','),
                compareClass: compareClass
            }, function (data) {
                console.log(data);
                if (data.success) {
                    
                }
                else {
                    alert(data.message);
                }
                $scope.LoadDate();
            });
    }

    $scope.ChartData = function () {
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('salaryPie1'));

        app.configParameters = {
            rotate: {
                min: -90,
                max: 90
            },
            align: {
                options: {
                    left: 'left',
                    center: 'center',
                    right: 'right'
                }
            },
            verticalAlign: {
                options: {
                    top: 'top',
                    middle: 'middle',
                    bottom: 'bottom'
                }
            },
            distance: {
                min: 0,
                max: 100
            }
        };

        app.config = {
            rotate: 90,
            align: 'left',
            verticalAlign: 'middle',
            position: 'insideBottom',
            distance: 15,
            onChange: function () {
                var labelOption = {
                    normal: {
                        rotate: app.config.rotate,
                        align: app.config.align,
                        verticalAlign: app.config.verticalAlign,
                        position: app.config.position,
                        distance: app.config.distance
                    }
                };
                myChart.setOption({
                    series: [{
                        label: labelOption
                    }, {
                        label: labelOption
                    }, {
                        label: labelOption
                    }, {
                        label: labelOption
                    }]
                });
            }
        };


        var labelOption = {
            normal: {
                show: true,
                position: app.config.position,
                distance: app.config.distance,
                align: app.config.align,
                verticalAlign: app.config.verticalAlign,
                rotate: app.config.rotate,
                formatter: '{c}  {name|{a}}',
                fontSize: 16,
                rich: {
                    name: {
                        textBorderColor: '#fff'
                    }
                }
            }
        };

        var option = {
            color: ['#003366', '#006699', '#4cabce', '#e5323e'],
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    type: 'shadow'
                }
            },
            legend: {
                data: ['Forest', 'Steppe', 'Desert', 'Wetland']
            },
            toolbox: {
                show: true,
                orient: 'vertical',
                left: 'right',
                top: 'center',
                feature: {
                    mark: { show: true },
                    dataView: { show: true, readOnly: false },
                    magicType: { show: true, type: ['line', 'bar', 'stack', 'tiled'] },
                    restore: { show: true },
                    saveAsImage: { show: true }
                }
            },
            calculable: true,
            xAxis: [
                {
                    type: 'category',
                    axisTick: { show: false },
                    data: ['2012', '2013', '2014', '2015', '2016']
                }
            ],
            yAxis: [
                {
                    type: 'value'
                }
            ],
            series: [
                {
                    name: 'Forest',
                    type: 'bar',
                    barGap: 0,
                    data: [320, 332, 301, 334, 390]
                },
                {
                    name: 'Steppe',
                    type: 'bar',
                    barGap: 0,
                    data: [220, 182, 191, 234, 290]
                },
                {
                    name: 'Desert',
                    type: 'bar',
                    data: [150, 232, 201, 154, 190]
                },
                {
                    name: 'Wetland',
                    type: 'bar',
                    data: [98, 77, 101, 99, 40]
                }
            ]
        };

        myChart.setOption(option);
        $scope.charts.push(myChart);
    }

    $scope.ChartData();
});