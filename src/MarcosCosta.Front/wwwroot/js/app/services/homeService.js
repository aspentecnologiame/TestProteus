(function () {

    'use strict';

    angular.module('marcosCostaApp').service('homeService', homeService);

    homeService.$inject = ['$http', '$q'];

    function homeService($http, $q) {

        var service = this;
        setFunctions();
        return service;

        function setFunctions() {
            service.GetGridInfos = getGridInfos;
            service.GetFeeds = getFeeds;
        }

        function getGridInfos() {

            var deferred = $q.defer();

            var url = '/js/app/data/uiGridInfo.json';
            var verb = 'GET';

            var request = global.CreateRequest(url, verb);

            $http({ url: url, method: verb })
                .then(gridInfosSuccess)
                .catch(gridInfosFailed);

            function gridInfosSuccess(response) {
                deferred.resolve(response.data);
            }

            function gridInfosFailed(error) {
                deferred.reject(error.data);
            }

            return deferred.promise;
        }

        function getFeeds() {

            var deferred = $q.defer();

            var url = 'feed-rdf/feeds';
            var verb = 'GET';

            var request = global.CreateRequest(url, verb);

            $http(request)
                .then(feedSuccess)
                .catch(feedFailed);

            function feedSuccess(response) {
                deferred.resolve(response);
            }

            function feedFailed(error) {
                deferred.reject(error.data);
            }

            return deferred.promise;
        }
    }

})();