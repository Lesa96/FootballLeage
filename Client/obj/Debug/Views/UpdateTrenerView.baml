   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5      #    Client.Views.UpdateTrenerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  63      
IsReadOnly .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6�   $	��199��6  $��	10,85,0,0q�6&  $	��Top=�69  $	��780��6Q  ��6   �� *	treneri+ �� SelectedValue 6�   �� *Selektovani_trener+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 60 6R   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *T.id_trenera+6R     5      $ Ime trenera��6%   $	 * 6\   
 6:   �� *T.ime_trenera+6\     5      $ Prezime trenera��6%   $	 * 6d   
 6>   �� *T.prezime_trenera+6d     5      $ Drzava trenera��6%   $	 * 6Z   
 6=   �� *
T.drzava+6Z     5      $ Klub trenera��6%   $	 * 6[   
 6;   �� *Naziv_Kluba+6[   5      �� 5   
   $
��Left=�6   $��20��6-   $��311,330,0,0q�69    �� TextWrapping$
 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *" Selektovani_trener.T.ime_trenera+6�   �� 5   
   $��Ime Trenera��6   
�������$
��Left=�6=   $��25��6X   $��311,300,0,0q�6d   $	��Top=�6y   $��72��6�   �� 5   
   $
��Left=�6   $��20��6-   $��515,330,0,0q�69   $
 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *&$Selektovani_trener.T.prezime_trenera+6�   �� 5   
   $��Prezime Trenera��6   
�������$
��Left=�6A   $��25��6\   $��515,300,0,0q�6h   $	��Top=�6}   $	��100��6�   �� 5   
   $
��Klub��6   
�������$
��Left=�66   $��25��6Q   $��311,355,0,0q�6]   $	��Top=�6r   $��37��6�   �� 5   
    � Cursor$
 Hand��6F   $
��Left=�6�   $��24��6�   $��311,385,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Naziv_Klubova+$ TwoWay=� �� SelectedItem 6T   �� * Selektovani_trener.Naziv_Kluba+$ TwoWay=�6�   �� 5    
   $
 Hand��6?   $
��Left=�6�   $��24��6�   $��515,385,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� 6M   �� *Selektovani_trener.T.drzava+$ TwoWay=�6�   �� 5!   
   $��Drzava trenera��6   
�������$
��Left=�6@   $��25��6[   $��515,355,0,0q�6g   $	��Top=�6|   $	��100��6�   �� 5#   
   $��Promeni Trenera��6     RoundButton#��[ 6,   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6Q   �� *UpdateCommand+{�6s   �� *	CanUpdate+6�   5$      5%      