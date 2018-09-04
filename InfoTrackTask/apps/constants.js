(function () {
    'use strict';

    angular.module('ll')
        .constant('llConstants', {
            'SEARCH_SERV': '/home/',
            'HIST_RESULT': 'hist',
            'LOCAL_STORE': 'localStorage',
            'SESSION_STORE': 'sessionStorage',
            'seList': [
                { text: "Google", value: 1 },
            ],
            'growlTTL': 10000,
            'NOTFOUND_ERROR': 'Your requested resource could not be found or invalid! please try again later.',
            'REQUEST_ERROR': 'Unable to complete request at this time! please try again later. If problem persist contact administrator!',
        });

})();