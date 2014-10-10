using System;
using System.IO;
using System.Xml.Serialization;

namespace EConnectApi.Definitions
{
    public class FileWrapper
    {
        /// <summary>
        /// Orginal filename
        /// </summary>
        [XmlIgnore]
        protected string FileName { get; set; }

        /// <summary>
        /// File bytes
        /// </summary>
        [XmlIgnore]
        public byte[] Contents { get; set; }

        /// <summary>
        /// File bytes based on Contents propertu in base64 string
        /// </summary>       
        protected string Base64
        {
            get
            {
                if (Contents == null)
                    return null;

                if (Contents.Length == 0)
                    return string.Empty;

                return Convert.ToBase64String(Contents);
            }
            set
            {
                Contents = Convert.FromBase64String(value);
            }
        }

        public FileWrapper()
        {

        }

        public FileWrapper(string filename, string base64)
        {
            FileName = filename;
            Base64 = base64;

        }
        public FileWrapper(string filename, byte[] contents)
        {
            FileName = filename;
            Contents = contents;
        }

        /// <summary>
        /// Store file in give directory
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filename"></param>
        public void Store(string directory, string filename = null)
        {
            var path = Path.Combine(directory, filename ?? FileName);
            File.WriteAllBytes(path, Contents);
        }

        /// <summary>
        /// Load file contents into the wrapper
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path)
        {
            Contents = File.ReadAllBytes(path);
        }
    }
}