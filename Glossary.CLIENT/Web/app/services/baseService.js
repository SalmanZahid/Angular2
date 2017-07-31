'use strict';
app.factory('baseService', ['$http', 'ngAppSettings', function ($http, ngAppSettings) {
    // GET API BASE URL FROM NG-APP SETTINGS
    var serviceBase = ngAppSettings.apiServiceBaseUri;
    var baseServiceFactory = {};

    baseServiceFactory.serviceBase = serviceBase;

    // INJECT THIS SERVICE TO GET LIST FROM ENDPOINT
    baseServiceFactory.getList = function (url, requestParams) {
        return $http({
            url: serviceBase + url,
            method: "GET",
            params: requestParams,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'
        }).then(function (results) {
            return results.data;
        })
    };

    // INJECT THIS SERVICE TO GET ELEMENT BY ID|ANY FROM ENDPOINT
    baseServiceFactory.get = function (url, value) {
        return $http({
            url: serviceBase + url + value,
            method: "GET",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'
        }).then(function (results) {
            return results.data;
        })
    };

    // INJECT THIS SERVICE TO POST FORM-DATA|ANY TO ENDPOINT
    baseServiceFactory.post = function (url, requestParams) {
        return $http({
            url: serviceBase + url,
            method: "POST",
            data: requestParams,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'
        }).then(function (results) {
            return results.data;
        }, function (error) {
            console.log(error);
        })
    };

    // INJECT THIS SERVICE TO UPDATE DATA BY PROVIDING FORM|ANY VALUES TO ENDPOINT
    baseServiceFactory.put = function (url,requestParams) {
        return $http({
            url: serviceBase + url,
            method: "PUT",
            params: requestParams,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'
        }).then(function (results) {
            return results.data;
        })
    };

    // INJECT THIS SERVICE TO DELETE DATA BY PROVIDING ID|ANY TO ENDPOINT
    baseServiceFactory.delete = function (url, value) {
        return $http({
            url: serviceBase + url + value,
            method: "DELETE",
            contentType: 'application/json; charset=utf-8'
        }).then(function (results) {
            return results.data;
        })
    };

    // RETURNS BASE SERVICE
    return baseServiceFactory;

}]);