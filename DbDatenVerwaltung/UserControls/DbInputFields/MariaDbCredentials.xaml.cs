using System.Windows.Controls;

namespace DbDatenVerwaltung.UserControls.DbInputFields;

public partial class MariaDbCredentials : UserControl {
	public MariaDbCredentials() {
		InitializeComponent();
	}
	
	public Grid GetContainer() {
		return CredentialsContainer;
	}

	public void ClearFields() {
		throw new NotImplementedException();
	}
}

