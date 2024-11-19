using System.Windows.Controls;

namespace DbDatenVerwaltung.Classes.DataBaseClasses.MySqlHandler;

public interface IConnector {
	public string BuildConnectionString(Dictionary<string, string> inputGrids);
	public bool IsConnected();
	public bool TestConnection();
	public void Close();
}
