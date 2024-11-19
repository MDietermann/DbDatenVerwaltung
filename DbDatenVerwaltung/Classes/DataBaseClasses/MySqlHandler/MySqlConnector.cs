using System.Collections;
using System.Windows.Controls;

namespace DbDatenVerwaltung.Classes.DataBaseClasses.MySqlHandler;

using MySql.Data;
using MySql.Data.MySqlClient;

public class MySqlConnector : IConnector {
	public MySqlConnector(Dictionary<string, string> inputData = null) {
		if (inputData != null)
			_connectionString = BuildConnectionString(inputData);
	}

	private          string? Server   { get; set; }
	private          string? Port     { get; set; }
	private          string? Database { get; set; }
	private          string? User     { get; set; }
	private          string? Password { get; set; }
	private readonly string? _connectionString;

	public MySqlConnection? Connection { get; set; }

	private static MySqlConnector? _instance = null;

	public static MySqlConnector Instance(Dictionary<string, string> inputData = null) {
		return _instance ?? new MySqlConnector(inputData);
	}

	public string BuildConnectionString(Dictionary<string, string> inputData) {
		
		Server = inputData["Server"];
		Database = inputData["Database"];
		User = inputData["User"];
		Password = inputData["Password"];
		Port = inputData["Port"];

		return $"Server={Server}; " +
			   $"database={Database}; " +
			   $"UID={User}; " +
			   $"password={Password}; " +
			   $"port={Port}";
	}

	public bool IsConnected() {
		if (Connection == null) {
			if (string.IsNullOrEmpty(Database))
				return false;
			Connection = new MySqlConnection(_connectionString);
			Connection.Open();
		}
		else if (Connection.State == System.Data.ConnectionState.Closed) {
			Connection.Open();
		}

		return true;
	}

	public bool TestConnection() {
		bool connectionSuccessful = IsConnected();
		Close();
		return connectionSuccessful;
	}

	public void Close() {
		if (Connection != null)
			Connection.Close();
	}
}
