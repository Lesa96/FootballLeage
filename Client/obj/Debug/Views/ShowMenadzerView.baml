   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5      #    Client.Views.ShowMenadzerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  65       
IsReadOnly  .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6  $	��199��6  $��	10,85,0,0q�6*  $	��Top=�6=  $	��780��6U  ��6   �� *	menadzeri+ �� SelectedValue 6�   �� *Selektovani_menadzer+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6S   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *M.id_menagera+6S     5      $ Ime Menadzera��6%   $ * 6_   	 6<   �� *M.ime_menagera+6_     5      $ Prezime Menadzera��6%   $ * 6g   	 6@   �� *M.prezime_menagera+6g     5      $ Drzava Menadzera��6%   $ * 6\   	 6?   �� *
M.drzava+6\   5      �� 5   
   $ ��Igraci kojima je menadzer:��6   
�������$
��Left=�6L   $��331,297,0,0q�6g   $	��Top=�6|   �� 5   
   
�������$
��Left=�6n   $��76��6�   $��331,328,0,0q�6�   $	��Top=�6�   $	��153��6�   ��6   �� *$"Selektovani_menadzer.Nazivi_igraca+$ TwoWay=�5      �� 5   
   $��Obrisi Menadzera��6     RoundButton#��[ 6-   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6	  y�6R   �� *
Visibility+��6t   �� *DeleteCommand+{�6�   �� *	CanDelete+6	  �� 5   
   $��Stampaj menadzere��6   #��[ 6O   $
��Left=�6t   $��50��6�   $��626,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6-   �� *IspisCommand+6�   5      5      