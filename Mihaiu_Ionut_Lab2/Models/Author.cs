﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Mihaiu_Ionut_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        
        public string LastName { get; internal set; }
        public string FirstName { get; internal set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Book>? Books { get; set; }
        
    }
}
