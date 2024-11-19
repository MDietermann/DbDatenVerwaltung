using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DbDatenVerwaltung.Classes.DataBaseClasses;

public class DataBaseViewModel : INotifyPropertyChanged {
	public ObservableCollection<DataBaseTypeEnum> DbTypes { get; set; }
        
	private DataBaseTypeEnum _selectedDbType;
	public DataBaseTypeEnum SelectedDbType
	{
		get { return _selectedDbType; }
		set
		{
			_selectedDbType = value;
			OnPropertyChanged(nameof(SelectedDbType));
		}
	}

	public DataBaseViewModel()
	{
		DbTypes = new ObservableCollection<DataBaseTypeEnum>
		{
			DataBaseTypeEnum.MySQL,
			DataBaseTypeEnum.SQLServer,
			DataBaseTypeEnum.PostgreSQL,
			DataBaseTypeEnum.MariaDB
		};

		// Initiale Auswahl
		SelectedDbType = DbTypes[0];
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged(string name)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
