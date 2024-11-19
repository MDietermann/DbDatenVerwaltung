using System.Collections.Specialized;

namespace DbDatenVerwaltung.Classes.DataBaseClasses;

public class SavedDatabaseEntry {
	public string                                     Name     { get; set; }
	public Dictionary<string, string>                 DbValues { get; set; }
}
