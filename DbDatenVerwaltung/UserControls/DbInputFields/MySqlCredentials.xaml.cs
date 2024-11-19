using System.Windows.Controls;
using System.Windows.Media;

namespace DbDatenVerwaltung.UserControls.DbInputFields;

public partial class MySqlCredentials : UserControl, ICredentials {
	private readonly AddDbControls _addDbControls;

	public MySqlCredentials(AddDbControls addDbControls) {
		_addDbControls = addDbControls;
		InitializeComponent();
	}

	public Dictionary<string, string> GetCredentials() {
		return new Dictionary<string, string>() {
			{ "Server", ServerTextBox.Text },
			{ "Database", DatabaseTextBox.Text },
			{ "User", UserTextBox.Text },
			{ "Password", PasswordBox.Password },
			{ "Port", PortTextBox.Text }
		};
	}

	public Border GetConnectionValidBorder() {
		return ConnectionShow;
	}

	public void ClearFields() {
		ServerTextBox.Text        = "";
		DatabaseTextBox.Text      = "";
		UserTextBox.Text          = "";
		PasswordBox.Password      = "";
		PortTextBox.Text          = "";
		ConnectionShow.Background = new SolidColorBrush(Colors.Yellow);
		ConnectionText.Text       = "Waiting for Connection-Test";
	}
}
