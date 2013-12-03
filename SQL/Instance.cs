using System.Data.SqlClient;
using SQL.DSL;
using SQL.Entity.Interfaces;

namespace SQL {

	public class Instance {
		public IDatabaseSettings settings;
		private SqlConnection Connection;

		// public DatabaseSettings DefaultDatabase {get; set;}
		public void Connect( IDatabaseSettings database_settings ) {
			settings = database_settings;
			Connection = new SqlConnection( database_settings.ConnectionString );
		}

		public CommandExecuteChain Execute( SqlCommand command ) {
			return new CommandExecuteChain( command, Connection );
		}

		public CommandExecuteChain Execute( Command command ) {
			return new CommandExecuteChain( command.Object, Connection );
		}
	}

}