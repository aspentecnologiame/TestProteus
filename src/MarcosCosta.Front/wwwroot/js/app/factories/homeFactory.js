(function () {

    'use strict';

    angular.module('marcosCostaApp').factory('homeFactory', homeFactory);

    function homeFactory() {

        var factory = this;
        setProperties();
        return factory;

        function setProperties() {

            factory.ColumnDefs = [
                {
                    name: 'name'
                },
                {
                    name: 'company',
                },
                {
                    name: 'age',
                    type: 'number'
                },
                {
                    name: 'gender',
                    cellFilter: 'mapGender',
                    editDropdownValueLabel: 'gender',
                    editDropdownOptionsArray: [
                        { id: 0, gender: 'male' },
                        { id: 1, gender: 'female' },
                    ]
                },
                {
                    name: 'registered',
                    displayName: 'Registered',
                    type: 'date',
                    cellFilter: 'date:"yyyy-MM-dd"',
                    width: '20%'
                }
            ];
        }
    }

})();