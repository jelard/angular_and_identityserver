(function () {
    "use strict";
    angular
        .module("app")
        .controller("tripIndexController",
                     ["$filter", "TripsRepository",
                         TripIndexController]);

    function TripIndexController($filter, TripsRepository) {
        var vm = this;

     

        vm.switchPrivacyLevel = function (tripId)
        {         
            // create a JsonPatchDocument to change the privacy level,
            // and send it to the API through the tripResource.

            // get the trip to patch, using injected $filter dependency, and the built-in filter
            // named 'filter' (https://docs.angularjs.org/api/ng/filter) 
            
            var tripToPatch = $filter('filter')(vm.trips, { id: tripId }, true)[0];
         
            // only *really* switch the value after
            // the patch was succesful => success callback.
                        
            // patch the switched value
            tripToPatch.$patch(
                 {
                     tripId: tripId
                 },
                 // success
                    function (patchedTrip) {
                        debugger;
                        tripToPatch = patchedTrip;
                    },
                 // failure
                 null); 
 
        }

        vm.loadTrips = function() {
            TripsRepository.getTrips().then(function(response) {
                vm.trips = response.data;
            });
        };

   
        vm.loadTrips();
        

    }
}());
