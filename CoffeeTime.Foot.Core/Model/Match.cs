//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeTime.Foot.Core.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Match
    {
        public int Id { get; set; }
        public System.DateTime DateMatch { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public Nullable<int> Score1 { get; set; }
        public Nullable<int> Score2 { get; set; }
        public string Result { get; set; }
        public int MatchNum { get; set; }
        public int SeasonId { get; set; }
    
        public virtual Season Season { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
    }
}
