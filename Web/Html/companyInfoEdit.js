app.controller('CompanyEditController', function ($scope, $http, pageValueFactory) {
    $scope.GetCompanyInfo = function () {
        var Id = pageValueFactory.components.Id;
        $scope.Id = Id;
        if (Id != undefined&&Id!="") {
            $.post('/api/CompanyInfo/GetCompanyInfo',
                {
                    Id: Id
                }, function (data) {
                    console.log(data);
                    if (data.success) {
                        $scope.name = data.obj.CompanyName;
                        $scope.description = data.obj.CompanyDescription;
                        $scope.size = data.obj.CompanySize;
                        $scope.industry = data.obj.CompanyIndustry;
                        $scope.build = data.obj.CompanyBuildDate;
                        $scope.address = data.obj.CompanyAddress;
                        $scope.captial = data.obj.RegisteredCapital;
                        $scope.$apply();
                    }
                    else {
                        alert(data.message);
                    }
                });
            
        }
    }
    $scope.GetCompanyInfo();

    $scope.Save = function () {
        if ($scope.Id == undefined) {
            $scope.Id = '-1';
        }
        $.post('/api/CompanyInfo/AddCompanyInfo',
            {
                id: $scope.Id,
                name: $scope.name,
                description: $scope.description,
                size: $scope.size,
                industry: $scope.industry,
                build: $scope.build,
                captial: $scope.captial,
                address: $scope.address
            }, function (data) {
                if (data.success) {
                    alert("保存成功");
                    window.location = '#home';
                }
                else {
                    alert("保存失败");
                }
            });
    }

    $scope.SearchAddress = function () {
        $scope.AddressList = [];
        $.post('/api/CompanyInfo/SearchAddress', {
            keywords: $scope.address
        }, function (data) {
            if (data.success) {
                $scope.AddressList = data.rows;
            }
            else {
                alert(data.message);
            }
            if (!$scope.phase || !$scope.$root.phase) {
                $scope.$apply();
            }
        });
    }
});