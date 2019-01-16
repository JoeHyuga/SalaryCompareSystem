app.controller('CompanyCompareController', function ($scope, $http) {
    $scope.LoadDate = function () {
        $scope.charts = [];
        $http({
            method: 'GET',
            url: '/api/CompanyInfo/GetCompanyInfoes'
        }).then(function successCallback(response) {
            if (response.data.success) {
                $scope.Infos = response.data.rows;
            }
            else {
                layer.msg(response.data.message);
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
                    $scope.ChartData(data);
                }
                else {
                    layer.msg(data.message);
                }
                $scope.LoadDate();
            });
    }

    $scope.charts = [];
    $scope.ChartData = function (data) {
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('salaryPie1'));
        
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
        var barSeries = [];
        for (var i = 0; i < data.obj.series.length; i++) {
            var odata = {};
            odata.name = data.obj.series[i].name;
            odata.type = data.obj.series[i].type;
            odata.data = data.obj.series[i].data;
            odata.label = labelOption
            barSeries.push(odata);
        }
        var option = {
            title: {
                show: true,
                text: data.obj.title,
                textStyle: {
                    color: '#333'
                }
            },
            xAxis: {
                show: true,
                name: data.obj.xName,
                data: data.obj.xData
            },
            yAxis: {
                show: true,
                name: data.obj.yName,
                type:'value'
            },
            series: barSeries
            //    [
            //    {
            //        name: 'Forest',
            //        type: 'bar',
            //        label: labelOption,
            //        data: [320, 332, 301, 334]
            //    },
            //    {
            //        name: 'HT',
            //        type: 'bar',
            //        label: labelOption,
            //        data: [666, 56, 555, 55]
            //    },
            //    {
            //        name: 'Steppe',
            //        type: 'bar',
            //        label: labelOption,
            //        data: [120, 132, 101, 314]
            //    }
            //]
        }

        myChart.setOption(option);
        $scope.charts.push(myChart);
    }  
});