   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5      )    #Client.Views.UpdateObezbedjenjeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  63       
IsReadOnly  .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6�   $	��199��6  $��	10,85,0,0q�6&  $	��Top=�69  $	��780��6Q  ��6   �� *	Radnici+ �� SelectedValue 6�   �� *Selektovani_radnik+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6W   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Radnik.id_radnika+6W     5      $ Ime Radnika��6%   $ * 6a   	 6:   �� *Radnik.ime_radnika+6a     5      $ Prezime Radnika��6%   $ * 6i   	 6>   �� *Radnik.prezime_radnika+6i     5      $ Drzava Radnika��6%   $ * 6_   	 6=   �� *Radnik.drzava+6_   5      �� 5   
   $
��Left=�6   $��20��6-   $��224,319,0,0q�69   
 �� TextWrapping$

 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *'%Selektovani_radnik.Radnik.ime_radnika+6�   �� 5   
   $��Ime Radnika��6   
�������$
��Left=�6=   $��25��6X   $��224,289,0,0q�6d   $	��Top=�6y   $��77��6�   �� 5   
   $
��Left=�6   $��20��6-   $��410,319,0,0q�69   $

 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *+)Selektovani_radnik.Radnik.prezime_radnika+6�   �� 5   
   
�������$��Prezime Radnika��6'   $
��Left=�6A   $��25��6\   $��410,289,0,0q�6h   $	��Top=�6}   $	��101��6�   �� 5   
   
�������$��Drzava radnika��6'   $
��Left=�6@   $��25��6[   $��224,344,0,0q�6g   $	��Top=�6|   $��99��6�   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��224,374,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� *" Selektovani_radnik.Radnik.drzava+$ TwoWay=�6�   �� 5   
   $��Stadioni na kojima radi:��6   
�������$
��Left=�6J   $��598,289,0,0q�6e   $	��Top=�6z   �� 5   
   
�������$
��Left=�6T   $��78��6o   $��598,320,0,0q�6{   $	��Top=�6�   $	��153��6�   ��6   �� *
Poseduju+$ TwoWay=���5      �� 5      .R�5      �� .+�5       ��  d� 	IsChecked 6#   �� *
IsSelected+$ TwoWay=��� 5!      ��6$   �� *Klub_Stadion_Nazivi+$ TwoWay=�5"      5#      5%      �� 5)   
   $��Promeni Navijaca��6     RoundButton#��[ 6-   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6R   �� *UpdateCommand+{�6t   �� *	CanUpdate+6�   5-      5.      