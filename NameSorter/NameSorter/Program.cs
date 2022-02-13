using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace NameSorter
{
    public class Name
    {
        public string FirstName { get; set; }
        public List<string> MiddleNames { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        // Empty.
        public Name ()
        {
            this.FirstName = null;
            this.LastName = null;

            this.FullName = null;
        }
        // Initialise without middle names.
        public Name (string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;

            this.FullName = FirstName + " " + LastName;
        }
        // Initialise with middle names.
        public Name(string firstname, List<string> middlenames, string lastname)
        {
            this.FirstName = firstname;
            this.MiddleNames = middlenames;
            this.LastName = lastname;

            this.FullName = FirstName + " ";
            for (int i = 0; i < middlenames.Count; i++)
            {
                this.FullName += middlenames[i] + " ";
            }
            this.FullName += LastName; 
        }
    }
    public class NamesList
    {
        public List<Name> FullNames { get; set; }
        public NamesList()
        {
            this.FullNames = new List<Name>();
        }
        public void AddName(Name new_name)
        {
            this.FullNames.Add(new_name);
        }
        public IOrderedEnumerable<Name> Sort()
        {
            var orderByResult = 
                from s in FullNames
                orderby s.LastName 
                select s;

            return orderByResult;
        }
        public int Count()
        {
            return FullNames.Count();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../unsorted-names-list.txt";
            string text = File.ReadAllText(path);
            string[] file_names = text.Split("\r\n");

            NamesList names_in_order = new NamesList();
            List<string> middle_names = new List<string>();

            for (int i = 0; i < file_names.Count(); i++)
            {
                string[] placeholder_array = file_names[i].Split(" ");

                for (int j = 1; j < placeholder_array.Count() - 1; j++)
                {
                    middle_names.Add(placeholder_array[j]);
                }

                if (placeholder_array.Count() == 2)
                {
                    names_in_order.AddName(new Name(placeholder_array[0], placeholder_array[1]));
                }
                else
                {
                    names_in_order.AddName(new Name(placeholder_array[0], middle_names, placeholder_array[placeholder_array.Count() - 1]));
                }
                middle_names.Clear();
            }
            
            IOrderedEnumerable<Name> sorted_list = names_in_order.Sort();
            string sorted_list_text = "";

            foreach (var name in sorted_list)
            {
                Console.WriteLine(name.FullName);
                sorted_list_text += name.FullName + Environment.NewLine;
            }

            File.WriteAllText("../../../../sorted-names-list.txt", sorted_list_text);
        }
    }
}
