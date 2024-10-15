using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlConverter.Models;

namespace XmlConverter
{
    public class XmlConvert
    {
        public XElement MakeXML(List<Person> people)
        {
            // XElement basically builds the data gatherered by the parser as an XML file
            var resultXML = new XElement("people"); //this where people will be stored

            foreach (var person in people)
            {
                //always included
                var firstName = new XElement("firstname", person.FirstName);
                var lastName = new XElement("lastname", person.LastName);

                var element = new XElement("person", firstName, lastName);

                if(person.PhoneNumber != null) // if phone number exists
                {
                    var mobile = new XElement("mobile", person.PhoneNumber.MobileNumber);
                    var landline = new XElement("landline", person.PhoneNumber.LandlineNumber);

                    element.Add(new XElement("phone", mobile, landline));
                }

                if(person.Adress != null) // if adress exists
                {
                    var city = new XElement("city", person.Adress.City); 
                    var street = new XElement("street", person.Adress.Street);
                    var zip = new XElement("zip", person.Adress.Zip);

                    element.Add(new XElement("adress", street, city, zip));
                }

                foreach (var member in person.FamilyMembers) // for every family member of the person, if there are any
                {
                    var name = new XElement("name", member.Name);
                    var born = new XElement("born", member.BirthYear);

                    var familyElement = new XElement("family", name, born);

                    if (member.PhoneNumber != null) // if phone number exists
                    {
                        var mobile = new XElement("mobile", member.PhoneNumber.MobileNumber);
                        var landline = new XElement("landline", member.PhoneNumber.LandlineNumber);

                        familyElement.Add(new XElement("phone", mobile, landline));
                    }

                    if (member.Adress != null) // if adress exists
                    {
                        var city = new XElement("city", member.Adress.City);
                        var street = new XElement("street", member.Adress.Street);
                        var zip = new XElement("zip", member.Adress.Zip);

                        familyElement.Add(new XElement("adress", street, city, zip));
                    }

                    element.Add(familyElement); // add the family member to the person 
                }

                resultXML.Add(element); // add the person to the return list filled with people
            }
            return resultXML; 
        }
    }
}
