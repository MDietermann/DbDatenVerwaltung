using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using DbDatenVerwaltung.Classes.DataBaseClasses;
using DbDatenVerwaltung.Classes.JsonHandler;

namespace DbDatenVerwaltung.UserControls;

public partial class MainControls {
	private readonly MainWindow _parentWindow;
	public List<UserControl> UserControls { get; set; }
	public MainControls(MainWindow parentWindow) {
		_parentWindow = parentWindow;
		
		InitializeComponent();
		LoadDatabases();
	}
	
	public void LoadDatabases() {
		SavedDatabases.DataContext = GetSavedDatabaseEntries();
	}
	
	private ObservableCollection<SavedDatabaseEntry> GetSavedDatabaseEntries() {
		ObservableCollection<SavedDatabaseEntry> savedDatabaseEntries = [];
		foreach (KeyValuePair<string, Dictionary<string, string>> savedDictionary in SaveLoadHandler.Deserialize()) {
			savedDatabaseEntries.Add(new SavedDatabaseEntry() {
				Name = savedDictionary.Key,
				DbValues = savedDictionary.Value
			});
		}
		return savedDatabaseEntries;
	}

	private void StartImportButton_OnClick(object          sender,
										   RoutedEventArgs e) {
		throw new NotImplementedException();
	}

	private void StartExportButton_OnClick(object          sender,
										   RoutedEventArgs e) {
		_parentWindow.LoadUserControl("Export");
	}

	private void AddDatabaseButton_OnClick(object          sender,
										   RoutedEventArgs e) {
		_parentWindow.LoadUserControl("AddDb");
	}

	private void SavedDatabases_OnSelectionChanged(object                    sender,
												   SelectionChangedEventArgs e) {
		Console.WriteLine($"Selection Changed{SavedDatabases.SelectedItems}");
	}
}

