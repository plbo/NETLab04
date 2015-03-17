using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CorrectPerson.Tests
{
    public abstract class PersonPropertyTest : TestBase
    {
        protected readonly string PropertyName;

        public PersonPropertyTest(string propertyName)
            : base(typeof(Person))
        {
            PropertyName = propertyName;
        }

        protected void CreatePersonAndSetProperty(string propName, object value)
        {
            var p = CreatePerson();
            var prop = GetProperty(propName);
            var valueBefore = prop.GetGetMethod().Invoke(p, null);

            try
            {
                prop.GetSetMethod().Invoke(p, new object[] { value });
                Assert.AreEqual(value, prop.GetGetMethod().Invoke(p, null));
            }
            catch
            {
                Assert.AreEqual(valueBefore, prop.GetGetMethod().Invoke(p, null),
                    string.Format("State for property {0} should not be changed when exception is thrown", propName));
                throw;
            }
        }

        protected void CreatePersonAndSetProperty<TEx>(string propName, object value) where TEx : Exception
        {
            try
            {
                CreatePersonAndSetProperty(propName, value);
            }
            catch (Exception ex)
            {
                if (!(ex.InnerException is TEx))
                {
                    Assert.Fail("Unknown exception was thrown:" + ex);
                }
            }
        }
    }
}
