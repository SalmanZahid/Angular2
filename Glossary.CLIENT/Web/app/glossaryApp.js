var app = angular.module("GlossaryModule", ["ngRoute"]);

var serviceBaseURL = 'http://localhost:81/GlossaryWEBAPI/';

//Defining Routing
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/',
                        {
                            templateUrl: 'app/views/Glossary.html',
                            controller: 'glossaryController',
                            operation: "view"
                        });
    $routeProvider.when('/addglossaryterm',
                        {
                            templateUrl: 'app/views/CreateOrEditTerm.html',
                            controller: 'glossaryController',
                            operation: "new"
                        });
    $routeProvider.when("/editglossaryterm/:ID",
                        {
                            templateUrl: 'app/views/CreateOrEditTerm.html',
                            controller: 'glossaryController',
                            operation: "edit"
                        });
    $routeProvider.otherwise(
                        {
                            redirectTo: '/'
                        });
    $locationProvider.html5Mode(true)
}]);

// Evaluate operation to be made by controller
app.run(['$rootScope', '$location', function ($rootScope, $location) {
    $rootScope.$on('$routeChangeError', function (e, current, pre) {
        console.log('Unable to route');
    });

    $rootScope.$on('$routeChangeSuccess', function (e, current, pre) {
        if (current.$$route != undefined) {
            $rootScope.operation = current.$$route.operation;
        }

    });
}]);

// App constants
app.constant('ngAppSettings', {
    apiServiceBaseUri: serviceBaseURL
});

// Generic Error Handler
function handleError(error) {
    var errorMessage = { error: false, message: '', show: true };
    errorMessage = { message: 'Internal Error Please try later', error: true, show: true };
    if (error.status == 400) {
        errorMessage = { message: error.data.Message, show: true, error: true };
    }
    return errorMessage;
}