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

    $scope.charts = [];
    $scope.ChartData = function () {
        // 基于准备好的dom，初始化echarts实例
        var myChart = echarts.init(document.getElementById('salaryPie1'));

        myChart.setOption(option);
        $scope.charts.push(myChart);
    }
});