using System.Data;
using System.Data.SqlClient;

namespace SQL {

	public class Create {
		public static SqlParameter Parameter(string name, object value, SqlDbType type, ParameterDirection direction) {
			return new SqlParameter {ParameterName = name, Value = value, SqlDbType = type, Direction = direction};
		}

		public static SqlParameter Parameter(string name, string value) {
			return Parameter(name, value, SqlDbType.NVarChar, ParameterDirection.Input);
		}

		public static SqlParameter Parameter(string name, int value) {
			return Parameter(name, value, SqlDbType.Int, ParameterDirection.Input);
		}

		public static SqlParameter Parameter(string name, bool value) {
			return Parameter(name, value ? 1 : 0, SqlDbType.TinyInt, ParameterDirection.Input);
		}
		
		public static SqlParameter Parameter(string name, object value) {
			return new SqlParameter {ParameterName = name, Value = value, Direction = ParameterDirection.Input};;
		}
	}

}