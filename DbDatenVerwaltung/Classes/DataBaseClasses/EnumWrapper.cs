namespace DbDatenVerwaltung.Classes.DataBaseClasses;

public class EnumWrapper
{
	public static IEnumerable<DataBaseTypeEnum> DatabaseTypes => Enum.GetValues(typeof(DataBaseTypeEnum)).Cast<DataBaseTypeEnum>();
}

