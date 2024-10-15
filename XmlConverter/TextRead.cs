using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlConverter.Models;

namespace XmlConverter
{
    public class TextRead
    {
        private string TryGetLine(int index, string[] segments)
        {
            //if lines exists, return it. Otherwise return empty string
            return segments.Length > index ? segments[index] : string.Empty;
        }


        public List<Person> TextParseFile(string filename)
        {
            Person person = new Person();
            FamilyMember familyMember = new FamilyMember();
            var personList = new List<Person>();

            foreach (var line in File.ReadAllLines(filename)) // ReadAllLines opens the file, reads all the lines and then closes the file
            {
                var segments = line.Split('|');
                switch(segments[0])
                {
                    case "P": // line describes person
                    {
                        person = new Person();
                        person.FirstName = TryGetLine(1, segments);
                        person.LastName = TryGetLine(2, segments);
                        personList.Add(person);
                        break;
                    }
                    case "T": // telephone number
                    {
                            var phoneNumber = new PhoneNumber();
                            phoneNumber.MobileNumber = TryGetLine(1, segments);
                            phoneNumber.LandlineNumber = TryGetLine(2, segments);

                            if (familyMember == null) // potential family not reached in input yet, person data comes first
                            {
                                person.PhoneNumber = phoneNumber;
                            }
                            else // family member is being added 
                            {
                                familyMember.PhoneNumber = phoneNumber;
                            }
                            break;
                    }
                    case "A": // adress
                    {
                            var adress = new Adress();
                            adress.Street = TryGetLine(1, segments);
                            adress.City = TryGetLine(2, segments);
                            adress.Zip = TryGetLine(3, segments);

                            if (familyMember == null) // potential family not reached in input yet, person data comes first
                            {
                                person.Adress = adress;
                            }
                            else // family member is being added 
                            {
                                familyMember.Adress = adress;
                            }
                            break;
                    }
                    case "F": // family
                    {
                            familyMember = new FamilyMember();
                            familyMember.Name = TryGetLine(1, segments);
                            familyMember.BirthYear = TryGetLine(2, segments);
                            person.FamilyMembers.Add(familyMember);
                            break;
                    }
                }
            }

            return personList;
        }
    }
}
