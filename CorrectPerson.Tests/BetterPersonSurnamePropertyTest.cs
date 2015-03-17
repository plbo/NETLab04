using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class BetterPersonSurnamePropertyTest : StringPropertyTest<GenericDataValidationException<string>>
    {
        public BetterPersonSurnamePropertyTest()
            : base(SurnameProperty)
        {

        }

        protected override Person CreatePerson()
        {
            var t = typeof(BetterPerson);
            var p = (BetterPerson)Activator.CreateInstance(t);
            GetProperty(t, NameProperty).GetSetMethod().Invoke(p, new object[] { SampleName });
            GetProperty(t, SurnameProperty).GetSetMethod().Invoke(p, new object[] { SampleSurname });
            return p;
        }
    }
}
