var accountName='storage account name';
var accountKey='storage account key';
var azure=require('azure');
var qs=require('querystring');
var containerName='generateazuretablesas';
var sas;


exports.get = function(request, response) {
    var host = accountName + '.blob.core.windows.net'; 
    var blobService = azure.createBlobService(accountName, accountKey, host); 

    blobService.createContainerIfNotExists(containerName, {publicAccessLevel : 'blob'}, function(error){
    if(!error){
    // Container exists now define a policy that provides write access
    // that starts immediately and expires in 5 mins
    var sharedAccessPolicy = {
    AccessPolicy:{
    Permissions: 'rwdl',//rwdl means read write delete list
   
    //Start: //use for start time in future, beware of server time skew
    Expiry: formatDate(new Date(new Date().getTime() + 30 * 60 * 1000)) //30 minutes from now
    }
    
    };
    //Generate the SAS for your BLOB
    var sasQueryString = getSAS(accountName,
    accountKey,
    containerName,
    azure.Constants.BlobConstants.ResourceTypes.CONTAINER,
    sharedAccessPolicy);
    //full path for resource with sas
    sas = '?' + sasQueryString;
    response.send(statusCodes.OK, { sas : sas });
    }
    else{
    console.error(error);
    response.send(statusCodes.ERROR);
    }
    });
        function getSAS(accountName, accountKey, path, resourceType, sharedAccessPolicy) {
        return qs.encode(new azure.SharedAccessSignature(accountName, accountKey)
        .generateSignedQueryString(path, {}, resourceType, sharedAccessPolicy));
        }
         
        function formatDate(date){
        var raw = date.toJSON();
        //blob service does not like milliseconds on the end of the time so strip
        return raw.substr(0, raw.lastIndexOf('.')) + 'Z';
        }   
};