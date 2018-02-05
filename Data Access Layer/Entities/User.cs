using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    class User : IAuditLogs
    {

        public string userName { get; set; }
        public string password { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    public DateTime createdOn { get; set; }
        public int createdBy { get; set; }
        public int modefiedBy { get; set; }
        public DateTime modifiedOn { get; set; }
    }
}
