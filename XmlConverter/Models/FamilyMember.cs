using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlConverter.Models
{
    public class FamilyMember
    {
        public string BirthYear { get; set; }
        public string Name { get; set; }
        public Adress Adress { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
    }
}
