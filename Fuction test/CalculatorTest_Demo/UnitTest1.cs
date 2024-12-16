using Calculator_DLL_ForTest;
namespace Calculator_UnitTesting_Demo
{
    public class Tests
    {
        Calculator obj;
 
        [SetUp]
        public void Setup()
        {
            obj = new Calculator();
        }
 
        [TearDown]
        public void TearDown(){
            obj= null;
        }
 
        [Test]
        public void Test1()
        {
            int a = 2, b = 3;
            int expected = 5;
            int result = obj.Add(a, b);
 
            Assert.AreEqual(expected, result);
        }
 
        [Test]
        public void Test2()
        {
            int a = 10, b = 2;
            int expected = 4;
            int result = obj.Sub(a, b);
 
             Assert.AreEqual(expected, result);
        }
    }
}