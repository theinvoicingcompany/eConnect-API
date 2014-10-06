using System;
using System.Linq;

namespace EConnectApi.Definitions
{
    public class Statuses
    {
        protected string LatestStatusCode;
        protected Status[] AllStatuses;
        protected readonly string CodeNameDefaultStatus = "defaultstatus";

        public Statuses(string possibleConsignmentStatuses, string latestStatusCode)
        {
            LatestStatusCode = latestStatusCode;
            // Since .net 4 we could use IsNullOrWhiteSpace 
            // if (string.IsNullOrWhiteSpace(possibleConsignmentStatuses))
            if (possibleConsignmentStatuses == null || string.IsNullOrEmpty(possibleConsignmentStatuses.Trim()))
            {
                AllStatuses = new Status[0];
                return;
            }

            var rows = possibleConsignmentStatuses.Split(',');
            AllStatuses = new Status[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                var row = rows[i];
                AllStatuses[i] = new Status(row);
            }
        }

        /// <summary>
        /// The status that is marked as default  (can be null)
        /// </summary>
        public Status DefaultStatus
        {
            get { return AllStatuses.FirstOrDefault(a => a.CodeName.Equals(CodeNameDefaultStatus, StringComparison.InvariantCultureIgnoreCase)); }
        }


        /// <summary>
        /// The current status (can be null)
        /// </summary>
        public Status LatestStatus
        {
            get { return AllStatuses.FirstOrDefault(a => a.Code.Equals(LatestStatusCode)); }
        }


        /// <summary>
        /// Get next status from ordered list. If no next return null
        /// </summary>
        /// <returns></returns>
        public Status NextStatus
        {
            get
            {
                var statuses = PossibleStatuses;
                // max count is statuses.Length-1 because there is no next after statuses.Length
                for (int i = 0; i < statuses.Length - 1; i++)
                {
                    if (statuses[i].Code == LatestStatusCode)
                    {
                        // Return next
                        return statuses[++i];
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Get previous status from ordered list. If no back return null
        /// </summary>
        /// <returns></returns>
        public Status PreviousStatus
        {
            get
            {
                var statuses = PossibleStatuses;
                // start position is 1 because there is no back at position 0
                for (int i = 1; i < statuses.Length; i++)
                {
                    if (statuses[i].Code == LatestStatusCode)
                    {
                        // Return next
                        return statuses[--i];
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Get all possible statuses
        /// </summary>
        /// <returns></returns>
        public Status[] PossibleStatuses
        {
            get
            {
                return
                    AllStatuses.Where(a => !a.CodeName.Equals(CodeNameDefaultStatus, StringComparison.InvariantCultureIgnoreCase))
                        .OrderBy(a => a.CodeName).ToArray();
            }
        }
    }
}