   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      $    Client.Views.UpdateNavijacView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  64       
IsReadOnly  .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6   $	��199��6  $��	10,85,0,0q�6(  $	��Top=�6;  $	��780��6S  ��6   �� *
Navijaci+ �� SelectedValue 6�   �� *Selektovani_navijac+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6S   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *N.id_navijaca+6S     5      $ Ime Navijaca��6%   $ * 6^   	 6;   �� *N.ime_navijaca+6^     5      $ Prezime Navijaca��6%   $ * 6f   	 6?   �� *N.prezime_navijaca+6f     5      $ Drzava Navijaca��6%   $ * 6[   	 6>   �� *
N.drzava+6[   5      �� 5   
   $
��Left=�6   $��20��6-   $��224,319,0,0q�69   
 �� TextWrapping$

 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *$"Selektovani_navijac.N.ime_navijaca+6�   �� 5   
   $��Ime navijaca��6   
�������$
��Left=�6>   $��25��6Y   $��224,289,0,0q�6e   $	��Top=�6z   $��78��6�   �� 5   
   $
��Left=�6   $��20��6-   $��410,319,0,0q�69   $

 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *(&Selektovani_navijac.N.prezime_navijaca+6�   �� 5   
   
�������$��Prezime navijaca��6'   $
��Left=�6B   $��25��6]   $��410,289,0,0q�6i   $	��Top=�6~   $��99��6�   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��224,374,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� *Selektovani_navijac.N.drzava+$ TwoWay=�6�   �� 5   
   $��Drzava navijaca��6   
�������$
��Left=�6A   $��25��6\   $��224,344,0,0q�6h   $	��Top=�6}   $��95��6�   �� 5   
   $��Klubovi za koje navija:��6   
�������$
��Left=�6I   $��598,289,0,0q�6d   $	��Top=�6y   �� 5   
   
�������$
��Left=�6S   $��78��6n   $��598,320,0,0q�6z   $	��Top=�6�   $	��153��6�   ��6   �� *	Klubovi+$ TwoWay=���5      �� 5      .R�5      �� .+�5      ��  d� 	IsChecked 6#   �� *
IsSelected+$ TwoWay=��� 5      ��6$   �� *	K.naziv+$ TwoWay=�5      5       5"      �� 5&   
   $��Promeni Navijaca��6     RoundButton#��[ 6-   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6R   �� *UpdateCommand+{�6t   �� *	CanUpdate+6�   5(      5)      