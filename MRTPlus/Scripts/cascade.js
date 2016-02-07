var app = angular.module('myModule', []);
app.controller('myController', function ($scope, $http) {

    GetReviewTypes();
    function GetReviewTypes() {
        $http({
            method: 'Get',
            url: '/ReviewData/GetReviewTypes'
        }).success(function (data, status, headers, config) {
            $scope.reviewtypes = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    }

    $scope.GetReviewCategories = function () {
        var reviewtypeId = $scope.reviewtype;
        if (reviewtypeId) {
            $http({
                method: 'POST',
                url: '/ReviewData/GetReviewCategories/',
                data: JSON.stringify({ reviewtypeId: reviewtypeId })
            }).success(function (data, status, headers, config) {
                $scope.reviewcategories = data;
            }).error(function (data, status, headers, config) {
                $scope.message = 'Unexpected Error';
            });
        }
        else {
            $scope.reviewcategories = null;
        }
    }
    $scope.GetReviewElements = function () {
        var reviewcategoryId = $scope.reviewcategory;
        if (reviewcategoryId) {
            $http({
                method: 'POST',
                url: '/ReviewData/GetReviewElements/',
                data: JSON.stringify({ reviewcategoryId: reviewcategoryId })
            }).success(function (data, status, headers, config) {
                $scope.reviewelements = data;
            }).error(function (data, status, headers, config) {
                $scope.message = 'Unexpected Error';
            });
        }
        else {
            $scope.reviewelements = null;
        }
    }
});