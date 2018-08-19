var app = angular.module('MyApp', ['ngRoute']);

app.controller('CompanyController', function ($scope, $route) { $scope.$route = $route; })
app.controller('CompanyEditController', function ($scope, $route) { $scope.$route = $route; })
app.config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);
app.config(function ($routeProvider) {
    $routeProvider.
        when('/companyInfo', {
            templateUrl: 'companyInfo.html',
            controller: 'CompanyController'
        }).
        when('/companyInfoEdit', {
            templateUrl: 'companyInfoEdit.html',
            controller: 'CompanyEditController'
        }).
        otherwise({
            redirectTo: '/companyInfo'
        });
});
app.factory('pageValueFactory', ['$rootScope', function ($rootScope) {
    var value = {};
    value.components = {};
    value.update = function (v) {
        this.components = angular.copy(v);
        $rootScope.$broadcast('pageValue');
    };

    return value;
}]);
//app.factory('valueFactory', function () {
//    var object = [];
//    var _setter = function (data) {
//        object.push(data);
//    };

//    var _getter = function () {
//        return object;
//    };

//    return {
//        setter: _setter,
//        getter: _getter
//    }
//});
