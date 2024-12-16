using System.Reflection;
namespace TestProject_Asser_THAT_demo;

[TestFixture]
public class TestSampleString
{
    [Test]
    public void DoesNotEndWith()
    {
        StringAssert.DoesNotEndWith("a","abc");
    }

    [Test]
    public void  EndsWith()
    {
        StringAssert.EndsWith("a","abc");
        StringAssert.EndsWith("a","123abc");
        StringAssert.EndsWith("ABC","123abc");
    }

    [Test]
    public void CaseInsensitiveCompare()
    {
        StringAssert.AreEqualIgnoringCase("name", "NAME");
    }

    [Test]
    public void ThatExample()
    {
        var sentence = " The good , the bad and the ugly ";

        Assert.That(sentence, Is.EqualTo("The good, the bad and the ugly"));
        Assert.That(sentence, Is.EqualTo("The good "));
        Assert.That(sentence, Is.EqualTo("the bad "));
        Assert.That(sentence, Is.EqualTo("the ugly"). IgnoreCase);

        Assert.That(sentence, Contains.Substring("the bad"));

    }

} 