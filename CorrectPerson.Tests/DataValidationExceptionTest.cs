using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class DataValidationExceptionTest : TestBase
    {
        public DataValidationExceptionTest()
            : base(typeof(DataValidationException))
        {

        }

        [TestMethod]
        public void DataValidationException_HasPersonWithInvalidDataProperty()
        {
            TestProperty(PersonWithInvalidDataProperty, typeof(Person));
        }

        [TestMethod]
        public void DataValidationException_HasProperConstructor()
        {
            GetTypeConstructor();
        }

        [TestMethod]
        public void DataValidationException_GetUserFriendlyMessageReturnsRightValuesOnNullPerson()
        {
            var resultMessage = InvokeTest(SampleExceptionMessage, null);

            Assert.AreEqual(string.Format(DataValidationException.ValidationErrorMessageFormat, "", DataValidationException.UnknownValue, SampleExceptionMessage),
                resultMessage, false, "User friendly does not fail on null person");
        }

        [TestMethod]
        public void DataValidationException_GetUserFriendlyMessageReturnsRightValuesOnNotNullPerson()
        {
            var p = CreatePerson();
            var resultMessage = InvokeTest(SampleExceptionMessage, p);

            Assert.AreEqual(string.Format(DataValidationException.ValidationErrorMessageFormat, SamplePersonString, DataValidationException.UnknownValue, SampleExceptionMessage),
                resultMessage, false, "User friendly does not fail on non null person");
        }

        private string InvokeTest(string message, Person p)
        {
            var c = GetTypeConstructor();
            var obj = c.Invoke(new object[] { message, p });
            var mi = _testingType.GetMethod(GetUserFriendlyMessageMethodName);
            return (string)mi.Invoke(obj, null);
        }

        private ConstructorInfo GetTypeConstructor()
        {
            return GetAndTestConstructor(typeof(string), typeof(Person));
        }
    }
}
