angular.module('common.services').factory('TripsRepository', function ($http, $q) {
    var getTrips = function () {
        var deferred = $q.defer();
        return $http({
            method: 'GET',
            url: '/api/trips'
        }).success(function (data, status, headers, config) {
                deferred.resolve(data);
            }).error(function (data, status, headers, config) {
                deferred.reject(status);
            });
    }
  
    return {
        getTrips:getTrips
      
    }
});