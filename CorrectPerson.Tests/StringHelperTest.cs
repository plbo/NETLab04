using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class StringHelperTest : TestBase
    {
        const string IsStringValidMethodName = "IsStringValid";

        public StringHelperTest()
            : base(typeof(StringHelper))
        {

        }

        [TestMethod]
        public void StringHelper_IsPublicStaticClass()
        {
            Assert.IsTrue(IsStaticClass,
                string.Format("{0} is public static class", _testingType.Name));
        }

        [TestMethod]
        public void IsStringValid_IsPublicStaticWithProperSignature()
        {
            var mi = GetStringValidMethod();

            Assert.IsNotNull(mi, string.Format("{0} is public and non static", IsStringValidMethodName));
            Assert.IsTrue(typeof(bool).Equals(mi.ReturnType), string.Format("{0} returns bool", IsStringValidMethodName));
            Assert.AreEqual(mi.GetParameters().Length, 1, string.Format("{0} parameter is string", IsStringValidMethodName));
            Assert.IsTrue(typeof(string).Equals(mi.GetParameters()[0].ParameterType), string.Format("{0} parameter is string", IsStringValidMethodName));
        }

        [TestMethod]
        public void IsStringValid_ReturnFalseOnNullString()
        {
            var value = InvokeValidMethod(null);

            Assert.IsFalse(value);
        }

        [TestMethod]
        public void IsStringValid_ReturnFalseOnEmptyString()
        {
            var value = InvokeValidMethod("");

            Assert.IsFalse(value);
        }

        [TestMethod]
        public void IsStringValid_ReturnFalseOnWhitespaceString()
        {
            var value = InvokeValidMethod("                      ");

            Assert.IsFalse(value);
        }

        [TestMethod]
        public void IsStringValid_ReturnFalseOnStringWith2Characters()
        {
            var value = InvokeValidMethod("ab");

            Assert.IsFalse(value);
        }

        [TestMethod]
        public void IsStringValid_ReturnTrueOnStringWith3Characters()
        {
            var value = InvokeValidMethod("abc");

            Assert.IsTrue(value);
        }

        private MethodInfo GetStringValidMethod()
        {
            return _testingType.GetMethod(IsStringValidMethodName, BindingFlags.Public | BindingFlags.Static);
        }

        private bool InvokeValidMethod(string textToTest)
        {
            var mi = GetStringValidMethod();
            Assert.IsNotNull(mi, string.Format("{0} method exists in class {1}", IsStringValidMethodName, _testingType.Name));
            var retObj = mi.Invoke(null, new object[] { textToTest });
            Assert.IsInstanceOfType(retObj, typeof(bool), string.Format("{0} returned something different than boolean", IsStringValidMethodName));
            return (bool)retObj;
        }
    }
}
