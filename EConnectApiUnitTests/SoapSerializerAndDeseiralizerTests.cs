using System;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Text;
using EConnectApi.Definitions.SOAP;
using EConnectApi.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization.Formatters.Soap;

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
    }
}
