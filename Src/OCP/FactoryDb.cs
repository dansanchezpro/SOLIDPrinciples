namespace OCP
{
    public interface IDb
    {
        string TellTye();
    }
    public class SQLServerDb : IDb
    {
        readonly string connectionString;
        public SQLServerDb(string connectionString) => this.connectionString = connectionString;
        public string TellTye() => $"Type: SQLServer, Connection string: {connectionString}";
    }
    public class MySQLDb : IDb
    {
        readonly string connectionString;
        public MySQLDb(string connectionString) => this.connectionString = connectionString;
        public string TellTye() => $"Type: MySQL, Connection string: {connectionString}";
    }

    public interface IFactoryDb
    {
        string Type { get; }
        IDb Create();
    }
    public class SqlServerFactoryDb : IFactoryDb
    {
        public string Type => "SQLServer";
        readonly string connectionString;
        public SqlServerFactoryDb(string connectionString) => this.connectionString = connectionString;
        public IDb Create() => new SQLServerDb(connectionString);
    }
    public class MySQLFactoryDb : IFactoryDb
    {
        public string Type => "MySQL";
        readonly string connectionString;
        public MySQLFactoryDb(string connectionString) => this.connectionString = connectionString;
        public IDb Create() => new MySQLDb(connectionString);
    }
    public class FactoryService
    {
        public IEnumerable<IFactoryDb> Factories { get; private set; }
        public FactoryService(IEnumerable<IFactoryDb> factories) => Factories = factories;
        public IDb Crear(string type)
        {
            var factory = Factories.FirstOrDefault(f => f.Type.Equals(type));
            if (factory == null) { throw new InvalidOperationException($"Invalid type: {type}"); }
            return factory.Create();
        }
    }
}
