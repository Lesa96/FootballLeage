   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5          Client.Views.ShowLigaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  60      
IsReadOnly .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6�   $	��199��6  $��	10,85,0,0q�6!  $	��Top=�64  $	��780��6L  ��6   �� *lige+ �� SelectedValue 6�   �� *Selektovana_liga+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 60 6O   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *	L.id_lige+6O     5      $ 
Naziv Lige��6%   $	 * 6Z   
 69   �� *L.naziv_lige+6Z     5      $ Drzava Lige��6%   $	 * 6\   
 6:   �� *L.drzava_lige+6\     5      $ Ukupno klubova��6%   $	 * 6`   
 6=   �� *L.broj_klubova+6`     5      $# Prosecna vrednost klubova ($)��6%   $	 * 6z   
 6L   �� *Prosecna_Vrednost_Klubova+6z   5      �� 5   
   $��Obrisi ligu��6     RoundButton#��[ 6(   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6  y�6M   �� *
Visibility+��6o   �� *DeleteCommand+{�6�   �� *	CanDelete+6  �� 5   
   $��Stampaj lige��6   #��[ 6J   $
��Left=�6o   $��50��6�   $��626,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6(   �� *IspisCommand+6�   5      5      