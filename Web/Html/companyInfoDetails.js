app.controller('CompanyInfoDetailsController', function ($scope, $http, pageValueFactory) {

    //获取详情数据
    $scope.GetDetails = function () {
        var Id = pageValueFactory.components.Id;
        if (Id != undefined && Id != "") {
            $.post('/api/CompanyInfo/GetCompanyInfo',
                {
                    Id: Id
                }, function (data) {
                    console.log(data);
                    if (data.success) {
                        $scope.Info = data.obj;
                        $scope.$apply();
                    }
                    else {
                        alert(data.message);
                    }
                });
        }
    }
    $scope.GetDetails();

    //显示地址详情
    $scope.AddressDetails = function (location) {
        
    }
})