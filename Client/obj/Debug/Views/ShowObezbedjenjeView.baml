   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5      '    !Client.Views.ShowObezbedjenjeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  63       
IsReadOnly  .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6�   $	��199��6  $��	10,85,0,0q�6&  $	��Top=�69  $	��780��6Q  ��6   �� *	radnici+ �� SelectedValue 6�   �� *Selektovani_radnik+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6W   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Radnik.id_radnika+6W     5      $ Ime Navijaca��6%   $ * 6b   	 6;   �� *Radnik.ime_radnika+6b     5      $ Prezime Navijaca��6%   $ * 6j   	 6?   �� *Radnik.prezime_radnika+6j     5      $ Drzava Navijaca��6%   $ * 6`   	 6>   �� *Radnik.drzava+6`   5      �� 5   
   $��Stadioni na kojima radi:��6   
�������$
��Left=�6J   $��331,297,0,0q�6e   $	��Top=�6z   �� 5   
   
�������$
��Left=�6r   $��76��6�   $��331,328,0,0q�6�   $	��Top=�6�   $	��153��6�   ��6   �� *(&Selektovani_radnik.Klub_Stadion_Nazivi+$ TwoWay=�5      �� 5   
   $��Obrisi Radnika��6     RoundButton#��[ 6+   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6  y�6P   �� *
Visibility+��6r   �� *DeleteCommand+{�6�   �� *	CanDelete+6  �� 5   
   $��Stampaj obezbedjenje��6   #��[ 6R   $
��Left=�6w   $��50��6�   $��626,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��60   �� *IspisCommand+6�   5      5      