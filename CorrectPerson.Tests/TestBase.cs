using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace CorrectPerson.Tests
{
    public abstract class TestBase
    {
        protected const string GetUserFriendlyMessageMethodName = "GetUserFriendlyMessage";
        protected const string SurnameProperty = "Surname";
        protected const string NameProperty = "Name";
        protected const string PersonWithInvalidDataProperty = "PersonWithInvalidData";
        protected const string WrongNumberProperty = "WrongNumber";
        protected const string WrongTextValueProperty = "WrongTextValue";
        protected const string AgeProperty = "Age";
        protected const string WrongValueProperty = "WrongValue";

        protected const string SampleExceptionMessage = "test message";
        protected const string SampleName = "Bob";
        protected const string SampleSurname = "Smith";
        protected const string ExpectedNameSurnameFormat = "{0} {1}";


        protected readonly Type _testingType;

        protected TestBase(Type typeToTest)
        {
            _testingType = typeToTest;
        }

        protected ConstructorInfo GetAndTestConstructor(params Type[] parameterTypes)
        {
            var constructor = _testingType.GetConstructor(parameterTypes);

            if (constructor == null)
            {
                Assert.Fail(
                    string.Format("{0} does not contain parameter with types of {1}",
                        _testingType.Name,
                        string.Join(", ", parameterTypes.Select(t => t.Name))));
            }

            return constructor;
        }

        protected bool IsStaticClass
        {
            get
            {
                return _testingType.IsAbstract
                    && _testingType.IsSealed
                    && _testingType.IsClass;
            }
        }

        protected PropertyInfo GetProperty(string propertyName)
        {
            return GetProperty(_testingType, propertyName);
        }

        protected PropertyInfo GetProperty(Type t, string propertyName)
        {
            var valueProperty = t.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty);

            if (valueProperty == null)
            {
                Assert.Fail(string.Format("{0} does not contain property with name {1}",
                    t.Name, propertyName));
            }

            return valueProperty;
        }

        protected void TestProperty(string propertyName, Type expectedType)
        {
            var property = GetProperty(propertyName);

            Assert.IsTrue(expectedType.Equals(property.PropertyType),
                string.Format("{0} property is in type of {1}", propertyName, expectedType.Name));
        }

        protected virtual Person CreatePerson()
        {
            var t = typeof(Person);
            var p = Activator.CreateInstance(t) as Person;
            GetProperty(t, NameProperty).GetSetMethod().Invoke(p, new object[] { SampleName });
            GetProperty(t, SurnameProperty).GetSetMethod().Invoke(p, new object[] { SampleSurname });
            return p;
        }

        protected string SamplePersonString
        {
            get
            {
                return string.Format(ExpectedNameSurnameFormat, SampleName, SampleSurname);
            }
        }
    }
}
