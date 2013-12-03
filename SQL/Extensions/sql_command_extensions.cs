using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace SQL.Extensions {

	public static class sql_command_extensions {

		public static SqlCommand add_parameter( this SqlCommand command, SqlParameter parameter ) {
			command.Parameters.Add( parameter );
			return command;
		}

		public static SqlCommand add_parameters( this SqlCommand command, IEnumerable<SqlParameter> parameters ) {
			var command_parameters = command.Parameters;
			
			foreach( var parameter in parameters ) {
				command_parameters.Add( parameter );
			}

			return command;
		}

		public static SqlCommand parse_parameters( this SqlCommand command, object source ) {
			var command_parameters = command.Parameters;
			
			var properties = source.GetType().GetProperties( BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy );
			var source_type = source.GetType();
			
			// The entity's unique identifier is added here because the previous flags only detect the declared properties
			// and we dont want to be declaring the guid on every entity
			// command_parameters.Add( Create.Parameter( "@id", source.Id ) );
			
			// TODO: ensure that the list of properties correspond the the actual object
			// and that there's an Id field

			foreach(var property in properties){
				var property_type = property.PropertyType;
				var property_name = property.Name;

				var property_info =  source_type.GetProperty( property.Name );
				var property_value =  property_info.GetValue( source, null );
				
				var value = Convert.ChangeType( property_value, Nullable.GetUnderlyingType(property_type) ?? property_type);
				
				if(value == null) continue;

				command_parameters.Add( Create.Parameter( "@" + property_name, value ) );
			}

			return command;
		}

		// REMOVES COMMAND PARAMETERS
		public static SqlCommand release_parameters( this SqlCommand command ) {
			var parameters = command.Parameters;

			var i = 0;
			var length = parameters.Count;

			while( i < length ) {
				var parameter = parameters[i];
				parameters.Remove( parameter );
				i++;
			}

			return command;
		}

	}

}