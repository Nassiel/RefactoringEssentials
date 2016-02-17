﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RefactoringEssentials.Tests.VB.Converter
{
    [TestFixture]
    public class StatementTests : ConverterTestBase
    {
        [Test]
        public void AssignmentStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int b;
        b = 0;
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer
        b = 0
    End Sub
End Class");
        }

        [Test]
        public void AssignmentStatementInDeclaration()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int b = 0;
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer = 0
    End Sub
End Class");
        }

        [Test]
        public void AssignmentStatementInVarDeclaration()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        var b = 0;
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b = 0
    End Sub
End Class");
        }

        [Test]
        public void ObjectInitializationStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        string b;
        b = new string(""test"");
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As String
        b = New String(""test"")
    End Sub
End Class");
        }

        [Test]
        public void ObjectInitializationStatementInDeclaration()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        string b = new string(""test"");
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As String = New String(""test"")
    End Sub
End Class");
        }

        [Test]
        public void ObjectInitializationStatementInVarDeclaration()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        var b = new string(""test"");
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b = New String(""test"")
    End Sub
End Class");
        }

        [Test]
        public void ArrayDeclarationStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[] b;
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer()
    End Sub
End Class");
        }

        [Test]
        public void ArrayInitializationStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[] b = { 1, 2, 3 };
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer() = {1, 2, 3}
    End Sub
End Class");
        }

        [Test]
        public void ArrayInitializationStatementInVarDeclaration()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        var b = { 1, 2, 3 };
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b = {1, 2, 3}
    End Sub
End Class");
        }

        [Test]
        public void ArrayInitializationStatementWithType()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[] b = new int[] { 1, 2, 3 };
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer() = New Integer() {1, 2, 3}
    End Sub
End Class");
        }

        [Test]
        public void ArrayInitializationStatementWithLength()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[] b = new int[3] { 1, 2, 3 };
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer() = New Integer(2) {1, 2, 3}
    End Sub
End Class");
        }

        [Test]
        public void MultidimensionalArrayDeclarationStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[,] b;
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer(,)
    End Sub
End Class");
        }

        [Test]
        public void MultidimensionalArrayInitializationStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[,] b = { { 1, 2 }, { 3, 4 } };
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer(,) = {{1, 2}, {3, 4}}
    End Sub
End Class");
        }

        [Test]
        public void MultidimensionalArrayInitializationStatementWithType()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[,] b = new int[,] { { 1, 2 }, { 3, 4 } };
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer(,) = New Integer(,) {{1, 2}, {3, 4}}
    End Sub
End Class");
        }

        [Test]
        public void MultidimensionalArrayInitializationStatementWithLengths()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[,] b = new int[2, 2] { { 1, 2 }, { 3, 4 } };
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer(,) = New Integer(1, 1) {{1, 2}, {3, 4}}
    End Sub
End Class");
        }

        [Test]
        public void JaggedArrayDeclarationStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[][] b;
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer()()
    End Sub
End Class");
        }

        [Test]
        public void JaggedArrayInitializationStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[][] b = { new int[] { 1, 2 }, new int[] { 3, 4 } };
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer()() = {New Integer() {1, 2}, New Integer() {3, 4}}
    End Sub
End Class");
        }

        [Test]
        public void JaggedArrayInitializationStatementWithType()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[][] b = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer()() = New Integer()() {New Integer() {1, 2}, New Integer() {3, 4}}
    End Sub
End Class");
        }

        [Test]
        public void JaggedArrayInitializationStatementWithLength()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int[][] b = new int[2][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer()() = New Integer(1)() {New Integer() {1, 2}, New Integer() {3, 4}}
    End Sub
End Class");
        }

        [Test]
        public void IfStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod (int a)
    {
        int b;
        if (a == 0) {
            b = 0;
        } else if (a == 1) {
            b = 1;
        } else if (a == 2 || a == 3) {
            b = 2;
        } else {
            b = 3;
        }
    }
}", @"Class TestClass
    Sub TestMethod(ByVal a As Integer)
        Dim b As Integer

        If a = 0 Then
            b = 0
        ElseIf a = 1 Then
            b = 1
        ElseIf a = 2 OrElse a = 3 Then
            b = 2
        Else
            b = 3
        End If
    End Sub
End Class");
        }

        [Test]
        public void WhileStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int b;
        b = 0;
        while (b == 0)
        {
            if (b == 2)
                continue;
            if (b == 3)
                break;
            b = 1;
        }
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer
        b = 0

        While b = 0
            If b = 2 Then Continue While
            If b = 3 Then Exit While
            b = 1
        End While
    End Sub
End Class");
        }

        [Test]
        public void DoWhileStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        int b;
        b = 0;
        do
        {
            if (b == 2)
                continue;
            if (b == 3)
                break;
            b = 1;
        }
        while (b == 0);
    }
}", @"Class TestClass
    Sub TestMethod()
        Dim b As Integer
        b = 0

        Do
            If b = 2 Then Continue Do
            If b = 3 Then Exit Do
            b = 1
        Loop While b = 0
    End Sub
End Class");
        }

        [Test]
        public void ForEachStatementWithExplicitType()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod(int[] values)
    {
        foreach (int val in values)
        {
            if (val == 2)
                continue;
            if (val == 3)
                break;
        }
    }
}", @"Class TestClass
    Sub TestMethod(ByVal values As Integer())
        For Each val As Integer In values
            If val = 2 Then Continue For
            If val = 3 Then Exit For
        Next
    End Sub
