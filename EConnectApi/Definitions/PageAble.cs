using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class PageAble
    {
        protected byte PagerLimit = 20;
        public byte Limit
        {
            get { return PagerLimit; }
            set
            {
                if (value > 0)
                    PagerLimit = value;
            }
        }
        
        //[XmlElement(ElementName = "startrowrange")]
        //public string StartRowRange { get; set; }

        [XmlElement(ElementName = "cursor")]
        public string Cursor { get; set; }
    }

    public class PageAbleResponse
    {

        //[XmlElement(ElementName = "startrowrange")]
        //public string StartRowRange { get; set; }

        [XmlElement(ElementName = "cursor")]
        public string Cursor { get; set; }
    }
}