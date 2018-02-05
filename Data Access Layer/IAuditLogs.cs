using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    interface IAuditLogs
    {
        Int64 ID { get; set; }
        DateTime createdOn
        {
            get;
            set;
        }
        int createdBy
        {
            get;
            set;
        }
        int modefiedBy
        {
            get;
            set;
        }
        DateTime modifiedOn
        {
            get;
            set;
        }
    }
}
