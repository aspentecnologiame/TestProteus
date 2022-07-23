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
                    name: 'title'
                },
                {
                    name: 'link',
                },
                {
                    name: 'description'
                },
                {
                    name: 'date',
                    displayName: 'date',
                    type: 'date',
                    cellFilter: 'date:"yyyy-MM-dd"'
                }
            ];
        }
    }

})();