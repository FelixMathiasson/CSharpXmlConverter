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

                var personElement = new XElement("person", firstName, lastName);

                if(person.PhoneNumber != null) 
                {
                    var mobile = new XElement("mobile", person.PhoneNumber.MobileNumber);
                    var landline = new XElement("landline", person.PhoneNumber.LandlineNumber);

                    personElement.Add(new XElement("phone", mobile, landline));
                }

                if(person.Adress != null) 
                {
                    var city = new XElement("city", person.Adress.City); 
                    var street = new XElement("street", person.Adress.Street);
                    var zip = new XElement("zip", person.Adress.Zip);

                    if(person.Adress.Zip != string.Empty)
                    { 
                        personElement.Add(new XElement("adress", street, city, zip));
                    }
                    else
                    {
                        personElement.Add(new XElement("adress", street, city));
                    }
                }

                foreach (var member in person.FamilyMembers)
                {
                    var name = new XElement("name", member.Name);
                    var born = new XElement("born", member.BirthYear);

                    var familyElement = new XElement("family", name, born);

                    if (member.PhoneNumber != null)
                    {
                        var mobile = new XElement("mobile", member.PhoneNumber.MobileNumber);
                        var landline = new XElement("landline", member.PhoneNumber.LandlineNumber);

                        familyElement.Add(new XElement("phone", mobile, landline));
                    }

                    if (member.Adress != null)
                    {
                        var city = new XElement("city", member.Adress.City);
                        var street = new XElement("street", member.Adress.Street);
                        var zip = new XElement("zip", member.Adress.Zip);

                        if (member.Adress.Zip != string.Empty)
                        {
                            familyElement.Add(new XElement("adress", street, city, zip));
                        }
                        else
                        {
                            familyElement.Add(new XElement("adress", street, city));
                        }
                    }

                    personElement.Add(familyElement);
                }

                resultXML.Add(personElement); 
            }
            return resultXML; 
        }
    }
}
