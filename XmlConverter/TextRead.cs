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
        private string TryGetLine(int row, string[] lines)
        {
            return lines.Length > row ? lines[row] : string.Empty;
        }


        public List<Person> TextParseFile(string filename)
        {
            Person person = new Person();
            FamilyMember familyMember = new FamilyMember();
            var personList = new List<Person>();

            foreach (var line in File.ReadAllLines(filename)) // ReadAllLines opens the file, reads all the lines and then closes the file
            {
                var lines = line.Split('|');
                switch(lines[0])
                {
                    case "P": // line describes person
                    {
                        person = new Person();
                        person.FirstName = TryGetLine(1, lines);
                        person.LastName = TryGetLine(2, lines);
                        personList.Add(person); // as person is added, we edit the memory of the object. Such as adding a phone number, essentially person is memory reference
                        break;
                    }
                    case "T": // line describes telephone number
                    {
                            var phoneNumber = new PhoneNumber();
                            phoneNumber.MobileNumber = TryGetLine(1, lines);
                            phoneNumber.LandlineNumber = TryGetLine(2, lines);

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
                    case "A": // line describes an adress
                    {
                            var adress = new Adress();
                            adress.Street = TryGetLine(1, lines);
                            adress.City = TryGetLine(2, lines);
                            adress.Zip = TryGetLine(3, lines);

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
                    case "F": // line describes family
                    {
                            familyMember = new FamilyMember(); // initialize new memory of a family member object, essentially a new memory reference is created and added to the person's family
                            familyMember.Name = TryGetLine(1, lines);
                            familyMember.BirthYear = TryGetLine(2, lines);
                            person.FamilyMembers.Add(familyMember); // add family member to person object
                            break;
                    }
                }
            }

            return personList; // all lines read, return list of objects with relations
        }
    }
}
