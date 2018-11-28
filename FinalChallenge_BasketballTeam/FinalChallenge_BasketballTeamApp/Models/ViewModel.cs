using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalChallenge_BasketballTeamApp.Models
{
    public class ViewModel
    {
        public List<AspNetUser> AspNetUsers { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public List <AspNetRole> AspNetRoles { get; set; }
        public AspNetRole AspNetRole { get; set; }
        public List<Manager> Managers { get; set; }
        public Manager Manager { get; set; }
        public List<Fixture> Fixtures { get; set; }
        public Fixture Fixture { get; set; }
    }
}