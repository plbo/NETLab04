using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorrectPerson.Tests
{
    [TestClass]
    public class BetterPersonTest : TestBase
    {
        public BetterPersonTest()
            : base(typeof(BetterPerson))
        {

        }


        [TestMethod]
        public void BetterPerson_HasAllRequiredProperties()
        {
            TestProperty(SurnameProperty, typeof(string));
            TestProperty(NameProperty, typeof(string));
            TestProperty(AgeProperty, typeof(int));
        }
    }
}
