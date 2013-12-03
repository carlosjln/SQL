using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using SQL.DSL;

namespace SQL.Extensions {

	public static class sql_data_reader_extensions {

		public static GetColumnExtensionChain get_column( this SqlDataReader reader, string column_name ) {
			return new GetColumnExtensionChain(reader, column_name);
		}

		public static string[] get_column_names( this SqlDataReader reader ) {
			var field_count = reader.FieldCount;
			var column_names = new string[field_count];
			var schema = reader.GetSchemaTable();

			if (schema == null) return null;

			// STORE COLUMN NAMES
			for( var i = 0; i < field_count; i++ ){
				column_names[i] = schema.Rows[i]["ColumnName"].ToString();
			}

			return column_names;
		}

//		public static BsonDocument as_bson_document(this SqlDataReader reader) {
//			var bson_document = new BsonDocument();
//			var field_count = reader.FieldCount;
//			var schema = reader.GetSchemaTable();
//
//			for( var i = 0; i < field_count; i++) {
//				if(schema != null) {
//					bson_document.Add( schema.Columns[i].ColumnName, reader[i] as BsonString);
//				}
//			}
//			
//			reader.Close();
//
//			return bson_document;
//		}

		
		// TODO: MUST TEST THIS IF EVER NEEDED AGAIN
		public static string as_json_string( this SqlDataReader reader, bool get_one ) {
			var field_count = reader.FieldCount;
			var column_names = reader.get_column_names();
			int columns;

			if (reader.HasRows == false || reader.Read() == false || column_names == null) return null;
			
			var array = new ArrayList();
			do {
				var row = new Dictionary<string, object>();
				columns = 0;

				while( columns < field_count ) {
					row.Add( column_names[ columns ], reader[columns] );
					columns++;
				}

				array.Add( row );

			} while( reader.Read() );


			reader.Close();
			reader.Dispose();

			var serializer = new JavaScriptSerializer();

			return serializer.Serialize( get_one ? array[0] : array );
		}

		public static string as_json_string( this SqlDataReader reader ) {
			return as_json_string( reader, false );
		}


	}

}