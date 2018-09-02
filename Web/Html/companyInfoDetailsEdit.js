app.controller('companyInfoDetailsEdit', function ($scope, $http, pageValueFactory) {
    $scope.GetDetais = function () {
        var Id = pageValueFactory.components.Id;
        $scope.Id = Id;
        if (Id != undefined && Id != "") {
            $http({
                method: 'GET',
                url: '/api/ComanyInfoDetails/GetDetails',
                params: { Id: Id }
            }).then(function success(response) {
                if (response.data.success) {
                    $scope.bsalary = response.data.obj.BaseSalary;
                    $scope.salary = response.data.obj.Salary;
                    $scope.tel = response.data.obj.TelAllowance;
                    $scope.meal = response.data.obj.MealAllowance;
                    $scope.transport = response.data.obj.TransportAllowance;
                    $scope.housing = response.data.obj.HousingAllowance;
                    $scope.festival = response.data.obj.FestivalAllowance;
                    $scope.yearaward = response.data.obj.YearAward;
                    $scope.changetimes = response.data.obj.RaiseSalaryTimes;
                    $scope.$apply();
                }
                else {
                    alert(response.data.message);
                }
            }, function errorCallback(response) {
                console.log(response)
            });
        }
    }
    $scope.GetDetais();
});