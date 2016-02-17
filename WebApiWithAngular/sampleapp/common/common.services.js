(function () {
    "use strict";

    angular.module("common.services",
                    [])
      	.constant("appSettings",
        {
            apiUrl: "https://localhost:44301/api" 
        });


    // oidc manager for dep injection
    angular.module("common.services")
        .factory("OidcManager", function () {

            // configure manager
            var config = {
            	client_id: "html",
                redirect_uri:  window.location.protocol + "//" + window.location.host + "/callback.html",
                response_type: "id_token token",
                scope: "openid profile roles gallerymanagement",               
                authority: "https://localhost:44300/identity",
                silent_redirect_uri: window.location.protocol + "//" + window.location.host + "/silentrefreshframe.html",
                silent_renew:true
            };
                    
            var mgr = new OidcTokenManager(config);
             
            return {
                OidcTokenManager: function () {
                    return mgr;
                } 
        };
    });


}());