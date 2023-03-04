using System.Data.Common;

namespace Practice.Core
{
    public abstract class DbBaseClass
    {
        public int Cenas = 0;
        public int ConnectionString;
        public DbConnection? connection;
        public virtual void openConnection() {
            connection?.Open();
        }
        public virtual void CloseConnection() { 
            connection?.Close();
        }
        
    }

    public interface DbInterface1
    {
        public int Cenas { get; set; }
        public int ConnectionString { get; set; }
        public DbConnection? connection { get; set; }
        public void openConnection();

    }

    public interface DbInterface2
    {
        public int Cenas { get;}

    }


    public class MongoDbClass : DbBaseClass
    {
        public override void openConnection()
        {
            var transaction = connection?.BeginTransaction();
            connection?.Open();
        }
    }

    public class MysqlDbClass : DbBaseClass, DbInterface1, DbInterface2
    {
        int DbInterface1.Cenas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int DbInterface1.ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbConnection? DbInterface1.connection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        int DbInterface2.Cenas => throw new NotImplementedException();

        public override void openConnection()
        {
            var transaction = connection?.BeginTransaction();
            connection?.Open();
        }
        public override void CloseConnection()
        {
            base.CloseConnection();
        }
    }


    public class Class2
    {
        public int Cenas = 0;

    }

    [Obsolete("do not use")]
    public class Execucao
    {
        [Obsolete("mensagem custom")]
        public void CriarLog()
        {
            
        }
    }
}