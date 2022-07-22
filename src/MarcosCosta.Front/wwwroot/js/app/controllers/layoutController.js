(function () {

    'use strict';

    angular.module('marcosCostaApp').controller('layoutController', layoutController);

    layoutController.$inject = ['$rootScope', 'layoutService'];

    function layoutController($rootScope, layoutService) {

        var vm = this;
        validateToken();
        setProperties()

        return vm;

        function validateToken() {

            //layoutService.ValidateToken().then(function (response) {

            //}, function (error) {
            //    window.location.href = '../../';
            //});
        }

        function setProperties() {
            vm.Customer = true;
            vm.BaseUrl = global.BaseUrl;
            $rootScope.loader = false;
        }
    }

})();