End Class");
        }

        [Test]
        public void ForEachStatementWithVar()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod(int[] values)
    {
        foreach (var val in values)
        {
            if (val == 2)
                continue;
            if (val == 3)
                break;
        }
    }
}", @"Class TestClass
    Sub TestMethod(ByVal values As Integer())
        For Each val In values
            If val = 2 Then Continue For
            If val = 3 Then Exit For
        Next
    End Sub
End Class");
        }

        [Test]
        public void SyncLockStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod(object nullObject)
    {
        if (nullObject == null)
            throw new ArgumentNullException(nameof(nullObject));
        lock (nullObject) {
            Console.WriteLine(nullObject);
        }
    }
}", @"Class TestClass
    Sub TestMethod(ByVal nullObject As Object)
        If nullObject Is Nothing Then Throw New ArgumentNullException(NameOf(nullObject))

        SyncLock nullObject
            Console.WriteLine(nullObject)
        End SyncLock
    End Sub
End Class");
        }

        [Test]
        public void ForWithUnknownConditionAndSingleStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        for (i = 0; unknownCondition; i++)
            b[i] = s[i];
    }
}", @"Class TestClass
    Sub TestMethod()
        i = 0

        While unknownCondition
            b(i) = s(i)
            i += 1
        End While
    End Sub
End Class");
        }

        [Test]
        public void ForWithUnknownConditionAndBlock()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        for (i = 0; unknownCondition; i++) {
            b[i] = s[i];
        }
    }
}", @"Class TestClass
    Sub TestMethod()
        i = 0

        While unknownCondition
            b(i) = s(i)
            i += 1
        End While
    End Sub
End Class");
        }

        [Test]
        public void ForWithSingleStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        for (i = 0; i < end; i++) b[i] = s[i];
    }
}", @"Class TestClass
    Sub TestMethod()
        For i = 0 To [end] - 1
            b(i) = s(i)
        Next
    End Sub
End Class");
        }

        [Test]
        public void ForWithBlock()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod()
    {
        for (i = 0; i < end; i++) {
            b[i] = s[i];
        }
    }
}", @"Class TestClass
    Sub TestMethod()
        For i = 0 To [end] - 1
            b(i) = s(i)
        Next
    End Sub
End Class");
        }

        [Test]
        public void LabeledAndForStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class GotoTest1
{
    static void Main()
    {
        int x = 200, y = 4;
        int count = 0;
        string[,] array = new string[x, y];

        for (int i = 0; i < x; i++)

            for (int j = 0; j < y; j++)
                array[i, j] = (++count).ToString();

        Console.Write(""Enter the number to search for: "");

        string myNumber = Console.ReadLine();

                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (array[i, j].Equals(myNumber))
                        {
                            goto Found;
                        }
                    }
                }

            Console.WriteLine(""The number {0} was not found."", myNumber);
            goto Finish;

        Found:
            Console.WriteLine(""The number {0} is found."", myNumber);

        Finish:
            Console.WriteLine(""End of search."");


            Console.WriteLine(""Press any key to exit."");
            Console.ReadKey();
        }
    }", @"Class GotoTest1
    Shared Sub Main()
        Dim x As Integer = 200, y As Integer = 4
        Dim count As Integer = 0
        Dim array As String(,) = New String(x - 1, y - 1) {}

        For i As Integer = 0 To x - 1

            For j As Integer = 0 To y - 1
                array(i, j) = (System.Threading.Interlocked.Increment(count)).ToString()
            Next
        Next

        Console.Write(""Enter the number to search for: "")
        Dim myNumber As String = Console.ReadLine()

        For i As Integer = 0 To x - 1

            For j As Integer = 0 To y - 1

                If array(i, j).Equals(myNumber) Then
                    GoTo Found
                End If
            Next
        Next

        Console.WriteLine(""The number {0} was not found."", myNumber)
        GoTo Finish
Found:
        Console.WriteLine(""The number {0} is found."", myNumber)
Finish:
        Console.WriteLine(""End of search."")
        Console.WriteLine(""Press any key to exit."")
        Console.ReadKey()
    End Sub
End Class");
        }

        [Test]
        public void ThrowStatement()
        {
            TestConversionCSharpToVisualBasic(@"
class TestClass
{
    void TestMethod(object nullObject)
    {
        if (nullObject == null)
            throw new ArgumentNullException(nameof(nullObject));
    }
}", @"Class TestClass
    Sub TestMethod(ByVal nullObject As Object)
        If nullObject Is Nothing Then Throw New ArgumentNullException(NameOf(nullObject))
    End Sub
End Class");
        }

        [Test]
        public void AddRemoveHandler()
        {
            TestConversionCSharpToVisualBasic(@"using System;

class TestClass
{
    public event EventHandler MyEvent;

    void TestMethod(EventHandler e)
    {
        this.MyEvent += e;
        this.MyEvent += MyHandler;
    }

    void TestMethod2(EventHandler e)
    {
        this.MyEvent -= e;
        this.MyEvent -= MyHandler;
    }

    void MyHandler(object sender, EventArgs e)
    {

    }
}", @"Class TestClass
    Public Event MyEvent As EventHandler

    Sub TestMethod(ByVal e As EventHandler)
        AddHandler Me.MyEvent, e
        AddHandler Me.MyEvent, AddressOf MyHandler
    End Sub

    Sub TestMethod2(ByVal e As EventHandler)
        RemoveHandler Me.MyEvent, e
        RemoveHandler Me.MyEvent, AddressOf MyHandler
    End Sub

    Sub MyHandler(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
End Class");
        }
    }
}
