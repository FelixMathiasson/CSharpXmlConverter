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
                        person.FirstName = lines[1];
                        person.LastName = lines[2];
                        personList.Add(person); // as person is added, we edit the memory of the object. Such as adding a phone number, essentially person is memory reference
                        break;
                    }
                    case "T": // line describes telephone number
                    {
                            var phoneNumber = new PhoneNumber();
                            phoneNumber.MobileNumber = lines[1];
                            phoneNumber.LandlineNumber = lines[2];
                            
                            if(familyMember == null) // potential family not reached in input yet, person data comes first
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
                            adress.Street = lines[1];
                            adress.City = lines[2];
                            adress.Zip = lines.Length > 3 ? lines[3] : string.Empty; //if there is a fourth line, add the zip code. Otherwise add nothing

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
                            familyMember.Name = lines[1];
                            familyMember.BirthYear = lines[2];
                            person.FamilyMembers.Add(familyMember); // add family member to person object
                            break;
                    }
                }
            }

            return personList; // all lines read, return list of objects with relations
        }
    }
}
