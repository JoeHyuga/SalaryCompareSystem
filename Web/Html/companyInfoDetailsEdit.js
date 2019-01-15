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
                    if (response.data.obj != null) {
                        $scope.bsalary = response.data.obj.BaseSalary;
                        $scope.salary = response.data.obj.Salary;
                        $scope.tel = response.data.obj.TelAllowance;
                        $scope.meal = response.data.obj.MealAllowance;
                        $scope.transport = response.data.obj.TransportAllowance;
                        $scope.housing = response.data.obj.HousingAllowance;
                        $scope.festival = response.data.obj.FestivalAllowance;
                        $scope.yearaward = response.data.obj.YearAward;
                        $scope.changetimes = response.data.obj.RaiseSalaryTimes;
                    }
                }
                else {
                    layer.msg(response.data.message);
                }
            }, function errorCallback(response) {
                console.log(response)
            });
        }
    }
    $scope.GetDetais();

    $scope.Save = function () {
        $.post('/api/ComanyInfoDetails/CompanyInfoDetailsEdit',
            {
                Id: $scope.Id,
                bsalary: $scope.bsalary,
                salary: $scope.salary,
                meal: $scope.meal,
                tel: $scope.tel,
                transport: $scope.transport,
                housing: $scope.housing,
                festival: $scope.festival,
                yearaward: $scope.yearaward,
                changetimes: $scope.changetimes
            }, function (data) {
                if (data.success) {
                    layer.msg('保存成功', function () {
                        window.location = '#home';
                    })
                    
                }
                else {
                    layer.msg(data.message);
                }
            }
        );
    }
});