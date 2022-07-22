(function () {

    'use strict';

    angular.module('marcosCostaApp').service('layoutService', layoutService);

    layoutService.$inject = ['$http', '$q'];

    function layoutService($http, $q) {

        var service = this;
        setFunctions();
        return service;

        function setFunctions() {
            service.ValidateToken = validateToken;
        }

        function validateToken() {

            var deferred = $q.defer();

            var url = 'identity/authorization';
            var verb = 'POST';

            var request = global.CreateRequest(url, verb, null);

            $http(request)
                .then(validateTokenSuccess)
                .catch(validateTokenFailed);

            function validateTokenSuccess(response) {
                deferred.resolve(response.data);
            }

            function validateTokenFailed(error) {
                deferred.reject(error.data);
            }

            return deferred.promise;
        }
    }

})();