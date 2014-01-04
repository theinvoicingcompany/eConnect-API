namespace EConnectApi.Definitions
{
    public class Status
    {


        /// <summary>
        /// Status is used for AllStatuses and DocumentStatuses
        /// </summary>
        /// <param name="rawstatus">like: consignmentstatus2:Gelezen:20</param>
        public Status(string rawstatus)
        {
            var cols = rawstatus.Split(':');
            if (cols.Length <= 1) return;
            CodeName = cols[0];
            Name = cols[1];
            Code = cols[2];
            //var statuscode = cols[2];
            //int iStatuscode;
            //int.TryParse(statuscode, out iStatuscode);
            //Code = iStatuscode;
        }

        internal string CodeName { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        protected bool Equals(Status other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Code, other.Code);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Code != null ? Code.GetHashCode() : 0);
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Status)obj);
        }

        public static bool operator ==(Status x, Status y)
        {
            if ((object)x == null) 
                return (object)y == null;

            return x.Equals((object)y);
        }
        public static bool operator !=(Status x, Status y)
        {
            return !(x == y);
        }
    }
}