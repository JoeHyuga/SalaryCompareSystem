app.controller('CompanyEditController', function ($scope, $http, pageValueFactory) {
    $scope.berror = false;
    $errormsg = "";
    $scope.GetCompanyInfo = function () {
        var Id = pageValueFactory.components.Id;
        $scope.Id = Id;
        if (Id != undefined && Id != "") {
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
                        layer.msg(data.message);
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
                address: $scope.address,
                xy: $scope.location
            }, function (data) {
                if (data.success) {
                    layer.msg("保存成功", function () {
                        window.location = '#home';
                    });
                }
                else {
                    layer.msg("保存失败");
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
                layer.msg(data.message);
            }
            if (!$scope.phase || !$scope.$root.phase) {
                $scope.$apply();
            }
        });
    }

    //获取地址的经纬坐标(经度，纬度)
    $scope.GetLocation = function (lng, lat, address) {
        $scope.location = lng + ";" + lat;
        $scope.address = address;
        $scope.AddressList = [];
        if (!$scope.phase || !$scope.$root.phase) {
            $scope.$apply();
        }
    }
});