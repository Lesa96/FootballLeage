   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5      "    Client.Views.ShowVlasnikView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  64       
IsReadOnly  .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6   $	��199��6  $��	10,85,0,0q�6(  $	��Top=�6;  $	��780��6S  ��6   �� *
vlasnici+ �� SelectedValue 6�   �� *Selektovani_vlasnik+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6S   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *V.id_vlasnika+6S     5      $ Ime Vlasnika��6%   $ * 6^   	 6;   �� *V.ime_vlasnika+6^     5      $ Prezime Vlasnika��6%   $ * 6f   	 6?   �� *V.prezime_vlasnika+6f     5      $ Drzava Vlasnika��6%   $ * 6[   	 6>   �� *
V.drzava+6[   5      �� 5   
   $��Klubovi ciji je vlasnik:��6   
�������$
��Left=�6J   $��331,297,0,0q�6e   $	��Top=�6z   �� 5   
   
�������$
��Left=�6n   $��76��6�   $��331,328,0,0q�6�   $	��Top=�6�   $	��153��6�   ��6   �� *$"Selektovani_vlasnik.Nazivi_klubova+$ TwoWay=�5      �� 5   
   $��Obrisi Vlasnika��6     RoundButton#��[ 6,   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6  y�6Q   �� *
Visibility+��6s   �� *DeleteCommand+{�6�   �� *	CanDelete+6  �� 5   
   $��Stampaj vlasnike��6   #��[ 6N   $
��Left=�6s   $��50��6�   $��626,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6,   �� *IspisCommand+6�   5      5      