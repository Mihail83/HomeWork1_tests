using System;
using System.Collections.Generic;
using System.Text;

namespace HoveWork1_tests
{
    public interface IForMock1
    {
        int Method1_IForMock(int first);
    }
    public interface IWriter
    {
        void WriteLine(string message);
        string AddLine(string message);
    }

    public abstract class AbstractClasForMock
    {
        public abstract int MethodClasForMock(int min);
    }
    public class ClassForMock : AbstractClasForMock
    {
        public override int MethodClasForMock(int min)
        {
            return min;
        }
    }

    public class ClassForTestedMethods
    {
        int[] mass = new[] { 1, 2, 3, 4, 5 };
        public int PlusTen(IForMock1 a, int b)  //IForMock1
        {
            return a.Method1_IForMock(b) + 10;
        }
        public int Minus(AbstractClasForMock clasForMock, int number)   // ClasForMock
        {
            return clasForMock.MethodClasForMock(number) - 10;
        }
    }

    public class ClassForTestedMethods_Behaviour
    {
        IWriter _writer;
        public ClassForTestedMethods_Behaviour(IWriter messagewriter)
        {
            _writer = messagewriter;
        }
        public void WriteMessage(string message)
        {
            _writer.WriteLine(message);
        }
        public string AddLine(string message)
        {
            return _writer.AddLine(message) + "Line";
        }
    }
}
