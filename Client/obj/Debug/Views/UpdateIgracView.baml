   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5      "    Client.Views.UpdateIgracView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  62      
IsReadOnly .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6�   $	��199��6  $��	10,85,0,0q�6$  $	��Top=�67  $	��780��6O  ��6   �� *igraci+ �� SelectedValue 6�   �� *Selektovani_igrac+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 60 6U   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *igrac.id_igraca+6U     5      $
 Ime ��6%   $	 * 6X   
 63   �� *igrac.ime_igraca+6X     5      $ Prezime ��6%   $	 * 6`   
 67   �� *igrac.prezime_igraca+6`     5      $ Klub ��6%   $	 * 6Z   
 64   �� *igrac.naziv_kluba+6Z     5      $ Odigranih utakmica��6%   $	 * 6n   
 6A   �� *igrac.odigranih_utakmica+6n     5      $ Postignutih golova��6%   $	 * 6n   
 6A   �� *igrac.postignutih_golova+6n     5      $ Godine igraca��6%   $	 * 6d   
 6<   �� *igrac.godine_igraca+6d   5      �� 5   
   $
��Left=�6   $��20��6-   $��230,319,0,0q�69    �� TextWrapping$
 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *$"Selektovani_igrac.igrac.ime_igraca+6�   �� 5   
   $��
Ime Igraca��6   
�������$
��Left=�6<   $��25��6W   $��230,289,0,0q�6c   $	��Top=�6x   $��67��6�   �� 5   
   $
��Left=�6   $��20��6-   $��434,319,0,0q�69   $
 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *(&Selektovani_igrac.igrac.prezime_igraca+6�   �� 5   
   $��Prezime Igraca��6   
�������$
��Left=�6@   $��25��6[   $��434,289,0,0q�6g   $	��Top=�6|   $��89��6�   �� 5   
   $��Odigranih utakmica��6   
�������$
��Left=�6D   $��25��6_   $��230,344,0,0q�6k   $	��Top=�6�   $	��116��6�   �� 5    
   $
��Left=�6   $��20��6-   $��230,374,0,0q�69   $
 Wrap=�6N   $	��Top=�6|   $	��160��6�   ��6b   �� *
Utakmice+6�   �� 5!   
   $��Postignutih golova��6   
�������$
��Left=�6D   $��25��6_   $��434,344,0,0q�6k   $	��Top=�6�   $	��116��6�   �� 5"   
   $
��Left=�6   $��20��6-   $��434,374,0,0q�69   $
 Wrap=�6N   $	��Top=�6z   $	��160��6�   ��6b   �� *Golovi+6�   �� 5#   
   $��Klub igraca��6   
�������$
��Left=�6=   $��25��6X   $��643,289,0,0q�6d   $	��Top=�6y   $��71��6�   �� 5$   
    � Cursor$
 Hand��6F   $
��Left=�6�   $��20��6�   $��643,319,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Naziv_Klubova+$ TwoWay=� �� SelectedItem 6T   �� *%#Selektovani_igrac.igrac.naziv_kluba+$ TwoWay=�6�   �� 5%   
   $��Godine igraca��6   
�������$
��Left=�6?   $��25��6Z   $��643,344,0,0q�6f   $	��Top=�6{   $��87��6�   �� 5&   
   $
��Left=�6   $��20��6-   $��643,374,0,0q�69   $
 Wrap=�6N   $	��Top=�6�   $	��140��6�   ��6b   �� *Godine+$ TwoWay=�6�   �� 5(   
   $��Promeni Igraca��6     RoundButton#��[ 6+   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6P   �� *UpdateCommand+{�6r   �� *	CanUpdate+6�   5+      5,      