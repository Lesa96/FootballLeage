   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5      !    Client.Views.UpdateKlubView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  66      
IsReadOnly .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6�   $	��199��6  $��	10,85,0,0q�6'  $	��Top=�6:  $	��780��6R  ��6   �� *
KlubUpdate+ �� SelectedValue 6�   �� *Selektovana_klub+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Naziv kluba��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6V   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6:   �� *	K.naziv+6V     5      $ 
Grad kluba��6%   $	 * 6T   
 69   �� *K.grad+6T     5      $
 Liga��6%   $	 * 6R   
 63   �� *
Naziv_lige+6R     5      $ Trener��6%   $	 * 6P   
 65   �� *Trener+6P     5      $ Navijaci��6%   $	 * 6Y   
 67   �� *Broj_Navijaca+6Y     5      $ Vrednost kluba ($)��6%   $	 * 6`   
 6A   �� *
K.vrednost+6`   5      �� 5   
   $
��Left=�6   $��20��6-   $��311,319,0,0q�69    �� TextWrapping$
 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *Selektovana_klub.K.grad+6�   �� 5   
   $��
Grad kluba��6   
�������$
��Left=�6<   $��25��6W   $��311,289,0,0q�6c   $	��Top=�6x   $��69��6�   �� 5   
   
�������$
��Liga��6'   $
��Left=�66   $��25��6Q   $��515,289,0,0q�6]   $	��Top=�6r   $��33��6�   �� 5   
    � Cursor$
 Hand��6C   $
��Left=�6�   $��20��6�   $��515,319,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *
Naziv_lige+$ TwoWay=� �� SelectedItem 6Q   �� *Selektovana_klub.Naziv_lige+$ TwoWay=�6�   �� 5    
   
�������$��Slobodni Treneri��6'   $
��Left=�6B   $��25��6]   $��311,344,0,0q�6i   $	��Top=�6~   $��96��6�   �� 5!   
   $
 Hand��6F   $
��Left=�6�   $��20��6�   $��311,374,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Naziv_Trenera+$ TwoWay=� 6T   �� *Selektovana_klub.Trener+$ TwoWay=�6�   �� 5"   
   $��Vrednost kluba��6   
�������$
��Left=�6@   $��25��6[   $��515,344,0,0q�6g   $	��Top=�6|   $��92��6�   �� 5#   
   $
��Left=�6   $��20��6-   $��515,374,0,0q�69   $
 Wrap=�6N   $	��Top=�6�   $	��140��6�   ��6b   �� *
Vrednost+$ TwoWay=�6�   �� 5%   
   $��Update klub��6     RoundButton#��[ 6(   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6M   �� *UpdateCommand+{�6o   �� *	CanUpdate+6�   5'      5(      