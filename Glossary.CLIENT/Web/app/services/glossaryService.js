'use strict';
app.factory('glossaryService', ['baseService', function (baseService) {

    // HOLD GLOSSARY SERVICE FUNCTIONS
    var glossaryServiceFactory = {};

    // GET LIST OF TERMS FROM GLOSSARY
    glossaryServiceFactory.getList = function (request) {
        return baseService.getList('api/glossary/', request);
    };

    // GET TERM BY ID FROM GLOSSARY
    glossaryServiceFactory.get = function (id) {
        return baseService.get('api/glossary/', id);
    };

    // ADD NEW TERM IN GLOSSARY
    glossaryServiceFactory.add = function (entity) {
        return baseService.post('api/glossary', entity);
    };

    // EDIT TERM IN GLOSSARY
    glossaryServiceFactory.edit = function (entity) {
        return baseService.put('api/glossary', entity);
    };

    // DELETE FROM GLOSSARY
    glossaryServiceFactory.delete = function (id) {
        return baseService.delete('api/glossary/', id);
    };

    // RETURNS GLOSSARY SERVICE
    return glossaryServiceFactory;

}]);