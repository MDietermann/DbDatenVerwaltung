using System.IO;
using System.Text.Json;

namespace DbDatenVerwaltung.Classes.JsonHandler;

public static class SaveLoadHandler {
	public static void Serialize(Dictionary<string, string> data) {
		string path                 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		string dataPersistDirectory = $@"{path}\DB_Datenverwaltung\data\db_data.json";
		
		Dictionary<string, Dictionary<string, string>>? jsonObject = Deserialize();
		if (!jsonObject.ContainsKey(data["Name"])) {
			jsonObject[data["Name"]] = data;
		}

		string jsonContent = JsonSerializer.Serialize(jsonObject);
		File.WriteAllText(dataPersistDirectory, jsonContent);
	}
	
	public static Dictionary<string, Dictionary<string, string>> Deserialize() {
		string path                 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		string dataPersistDirectory = $@"{path}\DB_Datenverwaltung\data\db_data.json";

		string jsonContent = File.ReadAllText(dataPersistDirectory);
		if (jsonContent == "")
			jsonContent = "{}";
		Dictionary<string, Dictionary<string, string>>? jsonObject =
			JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonContent)
			?? new Dictionary<string, Dictionary<string, string>>();

		return jsonObject;
	}
}
