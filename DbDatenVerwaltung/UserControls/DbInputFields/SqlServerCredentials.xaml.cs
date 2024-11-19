using System.Windows.Controls;

namespace DbDatenVerwaltung.UserControls.DbInputFields;

public partial class SqlServerCredentials : UserControl {
	public SqlServerCredentials() {
		InitializeComponent();
	}
	
	public Grid GetContainer() {
		return CredentialsContainer;
	}
}

