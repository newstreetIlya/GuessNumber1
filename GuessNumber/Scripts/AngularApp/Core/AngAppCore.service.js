angular
.module('AngAppCore')
.factory('AngAppCoreFactory', ['$http', function ($http) {
    return {
        StartGame: function (N) {
            return $http.get('Home/StartGame', { params: { N: N } });
        },
        Check: function (arr) {
            return $http.post('Home/Check',{ CheckNumber: arr });
        }
    }
}])