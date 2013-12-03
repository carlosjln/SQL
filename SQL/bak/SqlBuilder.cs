using System;
using System.Data;
using System.Data.SqlClient;

namespace SQL.Entity {

	public class Create {
		// SQL COMMAND
		public static SqlCommand Command( string stored_procedure, SqlConnection connection ) {
			var command = new SqlCommand {
				CommandType = CommandType.StoredProcedure,
				Connection = connection,
				CommandText = stored_procedure
			};
			
			return command;
		}
	}

	public class SQLBuilder {

		// SQL COMMAND
		public SqlCommand Command( string stored_procedure, SqlConnection connection ) {
			var command = new SqlCommand {
				CommandType = CommandType.StoredProcedure,
				Connection = connection,
				CommandText = stored_procedure
			};
			
			return command;
		}
		
		public SqlCommand Command( string stored_procedure ) {
			var command = new SqlCommand {
				CommandType = CommandType.StoredProcedure,
				CommandText = stored_procedure
			};
			
			return command;
		}
		
		public SqlCommand Command(Action<SqlCommand> action) {
			var command = new SqlCommand { CommandType = CommandType.StoredProcedure };
			action(command);
			
			return command;
		}

		// SQL PARAMETER
		public SqlParameter Parameter(string name, object value, SqlDbType type, ParameterDirection direction) {
			return new SqlParameter {ParameterName = name, Value = value, SqlDbType = type, Direction = direction};
		}

		public SqlParameter Parameter(string name, string value) {
			return Parameter(name, value, SqlDbType.NVarChar, ParameterDirection.Input);
		}

		public SqlParameter Parameter(string name, int value) {
			return Parameter(name, value, SqlDbType.Int, ParameterDirection.Input);
		}

		public SqlParameter Parameter(string name, bool value) {
			return Parameter(name, value ? 1 : 0, SqlDbType.TinyInt, ParameterDirection.Input);
		}
		
		public SqlParameter Parameter(string name, object value) {
			return new SqlParameter {ParameterName = name, Value = value, Direction = ParameterDirection.Input};;
		}
	}
}