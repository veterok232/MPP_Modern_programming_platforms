using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;

[TestFixture]
class FooTest
{
    private Mock<IDisposable> a;
    private Mock<ICloneable> b;
    private Foo foo;
    [SetUp]
    public void SetUp()
    {
        var c = default (int);
        var d = default (string);
        a = new Mock<IDisposable>();
        b = new Mock<ICloneable>();
        foo = new Foo(a.Object, b.Object, c, d);
    }

    [Test]
    public void TestFunction1()
    {
        var e = default (int);
        var f = default (int);
        var actual = foo.TestFunction1(e, f);
        var expected = default (int);
        Assert.That(actual, Is.EqualTo(expected));
        Assert.Fail("autogenerated");
    }

    [Test]
    public void TestFunction2()
    {
        foo.TestFunction2();
        Assert.Fail("autogenerated");
    }
}