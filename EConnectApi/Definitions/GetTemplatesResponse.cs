using System;
using System.Xml.Serialization;
using EConnectApi.Helpers;

namespace EConnectApi.Definitions
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class GetTemplatesResponse
    {
        public class TemplateDetails
        {
            public string DocumentTemplateId { get; set; }

            public string DocumentTemplateName { get; set; }

            public string Description { get; set; }

            public string OwnerUserId { get; set; }

            public string OwnerUserName { get; set; }

            public string OwnerAccountId { get; set; }
            
            public string OwnerAccountName { get; set; }

            public string CreatorUserId { get; set; }

            public string CreatorUserName { get; set; }

            public string ParentTemplateId { get; set; }

            public bool IsMasterTemplate { get; set; }

            public string MasterTemplateId { get; set; }

            public string MasterTemplateName { get; set; }
            public string Language { get; set; }


            [XmlElement(ElementName = "URL")]
            public string RawUrl
            {
                get { return Url == null ? null : Url.ToString(); }
                set
                {
                    try
                    {
                        Url = value == null ? null : new Uri(value);
                    }
                    catch
                    {
                        Url = null;
                    }
                }
            }

            [XmlIgnore]
            public Uri Url { get; set; }

            [XmlIgnore]
            public DateTime CreatedDateTime { get; set; }

            // Proxied property
            [XmlElement(ElementName = "CreatedDate")]
            public long RawCreatedDateTime
            {
                get
                {
                    return CreatedDateTime.ToJavaTimestamp();
                }
                set
                {
                    CreatedDateTime = value.ToDateTime();
                }
            }

            [XmlIgnore]
            public DateTime LastModifiedDateTime { get; set; }

            // Proxied property
            [XmlElement(ElementName = "LastModifiedDate")]
            public long RawLastModifiedDateTime
            {
                get
                {
                    return LastModifiedDateTime.ToJavaTimestamp();
                }
                set
                {
                    LastModifiedDateTime = value.ToDateTime();
                }
            }

            public string LastModifiedByUserId { get; set; }

            public string LastModifiedByUserName { get; set; }
        }

        [XmlElement(ElementName = "tuple")]
        public TemplateDetails[] Templates { get; set; }
    }
}