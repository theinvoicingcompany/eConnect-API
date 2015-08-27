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

        /// <summary>
        /// Check EConnect connectiong with credentials
        /// </summary>
        public void Ping()
        {
            _client.GetRequestToken();
        }

        public SendDocumentResponse SendDocument(SendDocument document)
        {
            return _client.SendRequest<SendDocumentResponse>("SEND_DOC", document);
        }

        public SendDocumentForResponse SendDocumentFor(string senderId, SendDocumentFor document)
        {
            return _client.SendRequest<SendDocumentForResponse>("SEND_DOC_FOR", document, new SendDocumentForHeader()
            {
                SenderId = senderId
            });
        }

        public GetDocumentsResponse GetDocuments(IDocumentsRequest parameters)
        {
            return _client.SendRequest<GetDocumentsResponse>("RETRIEVE_DOCS", parameters);
        }

        public GetDocumentResponse GetDocument(GetDocument parameters)
        {
            return _client.SendRequest<GetDocumentResponse>("RETRIEVE_DOC", parameters);
        }

        public GetDocumentPdfResponse GetDocumentPdf(GetDocumentPdf parameters)
        {
            return _client.SendRequest<GetDocumentPdfResponse>("RETRIEVE_DOC", parameters);
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

        public SetDocumentStatusResponse SetDocumentStatus(SetDocumentStatus parameters)
        {
            return _client.SendRequest<SetDocumentStatusResponse>("SET_DOC_STATUS", parameters);
        }

        public SetInboxDocumentStatusResponse SetInboxDocumentStatus(SetInboxDocumentStatus parameters)
        {
            return _client.SendRequest<SetInboxDocumentStatusResponse>("SET_INBOX_DOC_STATUS", parameters);
        }

        public GetDocumentStatusResponse GetDocumentStatus(GetDocumentStatus parameters)
        {
            return _client.SendRequest<GetDocumentStatusResponse>("GET_DOC_STATUS", parameters);
        }

        public GetDocumentStatusResponse GetInboxDocumentStatus(GetInboxDocumentStatus parameters)
        {
            return _client.SendRequest<GetInboxDocumentStatusResponse>("GET_INBOX_DOC_STATUS", parameters);
        }

        public GetDocumentStatusResponse GetOutboxDocumentStatus(GetOutboxDocumentStatus parameters)
        {
            return _client.SendRequest<GetOutboxDocumentStatusResponse>("GET_OUTBOX_DOC_STATUS", parameters);
        }

        public EnquireCompanyResponse EnquireCompany(EnquireCompany parameters)
        {
            return _client.SendRequest<EnquireCompanyResponse>("ENQUIRE_COMPANY", parameters);
        }

        public SearchCompanyResponse SearchCompany(SearchCompany parameters)
        {
            return _client.SendRequest<SearchCompanyResponse>("SEARCH_COMPANY", parameters);
        }

        public RequestAppIntegrationResponse RequestAppIntegration(RequestAppIntegration parameters)
        {
            return _client.SendRequest<RequestAppIntegrationResponse>("APP_INTEGRATION", parameters);
        }

        public RequestIntegrationCredentialsResponse RequestIntegrationCredentials(RequestIntegrationCredentials parameters)
        {
            return _client.SendRequest<RequestIntegrationCredentialsResponse>("APP_INTEGRATION", parameters);
        }

        public bool HasAppIntergrationPermission()
        {
            try
            {
                var req = _client.GetRequestToken();
                var token = _client.GetAccessToken(req, "APP_INTEGRATION");
                return token != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Share documents & consignments to other users or groups
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public ShareDocumentResponse ShareDocument(ShareDocument parameters)
        {
            return _client.SendRequest<ShareDocumentResponse>("SHARE_DOC", parameters);
        }

        public void Dispose()
        {
            // Clean up
            _client.Dispose();
        }
    }
}
