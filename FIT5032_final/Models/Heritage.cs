//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5032_final.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Heritage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int RouteId { get; set; }
    
        public virtual Route Route { get; set; }
    }
}
