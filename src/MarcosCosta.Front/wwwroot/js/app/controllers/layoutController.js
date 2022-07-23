(function () {

    'use strict';

    angular.module('marcosCostaApp').controller('layoutController', layoutController);

    layoutController.$inject = ['$rootScope', 'layoutService'];

    function layoutController($rootScope, layoutService) {

        var vm = this;
        return vm;
    }

})();

