EConnect API Client
=========

* [API HELP] 


Example
--------------

```sh
var result = EConnect.Client.GetInboxDocuments(new GetInboxDocumentsOfAnUser() { Limit = 10 });
foreach (var doc in result.Documents)
{
    Console.WriteLine("Subject {0}", doc.Subject);
}
```

[API HELP]:http://help.everbinding.nl/content/api-application-programming-interface