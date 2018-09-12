app.controller('CompanyInfoDetailsController', function ($scope, $http, pageValueFactory) {
    //获取详情数据
    $scope.GetDetails = function () {
            $.post('/api/CompanyInfo/GetCompanyInfo',
                {
                    Id: $scope.CompanyId
                }, function (data) {
                    if (data.success) {
                        $scope.Info = data.obj;
                        $scope.$apply();
                    }
                    else {
                        alert(data.message);
                    }
                });
    }

    $scope.SalaryPie = function () {
        $http({
            method: 'GET',
            url: '/api/ComanyInfoDetails/GetDetails',
            params: { Id: $scope.CompanyId }
        }).then(function success(response) {
            if (response.data.success) {
                if (response.data.obj != null) {
                    // 基于准备好的dom，初始化echarts实例
                    var myChart = echarts.init(document.getElementById('salaryPie'));

                    // 指定图表的配置项和数据
                    var option = option = {
                        title: {
                            text: '工资组成部分',
                            subtext: '',
                            x: 'center'
                        },
                        tooltip: {
                            trigger: 'item',
                            formatter: "{a} <br/>{b} : {c} ({d}%)"
                        },
                        legend: {
                            orient: 'vertical',
                            left: 'left',
                            data: ['基本工资', '餐补', '交通补助', '住房补助', '节日补助', '话补', '年终奖']
                        },
                        series: [
                            {
                                name: '访问来源',
                                type: 'pie',
                                radius: '55%',
                                center: ['50%', '60%'],
                                data: [
                                    { value: response.data.obj.Salary, name: '基本工资' },
                                    { value: response.data.obj.MealAllowance, name: '餐补' },
                                    { value: response.data.obj.TransportAllowance, name: '交通补助' },
                                    { value: response.data.obj.HousingAllowance, name: '住房补助' },
                                    { value: response.data.obj.FestivalAllowance, name: '节日补助' },
                                    { value: response.data.obj.TelAllowance, name: '话补' },
                                    { value: response.data.obj.YearAward, name: '年终奖' }
                                ],
                                itemStyle: {
                                    emphasis: {
                                        shadowBlur: 10,
                                        shadowOffsetX: 0,
                                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                                    }
                                }
                            }
                        ]
                    };

                    // 使用刚指定的配置项和数据显示图表。
                    myChart.setOption(option);
                }
            }
            else {
                alert(response.data.message);
            }
        }, function errorCallback(response) {
            console.log(response)
        });
    }
    $scope.InitData = function () {
        var Id = pageValueFactory.components.Id;
        $scope.CompanyId = Id;
        if ($scope.CompanyId != undefined && $scope.CompanyId != "") {
            $scope.GetDetails();
            $scope.SalaryPie();
        }
    }
    $scope.InitData();
    //显示地址详情
    $scope.AddressDetails = function (location) {
        
    }
})