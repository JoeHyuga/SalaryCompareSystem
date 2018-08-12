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
