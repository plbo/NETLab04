using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CorrectPerson.Tests
{
    public class StringPropertyTest<ExpectedException> : PersonPropertyTest
        where ExpectedException : Exception
    {
        public StringPropertyTest(string propertyName)
            : base(propertyName)
        {

        }

        [TestMethod]
        public void StringProperty_DoesNotAcceptEmptyString()
        {
            CreatePersonAndSetProperty<ExpectedException>(PropertyName, "");
        }

        [TestMethod]
        public void StringProperty_DoesNotAcceptWhitespaceString()
        {
            CreatePersonAndSetProperty<ExpectedException>(PropertyName, "   ");
        }

        [TestMethod]
        public void StringProperty_DoesNotAcceptNullString()
        {
            CreatePersonAndSetProperty<ExpectedException>(PropertyName, null);
        }

        [TestMethod]
        public void StringProperty_DoesNotAcceptTooShortString()
        {
            CreatePersonAndSetProperty<ExpectedException>(PropertyName, "a");
        }

        [TestMethod]
        public void StringProperty_AcceptProperName()
        {
            CreatePersonAndSetProperty<ExpectedException>(PropertyName, "Jakub");
        }
    }
}
