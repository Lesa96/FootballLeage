   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5           Client.Views.ShowIgracView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  62      
IsReadOnly .    SelectionMode$ Single=�6k      AlternatingRowBackground
 �����   AutoGenerateColumns .  $
��Left=�6�   $	��199��6  $��	10,85,0,0q�6$  $	��Top=�67  $	��780��6O  ��6   �� *igraci+ �� SelectedValue 6�   �� *Selektovani_igrac+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 60 6U   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *igrac.id_igraca+6U     5      $ 
Ime igraca��6%   $	 * 6^   
 69   �� *igrac.ime_igraca+6^     5      $ Prezime igraca��6%   $	 * 6f   
 6=   �� *igrac.prezime_igraca+6f     5      $ Klub igraca��6%   $	 * 6`   
 6:   �� *igrac.naziv_kluba+6`     5      $ Broj utakmica��6%   $	 * 6i   
 6<   �� *igrac.odigranih_utakmica+6i     5      $ Datih golova��6%   $	 * 6h   
 6;   �� *igrac.postignutih_golova+6h     5      $ Prosek golova��6%   $	 * 6d   
 6<   �� *igrac.prosek_golova+6d     5      $ Godine igraca��6%   $	 * 6d   
 6<   �� *igrac.godine_igraca+6d   5      �� 5   
   $��Transfer istorija:��6   
�������$
��Left=�6D   $��331,297,0,0q�6_   $	��Top=�6t   �� 5   
   
�������$
��Left=�6g   $��76��6�   $��331,328,0,0q�6�   $	��Top=�6�   $	��153��6�   ��6   �� *Selektovani_igrac.Transferi+$ TwoWay=�6�   �� 5   
   $��Obrisi Igraca��6     RoundButton#��[ 6)   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6  y�6N   �� *
Visibility+��6p   �� *DeleteCommand+{�6�   �� *	CanDelete+6  �� 5   
   $��Stampaj igrace��6   #��[ 6L   $
��Left=�6q   $��50��6�   $��626,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6*   �� *IspisCommand+6�   5       5!      