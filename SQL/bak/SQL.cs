using System.Data.SqlClient;
using SQL.Entity;
using SQL.Entity.Interfaces;

namespace SQL {

	// TODO: Review this query based implementation if needed later
	public class Instance {
		public Settings settings;
		private SqlConnection Connection;

		// public DatabaseSettings DefaultDatabase {get; set;}
		public void Connect( IDatabaseSettings database_settings ) {
			Connection = new SqlConnection( database_settings.ConnectionString );
		}

		public CommandExecuteChain Execute( SqlCommand command ) {
			return new CommandExecuteChain( command, Connection );
		}
	}

}