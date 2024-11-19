using System.Windows.Controls;

namespace DbDatenVerwaltung.UserControls.ExportControls;

public partial class ExportControls : UserControl {
	
	private readonly List<string> exportFormats = new() {
		"CSV",
		"JSON",
		"XML"
	};
	
	public ExportControls() {
		InitializeComponent();
		DataContext = exportFormats;
		formatSeletor.ItemsSource = exportFormats;
	}
}

