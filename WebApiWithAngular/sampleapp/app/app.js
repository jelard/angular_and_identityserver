(function() {

    var app = angular.module("app", ["ngRoute","common.services"]);

    app.config(function ($routeProvider,$httpProvider) {

        $routeProvider
            .when("/trips", {
                templateUrl: "/sampleapp/app/trips/tripIndex.html",
                controller: "tripIndexController as vm"
            })
           .otherwise({ redirectTo: "/trips" });

        $httpProvider.interceptors.push(function (OidcManager) {
            return {
                'request': function (config) {

                    if (OidcManager.OidcTokenManager().expired) {
                        OidcManager.OidcTokenManager().redirectForToken();
                    }
                    // if it's a request to the API, we need to provide the
                    // access token as bearer token.             
                    if (config.url.indexOf("/api") === 0) {
                        config.headers.Authorization = 'Bearer ' + OidcManager.OidcTokenManager().access_token;
                    }

                    return config;
                }

            };
        });


    });

})();