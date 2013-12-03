using System.Data.SqlClient;
using SQL.Entity.Interfaces;

namespace SQL {

	public class DatabaseSettings : IDatabaseSettings {
		public string ConnectionString { get; private set; }
		public string DatabaseName { get; private set; }

		public DatabaseSettings( string connection_string ) {
			var connection_string_builder = new SqlConnectionStringBuilder( connection_string );

			DatabaseName = connection_string_builder.InitialCatalog;
			ConnectionString = connection_string;
		}

		public DatabaseSettings( string database_name, string connection_string ) {
			DatabaseName = database_name;
			ConnectionString = connection_string;
		}
	}

}