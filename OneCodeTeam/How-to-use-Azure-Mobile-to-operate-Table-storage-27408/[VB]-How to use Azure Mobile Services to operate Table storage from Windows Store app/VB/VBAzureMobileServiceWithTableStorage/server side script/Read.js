function read(query, user, request) {
    var message;
    var azure = require('azure');
    var tableService = azure.createTableService('{Your Storage account Name}',
    '{Your Storage account Key}');

    var tableQuery = azure.TableQuery
    .select()
    .from('ShortMessages')
    .where('IsRead eq?', "false");

    tableService.createTableIfNotExists('ShortMessages', function (error) {
        if (error) {
            message = 'Failed to access or create TodoItems table:\r\nerror=[' + error + ']';
            console.error(message);
            request.respond(statusCodes.BAD_REQUEST, message);
        }
        else {
            queryEntities();
        }
    });

    function queryEntities() {
        tableService.queryEntities(tableQuery, function (error, entities) {
            if (error) {
                var message = 'Failed to retrieve entities from ShortMessages: error=' + error;
                console.log(message);
                request.respond(statusCodes.BAD_REQUEST, message);
            }
            else {

                for (var i = 0; i < entities.length; i++) {
                    entities[i].id = parseInt(entities[i].Rowkey, 0);
                }
                request.respond(statusCodes.OK, entities);
            }
        });
    }
}