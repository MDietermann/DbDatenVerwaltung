using System.IO;
using System.Windows;
using System.Windows.Controls;
using DbDatenVerwaltung.UserControls;
using DbDatenVerwaltung.UserControls.ExportControls;

namespace DbDatenVerwaltung;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow {
	public MainWindow() {
		CreateInstallPathStrings();
		InitializeComponent();
		LoadUserControl("Main");
	}

	public void LoadUserControl(string userControlName) {
		WindowContent.Child = userControlName switch {
			"Main"   => new MainControls(this),
			"AddDb"  => new AddDbControls(this),
			"Export" => new ExportControls(),
			_        => throw new ArgumentOutOfRangeException(nameof(userControlName), userControlName, null)
		};
	}

	private void CreateMissingDirectory(string path) {
		if (Directory.Exists(path)) {
			Console.WriteLine("ERROR: Directory " + path + " already exists.");
		}

		Directory.CreateDirectory(path);
		Console.WriteLine("Directory " + path + " created.");
	}

	private void CreateMissingFile(string path) {
		if (File.Exists(path)) {
			Console.WriteLine("ERROR: File " + path + " already exists.");
			return;
		}

		File.Create(path);
		Console.WriteLine("File " + path + " created.");
	}

	private void CreateInstallPathStrings() {
		// Pathing
		string mainPath        = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\DB_Datenverwaltung";
		string dataPersistPath = $"{mainPath}\\data";

		// Create Paths
		CreateMissingDirectory(mainPath);
		CreateMissingDirectory(dataPersistPath);

		// Files
		string dataPersistFile = $@"{dataPersistPath}\db_data.json";

		// Create Files
		CreateMissingFile(dataPersistFile);
	}
}
