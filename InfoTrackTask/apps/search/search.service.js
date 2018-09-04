(function () {
    'use strict';

    angular.module('llServices')
        .service('llSearchService', llSearchService);

    llSearchService.$inject = ['$http', 'llConstants'];

    function llSearchService($http, llConstants, localStorageService)
    {
        this.search = search;

        function search(searchOption) {
            return $http.get(llConstants.SEARCH_SERV + 'Search', { params: searchOption });
        };
    }
})();