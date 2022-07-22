(function () {

    'use strict';

    const app = angular.module("marcosCostaApp", ["ngRoute", "ui.grid", "ui.grid.pagination"]);

    app.config(['$routeProvider', '$locationProvider',
        function ($routeProvider, $locationProvider) {
            $locationProvider.hashPrefix('');
            $routeProvider
                .when("/", {
                    templateUrl: global.BaseUrl + 'js/app/views/home.html',
                })
                .when("/home", {
                    templateUrl: global.BaseUrl + 'js/app/views/home.html',
                })
                .when("/list", {
                    templateUrl: global.BaseUrl + 'js/app/views/list.html',
                });
            $locationProvider.html5Mode(true);
        }])
        .config(function ($provide) {

            $provide.decorator("$exceptionHandler", function () {
                return function (exception, cause) {
                    var errString = exception + ' - stack: ' + exception.stack + ' - cause: ' + cause;
                };
            });
        })
        .run(['$rootScope', function ($rootScope) {
            $rootScope.$on("$routeChangeSuccess", function (userInfo) {
                //console.log(userInfo);
            });
        }]);

}).call(this);
