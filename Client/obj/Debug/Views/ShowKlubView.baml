   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5          Client.Views.ShowKlubView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  63      
IsReadOnly .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6�   $	��199��6  $��	10,85,0,0q�6$  $	��Top=�67  $	��780��6O  ��6   �� *	klubovi+ �� SelectedValue 6�   �� *Selektovana_klub+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv kluba��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6V   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6:   �� *	K.naziv+6V     5      $ 
Grad kluba��6%   $	 * 6T   
 69   �� *K.grad+6T     5      $
 Liga��6%   $	 * 6R   
 63   �� *
Naziv_lige+6R     5      $ Trener��6%   $	 * 6P   
 65   �� *Trener+6P     5      $ Navijaci��6%   $	 * 6Y   
 67   �� *Broj_Navijaca+6Y     5      $ Vrednost kluba ($)��6%   $	 * 6`   
 6A   �� *
K.vrednost+6`     5      $ Starost igraca��6%   $	 * 6b   
 6=   �� *Prosecna_Starost+6b   5      �� 5   
   $��Obrisi klub��6     RoundButton#��[ 6(   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6  y�6M   �� *
Visibility+��6o   �� *DeleteCommand+{�6�   �� *	CanDelete+6  �� 5   
   $��Stampaj klubove��6   #��[ 6M   $
��Left=�6r   $��50��6�   $��626,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6+   �� *IspisCommand+6�   5      5      