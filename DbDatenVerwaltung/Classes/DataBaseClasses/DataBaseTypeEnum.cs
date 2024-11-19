using System.ComponentModel;

namespace DbDatenVerwaltung.Classes.DataBaseClasses;

public enum DataBaseTypeEnum {
	[Description("MySQL")]
	MySQL,
    
	[Description("SQL Server")]
	SQLServer,
    
	[Description("PostgreSQL")]
	PostgreSQL,
    
	[Description("MariaDB")]
	MariaDB
}
