using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class PersonNamePropertyTest : StringPropertyTest<TextValidationException>
    {
        public PersonNamePropertyTest()
            : base(NameProperty)
        {

        }
    }
}
