   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5           Client.Views.KorisniciView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  65       
IsReadOnly  .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6  $	��199��6  $��	10,55,0,0q�6*  $	��Top=�6=  $	��690��6U  ��6   �� *	korisnici+ �� SelectedValue 6�   �� *Selektovani_korisnik+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID korisnika��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6;   �� *
id_usera+6X     5      $ Korisnicko ime��6%   $ * 6`   	 6=   �� *username_usera+6`     5      $ Klasa naloga��6%   $ * 6Z   	 6;   �� *
role_usera+6Z   5      �� 5   
   $��Obrisi Korisnika��6     RoundButton#��[ 6-   $
��Left=�6�   $��50��6�   $��
23,268,0,0q�6�   $	��Top=�6�   $	��142��6	  y�6R   �� *
Visibility+��6t   �� *DeleteCommand+{�6�   �� *	CanDelete+6	  5      5      