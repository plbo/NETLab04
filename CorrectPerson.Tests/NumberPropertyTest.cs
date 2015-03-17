using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CorrectPerson.Tests
{
    public abstract class NumberPropertyTest<ExpectedException> : PersonPropertyTest
        where ExpectedException : Exception
    {
        public NumberPropertyTest(string propertyName)
            : base(propertyName)
        {

        }

        [TestMethod]
        public void AgeDoesNotAcceptMinusAge()
        {
            CreatePersonAndSetProperty<ExpectedException>(PropertyName, -1);
        }

        [TestMethod]
        public void AgeDoesNot150OrMoreAge()
        {
            CreatePersonAndSetProperty<ExpectedException>(PropertyName, 151);
        }

        [TestMethod]
        public void AgeAccept1Year()
        {
            CreatePersonAndSetProperty(PropertyName, 1);
        }

        [TestMethod]
        public void AgeAccept100Years()
        {
            CreatePersonAndSetProperty(PropertyName, 100);
        }
    }
}
