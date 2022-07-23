(function () {

    'use strict';

    angular.module('marcosCostaApp').controller('homeController', layoutController);

    layoutController.$inject = ['$rootScope', 'homeService', 'homeFactory'];

    function layoutController($rootScope, homeService, homeFactory) {

        var vm = this;
        startGrid()

        return vm;

        function startGrid() {

            vm.gridOptions = {
                multiSelect: true,
                enableFiltering: false,
                enableFullRowSelection: true,
                enableRowSelection: true,
                multiSelect: false,
                paginationPageSizes: [50, 100],
                paginationPageSize: 50,
                columnDefs: homeFactory.ColumnDefs
            };

            vm.gridOptions.onRegisterApi = function (gridApi) {
                vm.gridApi = gridApi;
            };

            homeService.GetFeeds().then(function (response) {

                var data = response.data;
                vm.gridOptions.data = data.items;
                vm.channel = data.channel;

            }, function (error) {
                console.log(error);
            });
        }
    }

})();

