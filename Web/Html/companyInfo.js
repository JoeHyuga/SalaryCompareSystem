app.controller('CompanyController', function ($scope, $http, pageValueFactory) {
    $scope.LoadDate = function () {
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

    $scope.Delete = function () {
        if ($scope.arryId.length > 0) {
            var cf = confirm('是否删除');
            if (cf) {
                $.post('/api/CompanyInfo/DeleteCompanyInfo',
                    {
                        Ids: $scope.arryId.join(',')
                    }, function (data) {
                        if (data.success) {
                            alert("删除成功");
                        }
                        else {
                            alert(data.message);
                        }
                        $scope.LoadDate();
                    });
            }
        }
        
    }

    $scope.Update = function () {
        if ($scope.arryId.length>0) {
            var value = {};
            value['Id'] = $scope.arryId.join(',');
            $scope.$watch('components', function () {
                pageValueFactory.update(value);
            });

            window.location = '#companyInfoEdit';
        }
    }

    $scope.allck=false;
    $scope.SelectAll = function () {
        var cks = document.getElementsByName('ck');
        $scope.arryId.splice(0, $scope.arryId.length);

        for (var i = 0; i < cks.length; i++) {
            if (!$scope.allck) {
                $scope.arryId.push(cks[i].value);
            }
            else {
                $scope.arryId.splice(0, $scope.arryId.length);
            }
            cks[i].checked = !$scope.allck;
        }
    }

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
});