   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5           Client.Views.AddSudijaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   �� $��Ime sudije:��6   
�������$
��Left=�6=   $��	23,53,0,0q�6X   $	��Top=�6k   �� 5   
   $��Prezime:��6   
�������$
��Left=�6:   $��
23,110,0,0q�6U   $	��Top=�6i   �� 5   
   $��Drzava:��6   
�������$
��Left=�69   $��
23,167,0,0q�6T   $	��Top=�6h   �� 5   
   $
��Left=�6H   $��21��6c   $��	23,84,0,0q�6o    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Sudija_prop.ime_sudije+ �� Mode$ TwoWay=�6�   �� 5   
   $
��Left=�6L   $��21��6g   $��
23,141,0,0q�6s   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Sudija_prop.prezime_sudije+$ TwoWay=�6�   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��
23,198,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� *!Sudija_prop.nacionalnost_sudije+$ TwoWay=�6�   �� 5   
   $$��Odabrati jednu ligu (opciono):��6   
�������$
��Left=�6P   $��
23,227,0,0q�6k   $	��Top=�6   $	��168��6�   �� 5   
   $
 Hand��6C   $
��Left=�6�   $��24��6�   $��
23,258,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *
Naziv_lige+$ TwoWay=� 6Q   �� *SelektovanaLiga+$ TwoWay=�6�   �� 5   
   $��Dodaj sudiju��6      RoundButton#��[  6)   $
��Left=�6m   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6N   �� *
addCommand+6�   5      5      