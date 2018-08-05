app.controller('CompanyController', function ($scope, $http) {
    $http({
        method: 'GET',
        url:'/api/CompanyInfo/GetCompanyInfo'
    }).then(function successCallback(response) {
        $scope.Infos = response.data.rows;
        }, function errorCallback(response) {

        });

    $scope.PostT = function () {
        $.post('/api/CompanyInfo/AddCompanyInfo', { name: "鼎永科技ng", description: "老东家ng" }, function (data) {
            console.log(data);
        });
    }
});
//$(function () {
//    $.ajax({
//        type: "POST",
//        url: "/api/CompanyInfo/GetCompanyInfo",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (data) {
//            var html = "<table>";
//            for (var i = 0; i < data.rows.length; i++){
//                html += "<tr><td>" + data.rows[i].CompanyName + "</td><td>" + data.rows[i].CompanyDescription +"</td></tr>";
//            }
//            html += "</table>";

//            $("#info").html(html);
//        },
//        error: function () { }
//    });
//})
//function addCompany() {
//    $.ajax({
//        type: "POST",
//        url: "/api/CompanyInfo/AddCompanyInfo",
//        data: JSON.stringify({ name: "鼎永科技", description: "老东家" }),
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (data) { },
//        error: function () { }
//    });
//}