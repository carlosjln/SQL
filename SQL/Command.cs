using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SQL.Extensions;

namespace SQL {

	public class Command {
		public SqlCommand Object { get; protected set; }

		// SQL COMMAND
		public Command( string stored_procedure, SqlConnection connection ) {
			Object = new SqlCommand {
				CommandType = CommandType.StoredProcedure,
				Connection = connection,
				CommandText = stored_procedure
			};
		}

		public Command( string stored_procedure ) {
			Object = new SqlCommand {
				CommandType = CommandType.StoredProcedure,
				CommandText = stored_procedure
			};
		}

		public void AddParameter( SqlParameter sql_parameter ) {
			Object.add_parameter( sql_parameter );
		}

		// EXPERIMENT
		public void AddParameter( string name, object value, SqlDbType type, ParameterDirection direction ) {
			var parameter = new SqlParameter {
				ParameterName = name,
				Value = value,
				SqlDbType = type,
				Direction = direction
			};

			AddParameter( parameter );
		}

		public void AddParameter( string name, string value ) {
			AddParameter( name, value, SqlDbType.NVarChar, ParameterDirection.Input );
		}

		public void AddParameter( string name, int value ) {
			AddParameter( name, value, SqlDbType.Int, ParameterDirection.Input );
		}

		public void AddParameter( string name, bool value ) {
			AddParameter( name, value ? 1 : 0, SqlDbType.TinyInt, ParameterDirection.Input );
		}

		public void AddParameter( string name, object value ) {
			var parameter = new SqlParameter {
				ParameterName = name,
				Value = value,
				Direction = ParameterDirection.Input
			};

			AddParameter( parameter );
		}
		
		public void AddParameters( IEnumerable<SqlParameter> sql_parameters ) {
			Object.add_parameters( sql_parameters );
		}

		public void ParseParameters( object source ) {
			Object.parse_parameters( source );
		}
	}

}