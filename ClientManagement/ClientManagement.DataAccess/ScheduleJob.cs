//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientManagement.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class ScheduleJob
    {
        public int Id { get; set; }
        public int ServiceTypeID { get; set; }
        public int ClientID { get; set; }
        public string UserID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> EstimatedDuration { get; set; }
        public string Notes { get; set; }
        public bool Complete { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Client Client { get; set; }
        public virtual ServiceType ServiceType { get; set; }
    }
}
