app.controller('CompanyController', function ($scope, $http) {
    $scope.LoadDate = function () {
        $http({
            method: 'GET',
            url: '/api/CompanyInfo/GetCompanyInfo'
        }).then(function successCallback(response) {
            $scope.Infos = response.data.rows;
        }, function errorCallback(response) {

        });
    }
    $scope.LoadDate();

    $scope.Delete = function () {
        $.post('/api/CompanyInfo/DeleteCompanyInfo',
            {
                Ids: $scope.arryId.join(',')
            }, function (data) {
                if (data.success) {
                    alert("删除成功");
                }
                else {
                    alert('删除失败');
                }
                $scope.LoadDate();
            });
    }

    $scope.Update = function () { }

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