using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class PersonAgeNumberPropertyTest :
        NumberPropertyTest<NumberValidationException>
    {
        public PersonAgeNumberPropertyTest()
            : base(AgeProperty)
        {

        }
    }
}
