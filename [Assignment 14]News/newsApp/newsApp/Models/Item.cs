//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace newsApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public string ItemLink { get; set; }
        public string ItemGuid { get; set; }
        public Nullable<System.DateTime> ItemPubDate { get; set; }
        public string ItemImage { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Itemauthor { get; set; }
        public string Itemsummary { get; set; }
        public string Itemcomments { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
