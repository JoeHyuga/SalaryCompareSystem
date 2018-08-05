var app = angular.module('MyApp', ['ngRoute']);

app.controller('CompanyController', function ($scope, $route) { $scope.$route = $route; })
    .config(function ($routeProvider) {
        $routeProvider.
            when('/CompanyInfo', {
                templateUrl: 'companyInfo.html',
                controller: 'CompanyController'
            }).
            otherwise({
                redirectTo: '/CompanyInfo'
            });
    });
