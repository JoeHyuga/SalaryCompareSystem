app.controller('CompanyInfoDetailsController', function ($scope, $http, pageValueFactory) {

    //获取详情数据
    $scope.GetDetails = function () {
        var Id = pageValueFactory.components.Id;
        //alert(Id);
        $http({
            method: 'GET',
            url: '/api/ComanyInfoDetails/GetDetails',
            //data: { Id: Id },
            params: { Id: Id }
        }).then(function success(response) {
            if (response.data.success) {
                $scope.Details = response.data.obj;
                $scope.Info = response.data.rows[0];
            }
            else {
                alert(response.data.message);
            }
            }, function errorCallback(response) {
                console.log(response)
        });
    }
    $scope.GetDetails();

    //显示地址详情
    $scope.AddressDetails = function (location) {
        
    }
})