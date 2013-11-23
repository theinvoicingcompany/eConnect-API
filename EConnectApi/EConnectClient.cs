using System;
using EConnectApi.Definitions;

namespace EConnectApi
{
    public class EConnectClient : IDisposable
    {
        private readonly BaseClient _client;
 
        public EConnectClient(string requesterId)
        {
            _client = new BaseClient(requesterId);
        }

        public SendDocumentResponse SendDocument(SendDocument document)
        {
            return _client.SendRequest<SendDocumentResponse>("SEND_DOC", document);
        }


        public GetInboxDocumentsResponse GetInboxDocuments(GetInboxDocuments parameters)
        {
            return _client.SendRequest<GetInboxDocumentsResponse>("RETRIEVE_INBOX_DOCS", parameters);
        }



        // TODO implement rest of API

        public void Dispose()
        {
            // Clean up
            //_client.Close();
        }
    }
}
