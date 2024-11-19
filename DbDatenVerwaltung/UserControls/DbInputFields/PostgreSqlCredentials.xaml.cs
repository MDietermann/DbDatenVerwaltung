using System.Windows.Controls;

namespace DbDatenVerwaltung.UserControls.DbInputFields;

public partial class PostgreSqlCredentials : UserControl {
	public PostgreSqlCredentials() {
		InitializeComponent();
	}
	
	public Grid GetContainer() {
		return CredentialsContainer;
	}
}

