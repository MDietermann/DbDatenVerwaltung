   M S B A M L   `   `   `  ����  DbDatenVerwaltung1    +DbDatenVerwaltung.UserControls.MainControls   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��950��5      $
��Auto��5      .��5	      �   � 	Resources  5   
      DeleteButtonTemplate �� RelativeSource �� AncestorType �� 
TargetType �� Property �� Value��%�  &	        �� 5      .R�5      �� $��Delete��6   $��16(�5      $��0q�5      $��0q�5      ��5      �� *DataContext.DeleteCommand+ ��  DataGrid��5      �� ��5      �� 5      " ��6    .�5      ��  � ��
 ���� 6;   �� 5       � ��
 �  ��6;   �� 5       � ��
 �  ��6<   �� 5       � ��$ 1q�6@   5      5      5      5       � RowDefinitions 5   
   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   .+�5%   
   �� -   5         ��Name$ DataBaseView��5%      $��1��5&      ._�5'      �� .+�5(      &   System.Windows.Controls.DataGrid  -   5          Name$ SavedDatabases��5(      	   AutoGenerateColumns$	 False��5)      "
   VerticalScrollBarVisibility$

 Auto=�5*      $   HorizontalScrollBarVisibility$
 Auto=�5+         CanUserAddRows$ False��5,         CanUserDeleteRows$ False��5-         SelectionMode$ Extended=�5.         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 5/         
IsReadOnly$
 True��50      ��51      ��   53      *  $System.Windows.Controls.DataGridCell=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '        '  L     �� 54      "  6    .�55      ��  � ��$ Center=�6B   56      �� 57      "  6    .�58      ��  � ��$ 16(�69   �� 59       � ��$
 Bold"�6;   5:      5;         Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$ Connection-Name��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5>   -   �� *Name+  5A      $ Database��6-    5B   -   �� *DbValues[Database]+  5C      $
 Type��6-    5D   -   �� *DbValues[Type]+  5E      $ Weitere Änderungen��6-   4  .System.Windows.Controls.DataGridTemplateColumn  5F      $ Delete��61      CellTemplate# [  5G   1   5I      �� 5K      -   5         ��Name$ AddDatabaseButton��5K        SmallButtonStyle#��[ 5L      $��Add Database��5M      5N      5O      5P      �� 5S   
   -   5        $ SelectionView��5S      $��0��6   $��0��65   ._�5T      �  5U      �� 5V      $��* �6$   �� 5W      $��2* �6$   .+�5[      �� $��0��6   $��24(�5\      $
��Bold"�5]      $��Auswahlmenü��5^      �� 5a      $��1��6   .+�5b      �� -   5        $ StartImportButton��5b      $��Importieren��5d      �� 5f      -   5        $ StartExportButton��5f      $��Exportieren��5h      5i      5j      5k      5l      5m      