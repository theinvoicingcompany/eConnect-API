using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EConnectApi.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EConnectApiFlowTests.Helpers
{
    public static class DocumentsRequesterFilters
    {
        public static GetDocumentsFiltersBase CreatedDateTime1
        {
            get
            {
                return new GetDocumentsFiltersBase()
                       {
                           CreatedDateTime = new TimeSpanFilter()
                                             {
                                                 To = DateTime.Now.AddDays(-30)
                                             }
                       };
            }
        }

        public static GetDocumentsFiltersBase CreatedDateTime2
        {
            get
            {
                return new GetDocumentsFiltersBase()
                {
                    CreatedDateTime = new TimeSpanFilter()
                    {
                        From = DateTime.Now.AddDays(-80),
                        To = DateTime.Now.AddDays(-3)
                    }
                };
            }
        }

        public static GetDocumentsFiltersBase ModifiedDateTime1
        {
            get
            {
                return new GetDocumentsFiltersBase()
                {
                    ModifiedDateTime = new TimeSpanFilter()
                    {
                        From = DateTime.Now.AddDays(-80),
                        To = DateTime.Now.AddDays(-3)
                    }
                };
            }
        }

        public static GetDocumentsFiltersBase IsReadFalse
        {
            get
            {
                return new GetDocumentsFiltersBase()
                {
                    IsRead = false
                };
            }
        }

        public static GetDocumentsFiltersBase IsReadTrue
        {
            get
            {
                return new GetDocumentsFiltersBase()
                {
                    IsRead = true
                };
            }
        }


        private static void ValidateTimeSpanFilter(TimeSpanFilter filter, DocumentBase[] docs)
        {
            var to = filter.To;
            if (to.HasValue)
                Assert.AreEqual(0, docs.Count(a => a.CreatedDateTime > to), "To filter not applied");

            var from = filter.From;
            if (from.HasValue)
                Assert.AreEqual(0, docs.Count(a => a.CreatedDateTime < from), "From filter not applied");
        }

        public static void Validate(GetDocumentsFiltersBase filter, DocumentBase[] docs)
        {
            if (docs == null || !docs.Any())
                Assert.Inconclusive("No documents found");

            if (filter.CreatedDateTime != null)
                ValidateTimeSpanFilter(filter.CreatedDateTime, docs);

            if (filter.ModifiedDateTime != null)
                ValidateTimeSpanFilter(filter.ModifiedDateTime, docs);

            if (!string.IsNullOrWhiteSpace(filter.ExternalId))
                Assert.AreEqual(0, docs.Count(a => a.ExternalId != filter.ExternalId), "ExternalId filter not applied");

            if (!string.IsNullOrWhiteSpace(filter.DocumentId))
                Assert.AreEqual(0, docs.Count(a => a.DocumentId != filter.DocumentId), "ExternalId filter not applied");

            if (!string.IsNullOrWhiteSpace(filter.DocumentTemplateId))
                Assert.AreEqual(0, docs.Count(a => a.DocumentTemplateId != filter.DocumentTemplateId), "DocumentTemplateId filter not applied");

        }

        public static void Validate(GetDocumentsFiltersBase filter, DocumentBaseExtensions[] docs)
        {
            if (docs == null || !docs.Any())
                Assert.Inconclusive("No documents found");

            Validate(filter, docs.Select(d => d as DocumentBase).ToArray());

            if (filter.IsRead.HasValue)
                Assert.AreEqual(0, docs.Count(a => a.IsRead != filter.IsRead), "Is Read filter not applied");
        }
    }
}
