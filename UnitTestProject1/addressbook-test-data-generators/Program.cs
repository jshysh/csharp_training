using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            if (dataType == "group")
            {
                List<GroupData> groups = GenerateGroupDataTemplate(count);
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Write("WARNING! Unrecognized file format: " + format + ".");
                }
                writer.Close();
            }
            else if (dataType == "contact")
            {
                List<ContactData> contacts = GenerateContactDataTemplate(count);
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Write("WARNING! Unrecognized file format: " + format + ".");
                }
                writer.Close();
            }
        }

        // Group data template creation
        public static List<GroupData> GenerateGroupDataTemplate(int count)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(35))
                {
                    Header = TestBase.GenerateRandomString(400),
                    Footer = TestBase.GenerateRandomString(400)
                });
            }
            return groups;
        }

        // Contact data template creation
        public static List<ContactData> GenerateContactDataTemplate(int count)
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(35), TestBase.GenerateRandomString(35))
                {
                    Address = TestBase.GenerateRandomString(175),

                    Home = TestBase.GenerateRandomString(35),
                    Mobile = TestBase.GenerateRandomString(35),
                    Work = TestBase.GenerateRandomString(35),

                    Email = TestBase.GenerateRandomString(35),
                    Email2 = TestBase.GenerateRandomString(35),
                    Email3 = TestBase.GenerateRandomString(35),
                });
            }
            return contacts;
        }

        //Csv file for groups (addressbook-test-data-generators.exe group 5 groups.csv csv)
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        //Csv file for contacts (addressbook-test-data-generators.exe contact 5 contacts.csv csv)
        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8}",
                contact.FirstName, contact.LastName,

                contact.Address, 

                contact.Home, contact.Mobile, contact.Work,

                contact.Email, contact.Email2, contact.Email3
                ));
            }
        }

        // Xml file for groups (addressbook-test-data-generators.exe group 5 groups.xml xml)
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        // Xml file for contacts (addressbook-test-data-generators.exe contact 5 contacts.xml xml)
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        // Json file for groups (addressbook-test-data-generators.exe group 5 groups.json json)
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        // Json file for contacts (addressbook-test-data-generators.exe contact 5 contacts.json json)
        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}