app.controller('CompanyController', function ($scope, $http) {
    $http({
        method: 'GET',
        url: '/api/CompanyInfo/GetCompanyInfo'
    }).then(function successCallback(response) {
        $scope.Infos = response.data.rows;
    }, function errorCallback(response) {

    });

    $scope.Delete = function () {

    }

    $scope.Update = function () { }

    $scope.allck = false;
    $scope.SelectAll = function () {
        if ($scope.allck == false) {
            $scope.arryId.splice(0, $scope.arryId.length);//清空数组
            $('input[name="id"]').attr("checked", false);
        }
        else {
            
        }

        for (var i = 0; i < $scope.Infos.length; i++) {
            if ($scope.allck == true) {
                document.getElementById("ck" + i).checked = true;
                $scope.arryId.push($scope.Infos[i].Id);
            }
            else {
                document.getElementById("ck" + i).checked = false;
                $scope.arryId.splice($.inArray($scope.Infos[i].Id, $scope.arryId), 1);
            }
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