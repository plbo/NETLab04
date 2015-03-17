using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class NumberValidationExceptionTest : TestBase
    {
        public NumberValidationExceptionTest()
            : base(typeof(NumberValidationException))
        {

        }

        [TestMethod]
        public void NumberValidationException_IsPublicClassInheritedFromDataValidationException()
        {
            Assert.IsFalse(IsStaticClass,
                string.Format("{0} is not static class", _testingType.Name));

            Assert.IsTrue(typeof(DataValidationException).Equals(_testingType.BaseType),
                string.Format("{0} inherits DataValidationException", _testingType.Name));
        }

        [TestMethod]
        public void NumberValidationException_HasPersonWithInvalidDataProperty()
        {
            TestProperty(WrongNumberProperty, typeof(int));
        }

        [TestMethod]
        public void NumberValidationException_HasProperConstructor()
        {
            GetTypeConstructor();
        }

        [TestMethod]
        public void DataValidationException_GetUserFriendlyMessageReturnsRightMessage()
        {
            var age = 100;
            var p = CreatePerson();
            var resultMessage = InvokeTest(SampleExceptionMessage, p, age);

            Assert.AreEqual(string.Format(DataValidationException.ValidationErrorMessageFormat, SamplePersonString, age, SampleExceptionMessage),
                resultMessage, false, "User friendly does not fail on non null person");
        }

        private string InvokeTest(string message, Person p, int number)
        {
            var c = GetTypeConstructor();
            var obj = c.Invoke(new object[] { message, p, number });
            var mi = _testingType.GetMethod(GetUserFriendlyMessageMethodName);
            return (string)mi.Invoke(obj, null);
        }

        private ConstructorInfo GetTypeConstructor()
        {
            return GetAndTestConstructor(typeof(string), typeof(Person), typeof(int));
        }
    }
}
