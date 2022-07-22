(function () {

    'use strict';

    angular.module('marcosCostaApp').controller('homeController', layoutController);

    angular.module('marcosCostaApp').filter('mapGender', function () {
        return function (input) {
            if (input === null || input === undefined) {
                return new Object();
            } else {
                return input.gender;
            }
        };
    })

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

            homeService.GetGridInfos().then(function (response) {

                var data = response.Data;
                vm.gridOptions.data = data;
                for (var i = 0; i < data.length; i++)
                    data[i].gender = data[i].gender === 'male' ? { id: 0, gender: 'male' } : { id: 1, gender: 'female' };

            }, function (error) {
                console.log(error);
            });
        }
    }

})();

