﻿
using NUnit.Framework;

namespace RefactoringEssentials.Tests.VB.Converter
{
    [TestFixture]
    public class NamespaceLevelTests : ConverterTestBase
    {
        [Test]
        public void TestNamespace()
        {
            TestConversionCSharpToVisualBasic(@"namespace Test
{
    
}", @"Namespace Test
End Namespace");
        }

        [Test]
        public void TestTopLevelAttribute()
        {
            TestConversionCSharpToVisualBasic(
                @"[assembly: CLSCompliant(true)]",
                @"<Assembly: CLSCompliant(True)>");
        }

        [Test]
        public void TestImports()
        {
            TestConversionCSharpToVisualBasic(
                @"using SomeNamespace;
using VB = Microsoft.VisualBasic;",
                @"Imports SomeNamespace
Imports VB = Microsoft.VisualBasic");
        }

        [Test]
        public void TestClass()
        {
            TestConversionCSharpToVisualBasic(@"namespace Test.@class
{
    class TestClass<T>
    {
    }
}", @"Namespace Test.[class]
    Class TestClass(Of T)
    End Class
End Namespace");
        }

        [Test]
        public void TestInternalStaticClass()
        {
            TestConversionCSharpToVisualBasic(@"namespace Test.@class
{
    internal static class TestClass
    {
    }
}", @"Namespace Test.[class]
    Friend Module TestClass
    End Module
End Namespace");
        }

        [Test]
        public void TestAbstractClass()
        {
            TestConversionCSharpToVisualBasic(@"namespace Test.@class
{
    abstract class TestClass
    {
    }
}", @"Namespace Test.[class]
    MustInherit Class TestClass
    End Class
End Namespace");
        }

        [Test]
        public void TestSealedClass()
        {
            TestConversionCSharpToVisualBasic(@"namespace Test.@class
{
    sealed class TestClass
    {
    }
}", @"Namespace Test.[class]
    NotInheritable Class TestClass
    End Class
End Namespace");
        }

        [Test]
        public void TestInterface()
        {
            TestConversionCSharpToVisualBasic(
                @"interface ITest : System.IDisposable
{
    void Test ();
}", @"Interface ITest
    Inherits System.IDisposable

    Sub Test()
End Interface");
        }

        [Test]
        public void TestEnum()
        {
            TestConversionCSharpToVisualBasic(
    @"internal enum ExceptionResource
{
    Argument_ImplementIComparable,
    ArgumentOutOfRange_NeedNonNegNum,
    ArgumentOutOfRange_NeedNonNegNumRequired,
    Arg_ArrayPlusOffTooSmall
}", @"Friend Enum ExceptionResource
    Argument_ImplementIComparable
    ArgumentOutOfRange_NeedNonNegNum
    ArgumentOutOfRange_NeedNonNegNumRequired
    Arg_ArrayPlusOffTooSmall
End Enum");
        }

        [Test]
        public void TestClassInheritanceList()
        {
            TestConversionCSharpToVisualBasic(
    @"abstract class ClassA : System.IDisposable
{
    abstract void Test();
}", @"MustInherit Class ClassA
    Implements System.IDisposable

    MustOverride Sub Test()
End Class");

            TestConversionCSharpToVisualBasic(
                @"abstract class ClassA : System.EventArgs, System.IDisposable
{
    abstract void Test();
}", @"MustInherit Class ClassA
    Inherits System.EventArgs
    Implements System.IDisposable

    MustOverride Sub Test()
End Class");
        }

        [Test]
        public void TestStruct()
        {
            TestConversionCSharpToVisualBasic(
    @"struct MyType : System.IComparable<MyType>
{
    void Test() {}
}", @"Structure MyType
    Implements System.IComparable(Of MyType)

    Sub Test()
    End Sub
End Structure");
        }

        [Test]
        public void TestDelegate()
        {
            TestConversionCSharpToVisualBasic(
                @"public delegate void Test();", 
                @"Public Delegate Sub Test()");
            TestConversionCSharpToVisualBasic(
                @"public delegate int Test();",
                @"Public Delegate Function Test() As Integer");
            TestConversionCSharpToVisualBasic(
                @"public delegate void Test(int x);",
                @"Public Delegate Sub Test(ByVal x As Integer)");
            TestConversionCSharpToVisualBasic(
                @"public delegate void Test(ref int x);",
                @"Public Delegate Sub Test(ByRef x As Integer)");
        }

        [Test]
        public void MoveImportsStatement()
        {
            TestConversionCSharpToVisualBasic("namespace test { using SomeNamespace; }",
                        @"Imports SomeNamespace

Namespace test
End Namespace");
        }

        [Test]
        public void ClassImplementsInterface()
        {
            TestConversionCSharpToVisualBasic("using System; class test : IComparable { }",
@"Class test
    Implements IComparable
End Class");
        }

        [Test]
        public void ClassImplementsInterface2()
        {
            TestConversionCSharpToVisualBasic("class test : System.IComparable { }",
@"Class test
    Implements System.IComparable
End Class");
        }

        [Test]
        public void ClassInheritsClass()
        {
            TestConversionCSharpToVisualBasic("using System.IO; class test : InvalidDataException { }",
@"Imports System.IO

Class test
    Inherits InvalidDataException
End Class");
        }

        [Test]
        public void ClassInheritsClass2()
        {
            TestConversionCSharpToVisualBasic("class test : System.IO.InvalidDataException { }",
@"Class test
    Inherits System.IO.InvalidDataException
End Class");
        }
    }
}
