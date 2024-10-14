using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlConverter.Models;

namespace XmlConverter
{
    public class XmlConver
    {
        public XElement MakeXML(List<Person> people)
        {
            // XElement basically builds the data gatherered by the parser as an XML file
            var resultXML = new XElement("people");

            foreach (var person in people)
            {
                //always included
                var firstName = new XElement("firstname", person.FirstName);
                var lastName = new XElement("lastname", person.LastName);

                var element = new XElement("person", firstName, lastName);
            }
        }
    }
}
