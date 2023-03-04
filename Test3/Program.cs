using System.Data;
using System.Data.Common;

namespace Test3
{
    public class ConnectionOpen<T> where T : DbConnection
    {
        public void OpenConnection(T type)
        {
            type.Open();
        }
    }
    public static class exampleClass
    {
        public static void DoShit()
        {
            Console.WriteLine("Shit");
        }
    }
    internal class Obsoleted
    {
        internal void obsoleteMethod()
        {
            Console.WriteLine("method called");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            exampleClass.DoShit();
            ConnectionOpen<DbConnection> open = new ConnectionOpen<DbConnection>();
        }
    }
}