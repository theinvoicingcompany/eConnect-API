EConnect API Client (Deprecated)
=========
This library makes it easier to connect to the EConnect platform.
This library is based on the old eVerbinding API V1. The API V1 is deprecated.

Platform API documentation:
* [API HELP] 

Installation using NuGET
-----------
Install-Package eConnectApi

Setup API client
--------------
Request the API credentiails on the [platform.everbinding.nl]
```sh
var client = new EConnectClient(new EConnectClientConfigBase()
{
    ConsumerKey = "[Replace with ConsumerKey]",
    ConsumerSecret = "[Replace with ConsumerSecret]",
    RequesterId = "[Replace with RequesterId]"
});
```

Example getting Inbox documents
--------------

```sh
try
{
    var result = client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() {Limit = 10});
    foreach (var doc in result.Documents)
    {
        Console.WriteLine("Subject {0}", doc.Subject);
    }
}
catch (EConnectClientException ex)
{
    // Log issues form econnect platform, network or library exceptions
    Console.WriteLine(ex.Message);
}
```

[API HELP]:https://development.everbinding.nl/article-categories/api-interface-reference/
[platform.everbinding.nl]:http://platform.everbinding.nl
