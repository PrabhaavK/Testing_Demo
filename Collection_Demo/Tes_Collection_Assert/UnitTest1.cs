using  Library_For_CollectionTest;
namespace Tes_Collection_Assert;

public class Tests
{
    Class1  obj;

    [SetUp]
    public void Setup()
    {
        obj = new Class1();
    }

    [TearDown]
    public void Removeobject()
    {
        obj = null;
    }

    [Test]
    public void Test1()
    {
        List<string> names = obj.GetNames();

        CollectionAssert.AllItemsAreUnique(names, "Names are  not Unique");
        CollectionAssert.AllItemsAreNotNull(names, "Names are  not Null");
    
        //Assert.Pass();
    }
}