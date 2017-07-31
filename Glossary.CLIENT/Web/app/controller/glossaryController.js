app.controller('glossaryController', ['$scope', '$route', '$routeParams', '$location', 'glossaryService',
    function ($scope, $route, $routeParams, $location, glossaryService) {
        $scope.termId = undefined;

        if ($routeParams.ID != undefined) {
            $scope.termId = $routeParams.ID;
        }

        // GLOSSARY TERM MODEL
        $scope.glossaryTerm = {};
        // TERM LIST
        $scope.glossaryTermList = {};
        // SEARCH TEXT
        $scope.searchText = '';

        // ALERT MESSAGE HANDLER
        $scope.messageHandler = {
            error: false,
            message: '',
            show: false
        };

        // NAVIGATE TO EDIT
        $scope.navigateEdit = function (id) {
            $location.path("/editglossaryterm/" + id);
        }

        // ADD NEW TERM  
        $scope.Add = function () {
            $('#add').button('loading');
            if (IsFormValid()) {
                glossaryService.add($scope.glossaryTerm).then(
               function (response) {
                   $scope.glossaryTerm = {};
                   $scope.messageHandler = { error: false, message: 'Successfully added in system.', show: true };
                   setTimeout(function () {
                                             
                                       
                   }, 3000);
               }, function (error) {
                   return $scope.messageHandler = error;
               });
            }
            $('#add').button('reset');
        }

        // UPDATE TERM
        $scope.Edit = function () {
            $('#edit').button('loading');
            if (IsFormValid()) {
                glossaryService.edit($scope.glossaryTerm).then(function (response) {
                    $scope.messageHandler = { error: false, message: 'Successfully updated in system.', show: true };
                }
              , function (error) {
                  return $scope.messageHandler = handleError(error);
              });
            }
            $('#edit').button('reset');
        }

        // DELETE TERM
        $scope.Delete = function (id, index) {
            if (confirm("Are you sure you want to delete this ?")) {
                glossaryService.delete(id)
                        .then(
                            function (response) {
                                $scope.glossaryTermList.splice(index, 1);
                                SnackBar();
                            }
                            , function (error) { return $scope.messageHandler = handleError(error); }
                        );
            }
        }

        // SEARCH TERMS
        $scope.search = function (item) {
            if ($scope.searchText == undefined) {
                return true;
            } else {
                if (item.term.toLowerCase().indexOf($scope.searchText.toLowerCase()) != -1 || item.definition.toLowerCase().indexOf($scope.searchText.toLowerCase()) != -1) {
                    return true;
                }
            }
            return false;
        };

        // VALIDATE FORM 
        var IsFormValid = function () {
            $scope.messageHandler = { error: false, message: '', show: false };
            var formValid = true;

            if (($scope.glossaryTerm.term == undefined) || ($scope.glossaryTerm.term.length <= 0)) {
                $scope.messageHandler = { error: true, message: 'Please enter term', show: true };
                formValid = false;
            } else if ($scope.glossaryTerm.term.length > 50) {
                $scope.messageHandler = { error: true, message: 'Term should not be more than 50 characters', show: true };
                formValid = false;
            }

            if (($scope.glossaryTerm.definition == undefined) || ($scope.glossaryTerm.definition.length <= 0)) {
                $scope.messageHandler = { error: true, message: 'Please enter definition', show: true };
                formValid = false;
            } else if ($scope.glossaryTerm.definition.length > 250) {
                formValid = false;
                $scope.messageHandler = { error: true, message: 'Definition should not be more than 250 characters', show: true };
            }

            return formValid;
        }

        // INITIALIZE LIST PAGE 
        $scope.Init = function () {
            glossaryService.getList(null).then(function (response) {
                if (response.status == 1) {
                    $scope.glossaryTermList = response.data;
                }
            });
        }

        // FILL GLOSSARY TERM MODEL FOR EDIT
        $scope.InitEdit = function () {
            glossaryService.get($scope.termId).then(function (response) {
                if (response.status == 1) {
                    $scope.glossaryTerm = response.entity;
                }
            });
        }

        // PERFORM ACTION ACCORDING TO PROVIDED OPERATION
        if ($scope.operation == "view") {
            $scope.Init();
        } else if ($scope.operation == "edit") {
            $scope.InitEdit();
        }

    }])