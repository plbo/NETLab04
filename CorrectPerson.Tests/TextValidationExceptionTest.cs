using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class TextValidationExceptionTest : TestBase
    {
        public TextValidationExceptionTest()
            : base(typeof(TextValidationException))
        {

        }

        [TestMethod]
        public void TextValidationException_IsPublicClassInheritedFromDataValidationException()
        {
            Assert.IsFalse(IsStaticClass,
                string.Format("{0} is not static class", _testingType.Name));

            Assert.IsTrue(typeof(DataValidationException).Equals(_testingType.BaseType),
                string.Format("{0} inherits DataValidationException", _testingType.Name));
        }

        [TestMethod]
        public void TextValidationException_HasPersonWithInvalidDataProperty()
        {
            TestProperty(WrongTextValueProperty, typeof(string));
        }

        [TestMethod]
        public void TextValidationException_HasProperConstructor()
        {
            GetTypeConstructor();
        }

        [TestMethod]
        public void TextValidationException_GetUserFriendlyMessageReturnsRightMessage()
        {
            var invalidName = "abc";
            var p = CreatePerson();
            var resultMessage = InvokeTest(SampleExceptionMessage, p, invalidName);

            Assert.AreEqual(string.Format(DataValidationException.ValidationErrorMessageFormat, SamplePersonString, invalidName, SampleExceptionMessage),
                resultMessage, false, "User friendly does not fail on non null person");
        }

        private string InvokeTest(string message, Person p, string text)
        {
            var c = GetTypeConstructor();
            var obj = c.Invoke(new object[] { message, p, text });
            var mi = _testingType.GetMethod(GetUserFriendlyMessageMethodName);
            return (string)mi.Invoke(obj, null);
        }

        private ConstructorInfo GetTypeConstructor()
        {
            return GetAndTestConstructor(typeof(string), typeof(Person), typeof(string));
        }
    }
}
