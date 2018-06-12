function insert(item, user, request) {
    var message;

    //Invoke Azure Module
    var azure = require('azure');
    var tableService = azure.createTableService('{Your Storage account Name}',
    '{Your Storage account Key}');
    insertEntity();

    function insertEntity() {
        tableService.createTableIfNotExists('ShortMessages', function (error) {
            if (error) {
                message = 'Failed to access or create TodoItems table:\r\nerror=[' + error + ']';
                console.error(message);
                request.respond(statusCodes.BAD_REQUEST, message);
            }
            else {
                var entity = {
                    PartitionKey: 'default',
                    RowKey: (new Date()).getTime(),
                    Name: item.Name,
                    Message: item.Message,
                    IsRead: 'false'
                };

                tableService.insertEntity('ShortMessages', entity, function (error) {
                    if (error) {
                        message = 'Failed to insert message to table:\r\nerror=[' + error + ']';
                        console.error(message);
                        request.respond(statusCodes.BAD_REQUEST, message);
                    }
                    else {
                        console.log('successfully inserted for user');
                        request.respond(statusCodes.OK, entity);
                    }
                });
            }
        });
    }
}