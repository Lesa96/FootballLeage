   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5      !    Client.Views.UpdateLigaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  66      
IsReadOnly .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6  $	��199��6   $��	10,85,0,0q�6-  $	��Top=�6@  $	��780��6X  ��6   �� *
ligeUpdate+ �� SelectedValue 6�   �� *Selektovana_ligaUpdate+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 60 6M   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *	id_lige+6M     5      $ 
Naziv Lige��6%   $	 * 6X   
 69   �� *
naziv_lige+6X     5      $ Drzava Lige��6%   $	 * 6Z   
 6:   �� *drzava_lige+6Z   5      �� 5   
   $
��Left=�6   $��20��6-   $��301,358,0,0q�69    �� TextWrapping$
 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *#!Selektovana_ligaUpdate.naziv_lige+6�   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��589,358,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� *$"Selektovana_ligaUpdate.drzava_lige+$ TwoWay=�6�   �� 5   
   $��
Naziv Lige��6   
�������$
��Left=�6<   $��25��6W   $��301,328,0,0q�6c   $	��Top=�6x   $��66��6�   �� 5   
   $��Drzava Lige��6   
�������$
��Left=�6=   $��25��6X   $��589,328,0,0q�6d   $	��Top=�6y   $��72��6�   �� 5   
   $��Update ligu��6     RoundButton#��[ 6(   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6M   �� *UpdateCommand+{�6o   �� *	CanUpdate+6�   5      5       