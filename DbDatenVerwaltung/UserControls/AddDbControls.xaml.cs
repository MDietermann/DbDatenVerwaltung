using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DbDatenVerwaltung.Classes.DataBaseClasses;
using DbDatenVerwaltung.Classes.DataBaseClasses.MySqlHandler;
using DbDatenVerwaltung.Classes.JsonHandler;
using DbDatenVerwaltung.UserControls.DbInputFields;

namespace DbDatenVerwaltung.UserControls;

public partial class AddDbControls {
	private readonly MySqlCredentials      _mySqlCredentials;
	private readonly MariaDbCredentials    _mariaDbCredentials;
	private readonly PostgreSqlCredentials _postgreSqlCredentials;
	private readonly SqlServerCredentials  _sqlServerCredentials;
	private          Border                _connectionShow;
	private          MainWindow            _mainWindow;
	private          ICredentials?         _selectedCredentials;
	private          IConnector?           _connector;

	public AddDbControls(MainWindow mainWindow) {
		_mainWindow = mainWindow;
		InitializeComponent();

		_mySqlCredentials      = new MySqlCredentials(this);
		_sqlServerCredentials  = new SqlServerCredentials();
		_postgreSqlCredentials = new PostgreSqlCredentials();
		_mariaDbCredentials    = new MariaDbCredentials();

		SaveDatabase.IsEnabled = false;

		DataBaseViewModel model = new();
		DbTypeComboBox.ItemsSource   = model.DbTypes;
		DbTypeComboBox.SelectedIndex = 0;
	}

	private void DbTypeComboBox_SelectionChanged(object                    sender,
												 SelectionChangedEventArgs e) {
		if (DbTypeComboBox.SelectedIndex == -1) return;
		DataBaseTypeEnum selectedDbType = (DataBaseTypeEnum)DbTypeComboBox.SelectedIndex;

		DbCredentials.Child = selectedDbType switch {
			DataBaseTypeEnum.MySQL      => _mySqlCredentials,
			DataBaseTypeEnum.SQLServer  => _sqlServerCredentials,
			DataBaseTypeEnum.PostgreSQL => _postgreSqlCredentials,
			DataBaseTypeEnum.MariaDB    => _mariaDbCredentials,
			_                           => null
		};

		GetCredentials(selectedDbType);
		Console.WriteLine(selectedDbType);
	}


	private void GetCredentials(DataBaseTypeEnum dbType) {
		_selectedCredentials = dbType switch {
			DataBaseTypeEnum.MySQL      => _mySqlCredentials,
			DataBaseTypeEnum.SQLServer  => throw new NotImplementedException(), // TODO: implement _sqlServerCredentials
			DataBaseTypeEnum.PostgreSQL => throw new NotImplementedException(), // TODO: implement _postgreSqlCredentials
			DataBaseTypeEnum.MariaDB    => throw new NotImplementedException(), // TODO: implement _mariaDbCredentials
			_                           => null
		};
	}

	private void GetConnector(DataBaseTypeEnum           dbType,
							  Dictionary<string, string> conStringData) {
		_connector = dbType switch {
			DataBaseTypeEnum.MySQL      => MySqlConnector.Instance(conStringData),
			DataBaseTypeEnum.SQLServer  => throw new NotImplementedException(), // TODO: implement SqlServerConnector.Instance(conStringData),
			DataBaseTypeEnum.PostgreSQL => throw new NotImplementedException(), // TODO: implement PostgreSqlConnector.Instance(conStringData),
			DataBaseTypeEnum.MariaDB    => throw new NotImplementedException(), // TODO: implement MariaDbConnector.Instance(conStringData),
			_                           => throw new NotImplementedException()
		};
	}

	private void TestConnection_OnClick(object          sender,
										RoutedEventArgs e) {
		if (_selectedCredentials == null) return;

		_connectionShow            = _selectedCredentials.GetConnectionValidBorder();
		_connectionShow.Background = new SolidColorBrush(Colors.Yellow);
		Dictionary<string, string> conStringData = _selectedCredentials.GetCredentials();

		GetConnector((DataBaseTypeEnum)DbTypeComboBox.SelectedIndex, conStringData);

		if (_connector == null) throw new ArgumentNullException(nameof(_connector));

		Color     connectionSuccessColor = Colors.Red;
		string    connectionStateText    = "Connection failed!";
		TextBlock connectionText         = (TextBlock)_connectionShow.Child;
		connectionText.Text = "Trying to connect...";

		if (_connector.TestConnection()) {
			connectionSuccessColor = Colors.Green;
			connectionStateText    = "Connection successful!";
			SaveDatabase.IsEnabled = true;
		}

		_connectionShow.Background = new SolidColorBrush(connectionSuccessColor);
		connectionText.Text        = connectionStateText;
	}

	private void SaveDatabase_OnClick(object          sender,
									  RoutedEventArgs e) {
		Dictionary<string, string> persistData   = new();
		Dictionary<string, string> conStringData = _selectedCredentials!.GetCredentials();

		persistData.Add("Name", $"{conStringData["User"]}@{conStringData["Server"]}: {conStringData["Database"]}");
		persistData.Add("Database", conStringData["Database"]);
		persistData.Add("Type", DbTypeComboBox.SelectedValue.ToString() ?? "Unknown");
		if (_connector != null) persistData.Add("ConnectionString", _connector.BuildConnectionString(conStringData));

		SaveLoadHandler.Serialize(persistData);

		_selectedCredentials!.ClearFields();
	}

	private void Cancel_OnClick(object          sender,
								RoutedEventArgs e) {
		_mainWindow.LoadUserControl("Main");
	}
}
