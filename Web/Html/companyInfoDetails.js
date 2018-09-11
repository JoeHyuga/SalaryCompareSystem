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
        $.post('/api/ComanyInfoDetails/SalaryPie',
            {
                Id: $scope.CompanyId
            }, function (data) {
                if (data.success) {
                    console.log(data.rows[0]);
                    // Get the context of the canvas element we want to select
                    var ctx = document.getElementById("salaryPie").getContext("2d");
                    var myBarChart = new Chart(ctx, {
                        type: 'pie',
                        data: data.rows[0],
                        // options: options
                    });
                }
                else {
                    alert(data.message);
                }
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