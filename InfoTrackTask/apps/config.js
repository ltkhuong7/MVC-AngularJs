(function () {
    'use strict';

    angular.module('ll')
        .config(['localStorageServiceProvider', function (localStorageServiceProvider) {
            localStorageServiceProvider.setPrefix('ll');
        }]);

    angular.module('ll')
        .config(['growlProvider', function (growlProvider) {
            growlProvider.globalDisableCountDown(true);
            growlProvider.onlyUniqueMessages(true);
        }]);

    angular.module('ll')
        .factory('moment', function () {
            return moment;
        });

})();