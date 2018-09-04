(function () {
    'use strict';

    angular
        .module('ll', [
            'llGoogle',
            'llConstants',
            'llServices',
            'angular-growl'
        ]);

    angular.module('llServices', ['LocalStorageModule']);
    angular.module('llConstants', []);
    angular.module('llDirectives', []);
    angular.module('llGoogle', ['angularUtils.directives.dirPagination']);

})();