   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      %    Client.Views.UpdateMenadzerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  65       
IsReadOnly  .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6  $	��199��6  $��	10,85,0,0q�6*  $	��Top=�6=  $	��780��6U  ��6   �� *	Menadzeri+ �� SelectedValue 6�   �� *Selektovani_menadzer+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6S   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *M.id_menagera+6S     5      $ Ime Menadzera��6%   $ * 6_   	 6<   �� *M.ime_menagera+6_     5      $ Prezime Menadzera��6%   $ * 6g   	 6@   �� *M.prezime_menagera+6g     5      $ Drzava Menadzera��6%   $ * 6\   	 6?   �� *
M.drzava+6\   5      �� 5   
   $
��Left=�6   $��20��6-   $��224,319,0,0q�69   
 �� TextWrapping$

 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *%#Selektovani_menadzer.M.ime_menagera+6�   �� 5   
   $��Ime menadzera��6   
�������$
��Left=�6?   $��25��6Z   $��224,289,0,0q�6f   $	��Top=�6{   $��97��6�   �� 5   
   $
��Left=�6   $��20��6-   $��410,319,0,0q�69   $

 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *)'Selektovani_menadzer.M.prezime_menagera+6�   �� 5   
   
�������$��Prezime menadzera��6'   $
��Left=�6C   $��25��6^   $��410,289,0,0q�6j   $	��Top=�6   $	��116��6�   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��224,374,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� *Selektovani_menadzer.M.drzava+$ TwoWay=�6�   �� 5   
   $��Drzava sudije��6   
�������$
��Left=�6?   $��25��6Z   $��224,344,0,0q�6f   $	��Top=�6{   $��80��6�   �� 5   
   $ ��Igraci kojima je menadzer:��6   
�������$
��Left=�6L   $��598,289,0,0q�6g   $	��Top=�6|   �� 5   
   
�������$
��Left=�6R   $��76��6m   $��598,320,0,0q�6y   $	��Top=�6�   $	��153��6�   ��6   �� *Igraci+$ TwoWay=���5      �� 5      .R�5      �� .+�5      ��  d� 	IsChecked 6#   �� *
IsSelected+$ TwoWay=��� 5      ��6$   �� *Ime_Prezime+$ TwoWay=�5       5!      5#      �� 5'   
   $��Promeni Menadzera��6     RoundButton#��[ 6.   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6S   �� *UpdateCommand+{�6u   �� *	CanUpdate+6�   5)      5*      