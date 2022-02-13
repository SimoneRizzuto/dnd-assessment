using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using NameSorter;

namespace NameSorterTest
{
    [TestClass]
    public class NameSorterUnitTests
    {
        [TestMethod]
        public void InitialiseName()
        {
            Name simone_rizzuto = new Name("Simone", "Rizzuto");

            Assert.AreEqual(simone_rizzuto.FirstName, "Simone");
            Assert.AreEqual(simone_rizzuto.LastName, "Rizzuto");
        }
        [TestMethod]
        public void InitialiseMiddleNames()
        {
            List<string> middle_names = new List<string>();

            middle_names.Add("Harry");
            middle_names.Add("Jack");

            Name simone_rizzuto = new Name("Simone", middle_names, "Rizzuto");

            Assert.AreEqual(simone_rizzuto.FirstName, "Simone");
            Assert.AreEqual(simone_rizzuto.MiddleNames[0], "Harry");
            Assert.AreEqual(simone_rizzuto.MiddleNames[1], "Jack");
            Assert.AreEqual(simone_rizzuto.LastName, "Rizzuto");
        }
        [TestMethod]
        public void InitialiseNamesList()
        {
            NamesList test_names = new NamesList();
        }

        [TestMethod]
        public void NamesListAddName()
        {
            NamesList test_names = new NamesList();

            Name simone_rizzuto = new Name("Simone", "Rizzuto");

            test_names.AddName(simone_rizzuto);

            Assert.AreEqual(simone_rizzuto, test_names.FullNames[0]);
        }

        [TestMethod]
        public void NamesListSort()
        {
            NamesList names_in_order = new NamesList();
            names_in_order.AddName(new Name("Simone", "Rizzuto"));
            names_in_order.AddName(new Name("Harry", "Smith"));
            names_in_order.AddName(new Name("Jack", "Harris"));
            names_in_order.AddName(new Name("Leslie", "Johnson"));

            NamesList names_out_of_order = new NamesList();
            names_out_of_order.AddName(new Name("Simone", "Rizzuto"));
            names_out_of_order.AddName(new Name("Harry", "Smith"));
            names_out_of_order.AddName(new Name("Jack", "Harris"));
            names_out_of_order.AddName(new Name("Leslie", "Johnson"));

            names_in_order.Sort();
            names_out_of_order.Sort();

            Assert.AreNotEqual(names_in_order, names_out_of_order);
        }
    }
}
