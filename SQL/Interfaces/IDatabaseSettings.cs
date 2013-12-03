namespace SQL.Entity.Interfaces {

	public interface IDatabaseSettings {
		string ConnectionString { get; }
		string DatabaseName { get; }
	}

}