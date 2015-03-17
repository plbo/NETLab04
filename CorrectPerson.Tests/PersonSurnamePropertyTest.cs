using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class PersonSurnamePropertyTest :
        StringPropertyTest<TextValidationException>
    {
        public PersonSurnamePropertyTest()
            : base(SurnameProperty)
        {

        }
    }
}
