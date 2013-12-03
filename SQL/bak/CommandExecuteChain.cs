using System;
using System.Data;
using System.Data.SqlClient;

namespace SQL.Entity {

	public class CommandExecuteChain {
		private readonly SqlConnection default_connection;
		private SqlCommand command { get; set; }

		public CommandExecuteChain( SqlCommand command, SqlConnection connection = null ) {
			default_connection = connection;
			this.command = command;

			if( default_connection !=null && command.Connection == null ) {
				command.Connection = default_connection;
			}
		}

		public SqlDataReader select( ) {
			command.Connection.Open();
			return command.ExecuteReader( CommandBehavior.SingleResult & CommandBehavior.CloseConnection );
		}

		// TODO: review if this needs to return null or if it could return the empty reader
		public SqlDataReader select_first() {
			var has_rows = false;
			command.Connection.Open();

			var reader = command.ExecuteReader( CommandBehavior.SingleRow & CommandBehavior.CloseConnection );
			
			if( reader.HasRows && reader.Read() ) {
				has_rows = true;
			}
			
			return has_rows? reader : null;
		}
		
		public Int32 scalar( ) {
			var connection = command.Connection;
			connection.Open();

			var scalar = ( Int32 ) command.ExecuteScalar();

			command.Dispose();
			connection.Close();

			return scalar;
		}
	}

}