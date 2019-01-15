var app = angular.module('MyApp', ['ngRoute']);

app.controller('CompanyController', function ($scope, $route) { $scope.$route = $route; })
app.controller('CompanyEditController', function ($scope, $route) { $scope.$route = $route; })
app.controller('CompanyInfoDetailsController', function ($scope, $route) { $scope.$route = $route; })
app.controller('CompanyInfoDetailsEditController', function ($scope, $route) { $scope.$route = $route; })
app.controller('CompanyCompareController', function ($scope, $route) { $scope.$route = $route; })
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
        when('/companyInfoDetails', {
            templateUrl: 'companyInfoDetails.html',
            controller:'CompanyInfoDetailsController'
        }).
        when('/companyInfoDetailsEdit', {
            templateUrl: 'companyInfoDetailsEdit.html',
            controller: 'CompanyInfoDetailsEditController'
        }).
        when('/companyCompare', {
            templateUrl: 'companyCompare.html',
            controller: 'CompanyCompareController'
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