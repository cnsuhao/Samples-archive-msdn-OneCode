function del(id, user, request) {
    //Access table service
    var azure = require('azure');
    var tableService = azure.createTableService('{Your Storage account Name}',
    '{Your Storage account Key}');
    deleteItem();
    function deleteItem() {
        tableService.deleteEntity('ShortMessages',
                                  {
                                      PartitionKey: 'default',
                                      RowKey: id
                                  },
                                  function (error) {
                                      if (error) {
                                          var message = 'Failed to delete item:\r\nerror=' + error;
                                          console.error(message);
                                          request.respond(statusCodes.BAD_REQUEST, message);
                                      }
                                      else {
                                          console.log('Item successfully deleted');
                                          request.respond(statusCodes.OK, id);
                                      }
                                  });
    }
}