//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalChallenge_BasketballTeamApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fixture
    {
        public int fixtureID { get; set; }
        public int managerID { get; set; }
        public string Team { get; set; }
        public string teamManager { get; set; }
        public System.DateTime fixtureDateTime { get; set; }
        public string Venue { get; set; }
        public Nullable<decimal> Spent { get; set; }
    
        public virtual Manager Manager { get; set; }
    }
}