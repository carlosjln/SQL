using System;
using System.Data.SqlClient;

namespace SQL.DSL {

	public class GetColumnExtensionChain {
		private readonly SqlDataReader reader;
		private readonly string column_name;

		public GetColumnExtensionChain(SqlDataReader reader, string column_name) {
			this.reader = reader;
			this.column_name = column_name;
		}

		public string as_string() {
			var ordinal = reader.GetOrdinal(column_name);
			return reader.IsDBNull(ordinal) ? string.Empty : reader.GetString(ordinal);
		}

		public Boolean as_boolean(bool default_value = false) {
			var ordinal = reader.GetOrdinal(column_name);
			return reader.IsDBNull(ordinal) ? default_value : Convert.ToBoolean( reader[ordinal] );
		}
		
		public Int32 as_int32(Int32 default_value = 0) {
			var ordinal = reader.GetOrdinal(column_name);
			return reader.IsDBNull(ordinal) ? default_value : reader.GetInt32(ordinal);
		}

		public Int16 as_int16(Int16 default_value = 0) {
			var ordinal = reader.GetOrdinal(column_name);
			return reader.IsDBNull(ordinal) ? default_value : reader.GetInt16(ordinal);
		}

		public DateTimeOffset as_datetime_offset(DateTimeOffset default_value = default(DateTimeOffset)) {
			var ordinal = reader.GetOrdinal(column_name);
			return reader.IsDBNull(ordinal) ? default_value : reader.GetDateTime(ordinal);
		}

		public DateTime as_datetime(DateTime default_value = default(DateTime)) {
			var ordinal = reader.GetOrdinal(column_name);
			return reader.IsDBNull(ordinal) ? default_value : reader.GetDateTime(ordinal);
		}

		public Int32 as_byte(Int32 default_value = 0) {
			var ordinal = reader.GetOrdinal(column_name);
			return reader.IsDBNull(ordinal) ? default_value : reader.GetByte(ordinal);
		}
	}

}