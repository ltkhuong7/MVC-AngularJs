(function () {
    'use strict';

    angular.module('llGoogle')
        .controller('llSearchController', llSearchController);

    llSearchController.$inject = ['$rootScope', '$scope', 'moment', 'growl', 'llSearchService', 'llConstants', 'localStorageService'];

    function llSearchController($rootScope, $scope, moment, growl, llSearchService, llConstants, localStorageService) {
        var vm = this;
        //public methods
        vm.search = search;
        vm.reset = reset;
        vm.viewAllResults = viewAllResults;
        //variables
        vm.datetimeformat = 'dd MMM yyyy HH:mm:ss';
        vm.pageSize = 5;
        vm.currentPage = 1;
        vm.historyResults = [];
        vm.loading = false;
        vm.showHistory = false;
        vm.seList = llConstants.seList;
        vm.searchOption = {
            NoFirstResult: 100,
        };

        function search(searchOption)
        {
            vm.loading = true;
            vm.showHistory = false;
            vm.googleResult = null;
            llSearchService.search(searchOption).then(function (result) {
                vm.loading = false;
                vm.googleResult = result.data;
                if (vm.googleResult)
                {
                    vm.googleResult.DateSearch = moment(vm.googleResult.DateSearch).format();

                    vm.historyResults = localStorageService.get(llConstants.HIST_RESULT, llConstants.LOCAL_STORE);
                    if (angular.isArray(vm.historyResults)) {      //only get histories if they are valid
                        vm.googleResult.Id = vm.historyResults.length + 1;
                        vm.historyResults.push(vm.googleResult);
                    }
                    else {
                        vm.historyResults = [];
                        vm.googleResult.Id = 1;
                        vm.historyResults.push(vm.googleResult);
                    }

                    localStorageService.set(llConstants.HIST_RESULT, vm.historyResults, llConstants.LOCAL_STORE);
                }
                
            }).catch(function (result) {
                vm.loading = false;
                var message = "Error occur!"
                if (result.status === 404) {
                    message = llConstants.NOTFOUND_ERROR;
                }
                else if (result.status >= 500 && result.status < 600) {
                    message = llConstants.REQUEST_ERROR;
                }
                growl.error(message, { title: 'Error', ttl: llConstants.growlTTL });
            });
        }

        function reset()
        {
            vm.googleResult = null;
            vm.searchOption = {
                NoFirstResult: 100,
            };
            vm.showHistory = false;
        }

        function viewAllResults() {
            vm.showHistory = true;
            vm.historyResults = localStorageService.get(llConstants.HIST_RESULT, llConstants.LOCAL_STORE);
        }
    }

})();