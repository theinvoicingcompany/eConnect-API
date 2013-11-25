using System;
using EConnectApi.Definitions;

namespace EConnectApi
{
    public class EConnectClient : IDisposable
    {
        private readonly BaseClient _client;
 
        public EConnectClient(IEConnectClientConfig config)
        {
            _client = new BaseClient(config);
        }

        public SendDocumentResponse SendDocument(SendDocument document)
        {
            return _client.SendRequest<SendDocumentResponse>("SEND_DOC", document);
        }

        public GetInboxDocumentsResponse GetInboxDocuments(IInboxDocumentsRequest parameters)
        {
            return _client.SendRequest<GetInboxDocumentsResponse>("RETRIEVE_INBOX_DOCS", parameters);
        }

        public GetInboxDocumentResponse GetInboxDocument(IInboxDocumentRequest parameters)
        {
            return _client.SendRequest<GetInboxDocumentResponse>("RETRIEVE_INBOX_DOC", parameters);
        }

        public GetOutboxDocumentsResponse GetOutboxDocuments(IOutboxDocumentsRequest parameters)
        {
            return _client.SendRequest<GetOutboxDocumentsResponse>("RETRIEVE_OUTBOX_DOCS", parameters);
        }

        public GetOutboxDocumentResponse GetOutboxDocument(IOutboxDocumentRequest parameters)
        {
            return _client.SendRequest<GetOutboxDocumentResponse>("RETRIEVE_OUTBOX_DOC", parameters);
        }



        // TODO implement rest of API

        public void Dispose()
        {
            // Clean up
            //_client.Close();
        }
    }
}
