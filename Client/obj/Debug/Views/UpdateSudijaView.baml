   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      #    Client.Views.UpdateSudijaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      .��5	      � ��5
   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  63      
IsReadOnly .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6�   $	��199��6  $��	10,85,0,0q�6&  $	��Top=�69  $	��780��6Q  ��6   �� *	sudijeS+ �� SelectedValue 6�   �� *Selektovani_sudija+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 60 6Q   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *S.id_sudije+6Q     5      $	 Ime��6%   $	 * 6S   
 62   �� *S.ime_sudije+6S     5      $ Prezime��6%   $	 * 6[   
 66   �� *S.prezime_sudije+6[     5      $ Drzava��6%   $	 * 6_   
 65   �� *S.nacionalnost_sudije+6_     5      $
 Liga��6%   $	 * 6S   
 63   �� *Liga_Sudije+6S   5      �� 5   
   $
��Left=�6   $��20��6-   $��311,319,0,0q�69    �� TextWrapping$
 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *!Selektovani_sudija.S.ime_sudije+6�   �� 5   
   $��
Ime sudije��6   
�������$
��Left=�6<   $��25��6W   $��311,289,0,0q�6c   $	��Top=�6x   $��65��6�   �� 5   
   $
��Left=�6   $��20��6-   $��515,319,0,0q�69   $
 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *%#Selektovani_sudija.S.prezime_sudije+6�   �� 5   
   
�������$��Prezime sudije��6'   $
��Left=�6@   $��25��6[   $��515,289,0,0q�6g   $	��Top=�6|   $��89��6�   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��311,374,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� **(Selektovani_sudija.S.nacionalnost_sudije+$ TwoWay=�6�   �� 5   
   $��Drzava sudije��6   
�������$
��Left=�6?   $��25��6Z   $��311,344,0,0q�6f   $	��Top=�6{   $��80��6�   �� 5   
   $
��Liga��6   
�������$
��Left=�66   $��515,343,0,0q�6Q   $	��Top=�6f   $��35��6~   �� 5   
   $
 Hand��6C   $
��Left=�6�   $��20��6�   $��515,374,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *
Naziv_lige+$ TwoWay=� 6Q   �� * Selektovani_sudija.Liga_Sudije+$ TwoWay=�6�   �� 5    
   $��Promeni sudiju��6     RoundButton#��[ 6+   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6P   �� *UpdateCommand+{�6r   �� *	CanUpdate+6�   5!      5"      