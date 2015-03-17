using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class BetterPersonNamePropertyTest : StringPropertyTest<GenericDataValidationException<string>>
    {
        public BetterPersonNamePropertyTest()
            : base(NameProperty)
        {

        }

        protected override Person CreatePerson()
        {
            var t = typeof(BetterPerson);
            var p = Activator.CreateInstance(t) as BetterPerson;
            GetProperty(t, NameProperty).GetSetMethod().Invoke(p, new object[] { SampleName });
            GetProperty(t, SurnameProperty).GetSetMethod().Invoke(p, new object[] { SampleSurname });
            return p;
        }
    }
}
