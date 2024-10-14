using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlConverter.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Adress Adress { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public List<FamilyMember> FamilyMembers { get; set; } = new List<FamilyMember>();
    }
}
