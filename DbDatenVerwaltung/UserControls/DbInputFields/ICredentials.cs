using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace DbDatenVerwaltung.UserControls.DbInputFields;

public interface ICredentials {
	public static T GetChildOfType<T>(DependencyObject depObj) 
		where T : DependencyObject
	{
		if (depObj == null) return null;

		for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
		{
			DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

			T? result = (child as T) ?? GetChildOfType<T>(child);
			if (result != null) return result;
		}
		return null;
	}

	public Dictionary<string, string> GetCredentials();
	public Border                     GetConnectionValidBorder();
	public void ClearFields();
}