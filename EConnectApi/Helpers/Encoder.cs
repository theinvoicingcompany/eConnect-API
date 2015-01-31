using System.Web;

namespace EConnectApi.Helpers
{
    public static class Encoder
    {
        /// <summary>
        /// Url Encode mail address (except @ sign)
        /// </summary>
        /// <example>
        /// This can be used if mailaddress is added to the url
        /// </example>
        /// <param name="mail"></param>
        /// <returns></returns>
        public static string MailAddressForUrl(string mail)
        {
            if (string.IsNullOrEmpty(mail))
                return mail;

            var index = mail.IndexOf('@');
            return HttpUtility.UrlEncode(mail.Substring(0, index)) + mail.Substring(index);
        }
    }
}
