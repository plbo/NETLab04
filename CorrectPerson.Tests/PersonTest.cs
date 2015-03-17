using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class PersonTest : TestBase
    {
        public PersonTest()
            : base(typeof(Person))
        {

        }

        [TestMethod]
        public void Person_HasAllRequiredProperties()
        {
            TestProperty(SurnameProperty, typeof(string));
            TestProperty(NameProperty, typeof(string));
            TestProperty(AgeProperty, typeof(int));
        }

        [TestMethod]
        public void Person_ToStringReturnsProperText()
        {
            var p = CreatePerson();

            Assert.AreEqual(SamplePersonString, p.ToString(), "To string is in 'Name Surname' form");
        }
    }
}
