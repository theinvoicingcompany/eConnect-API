using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Xml.Linq;
using EConnectApi.Definitions;
using EConnectApi.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiUnitTests
{
    [TestClass]
    public class SoapSerializerAndDeseiralizerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var xml = 
            @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
    <soapenv:Body>
        <soapenv:Fault>
            <faultcode>{http://schemas.xmlsoap.org/soap/envelope/}Server</faultcode>
            <faultstring>Ontbrekende informatie! Neem de API documentatie door en controleer of alle vereiste informatie in het verzoek aanwezig is.</faultstring>
             <detail>com.vg.pw.exceptions.DocExException
	at com.vg.pw.services.external.EnquireCompanyHandler.checkForAvailability(EnquireCompanyHandler.java:121)
	at com.vg.pw.services.external.EnquireCompanyHandler.handleRequest(EnquireCompanyHandler.java:82)
	at com.vg.pw.services.external.SearchCompanyHandler.enquireCompanyUsingGraydonId(SearchCompanyHandler.java:176)
	at com.vg.pw.services.external.SearchCompanyHandler.getPWResponseForGraydonResponse(SearchCompanyHandler.java:116)
	at com.vg.pw.services.external.SearchCompanyHandler.handleRequest(SearchCompanyHandler.java:56)
	at com.vg.pw.service.ServiceManager.process(ServiceManager.java:43)
	at com.vg.pw.gateway.svprovider.pw.PWServiceProvider.processXMLRequest(PWServiceProvider.java:186)
	at com.vg.pw.gateway.svprovider.pw.PWServiceProvider.serveRequest(PWServiceProvider.java:116)
	at com.vg.pw.gateway.svprovider.oauth.OAuthServiceProvider.serveResourceAccessRequest(OAuthServiceProvider.java:315)
	at com.vg.pw.gateway.svprovider.oauth.OAuthServiceProvider.serveRequest(OAuthServiceProvider.java:356)
	at com.vg.pw.gateway.PartnerWorldGateway.doPost(PartnerWorldGateway.java:143)
	at javax.servlet.http.HttpServlet.service(HttpServlet.java:647)
	at javax.servlet.http.HttpServlet.service(HttpServlet.java:728)
	at org.apache.catalina.core.ApplicationFilterChain.internalDoFilter(ApplicationFilterChain.java:305)
	at org.apache.catalina.core.ApplicationFilterChain.doFilter(ApplicationFilterChain.java:210)
	at org.apache.catalina.core.StandardWrapperValve.invoke(StandardWrapperValve.java:222)
	at org.apache.catalina.core.StandardContextValve.invoke(StandardContextValve.java:123)
	at org.apache.catalina.authenticator.AuthenticatorBase.invoke(AuthenticatorBase.java:472)
	at org.apache.catalina.core.StandardHostValve.invoke(StandardHostValve.java:171)
	at org.apache.catalina.valves.ErrorReportValve.invoke(ErrorReportValve.java:99)
	at org.apache.catalina.valves.AccessLogValve.invoke(AccessLogValve.java:953)
	at org.apache.catalina.core.StandardEngineValve.invoke(StandardEngineValve.java:118)
	at org.apache.catalina.connector.CoyoteAdapter.service(CoyoteAdapter.java:408)
	at org.apache.coyote.http11.AbstractHttp11Processor.process(AbstractHttp11Processor.java:1008)
	at org.apache.coyote.AbstractProtocol$AbstractConnectionHandler.process(AbstractProtocol.java:589)
	at org.apache.tomcat.util.net.JIoEndpoint$SocketProcessor.run(JIoEndpoint.java:310)
	at java.util.concurrent.ThreadPoolExecutor.runWorker(ThreadPoolExecutor.java:1145)
	at java.util.concurrent.ThreadPoolExecutor$Worker.run(ThreadPoolExecutor.java:615)
	at java.lang.Thread.run(Thread.java:722)
</detail>
        </soapenv:Fault>
    </soapenv:Body>
</soapenv:Envelope>";

            var obj = GenericXml.DeserializeSoap<SoapFault>(xml);
        }

        [TestMethod]
        public void TestSoapEnvelop()
        {
            var soap = @"<SOAP:Envelope xmlns:SOAP=""http://schemas.xmlsoap.org/soap/envelope/""><SOAP:Header/><SOAP:Body>
<GetInboxDocumentsResponse><tuple><rowkey>CUA000000191000001INCC9223370645588146187UA000000191000001</rowkey><SenderAccountId>A000000191</SenderAccountId><SenderAccountName>selmit.nl</SenderAccountName><CreatedDateTime>1391266631316</CreatedDateTime><ConsignmentId>CUA000000191000001INCC9223370645588146187UA000000191000001</ConsignmentId><ConsignmentName>Afas test factuur c1f45965-5749-4951-9eba-a0af08852e6b</ConsignmentName><DocumentId>RA000000191DMP2000014</DocumentId><ExternalId>XCNIN10637</ExternalId><IsRead>false</IsRead><IsTask>0</IsTask><LatestStatusCode>10</LatestStatusCode><LatestStatusInfo>UA000000191000001:Thieme:A000000191:selmit.nl:1391266630248</LatestStatusInfo><LatestStatus>Afgeleverd:UA000000191000001:Thieme:A000000191:selmit.nl:1391266630245</LatestStatus><MasterTemplateId>RA000000006DTP2000001</MasterTemplateId><MasterTemplateName>SimplerInvoicing Factuur - UBL2.0 Standard</MasterTemplateName><Subject>Afas test factuur c1f45965-5749-4951-9eba-a0af08852e6b</Subject><StandardTemplateId>GLDT9223370666504283001RA000000006DTP2000001</StandardTemplateId><StandardTemplateName>SimplerInvoicing Factuur - UBL2.0 Standard</StandardTemplateName><DocumentTemplateId>GLDT9223370666504283001RA000000006DTP2000001</DocumentTemplateId><TrackingMessage>EM0001</TrackingMessage><DocumentTemplateName>SimplerInvoicing Factuur - UBL2.0 Standard</DocumentTemplateName><TemplateSchemaId>RTSP2000003</TemplateSchemaId><Type>Inbox</Type><SenderUserId>UA000000191000001</SenderUserId><SenderUserName>Thieme</SenderUserName><DocumentViewerId>GLDV9223370666504282968RA000000006DVRA000000006DTP2000001999998P3</DocumentViewerId><DocumentViewerName>SimplerInvoicing Factuur - UBL2.0 Standard</DocumentViewerName></tuple><startrowrange>CUA000000191000001INCC9223370647483476971UA000000191000001</startrowrange></GetInboxDocumentsResponse></SOAP:Body></SOAP:Envelope>";

            XDocument xDoc = XDocument.Load(new StringReader(soap));
            var unwrappedResponse = xDoc.Descendants((XNamespace) "http://schemas.xmlsoap.org/soap/envelope/" + "Body")
                .First()
                .FirstNode;
        }

    }
}
