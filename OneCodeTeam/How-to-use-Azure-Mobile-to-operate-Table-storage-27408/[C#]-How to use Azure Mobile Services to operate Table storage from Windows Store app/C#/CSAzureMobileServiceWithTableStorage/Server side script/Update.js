function update(item, user, request) {
    var azure = require('azure');
    var tableService = azure.createTableService('{Your Storage account Name}',
    '{Your Storage account Key}');
    updateEntity();

    function updateEntity() {
        tableService.updateEntity('ShortMessages', item, function (error) {
            if (error) {
                //this error shouldn't be reached in this project.
                console.log(error);
                request.respond(statusCodes.BAD_REQUEST, error);
            }
            else {
                console.log('Item successfully updated:\r\n', item);
                request.respond(statusCodes.OK, item);
            }
        });
    }
}