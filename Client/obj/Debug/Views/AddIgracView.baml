   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5          Client.Views.AddIgracView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   �� $��Broj datih golova:��6   
�������$
��Left=�6D   $��361,110,0,0q�6_   $	��Top=�6t   �� 5   
   $��Ime Igraca:��6   
�������$
��Left=�6=   $��	23,53,0,0q�6X   $	��Top=�6k   �� 5   
   $��Odigranih utakmica��6   
�������$
��Left=�6D   $��361,167,0,0q�6_   $	��Top=�6t   �� 5   
   $��Prezime Igraca:��6   
�������$
��Left=�6A   $��
23,110,0,0q�6\   $	��Top=�6p   �� 5   
   $��Klub za koji igra:��6   
�������$
��Left=�6D   $��
23,167,0,0q�6_   $	��Top=�6s   �� 5   
   $��Godine Igraca:��6   
�������$
��Left=�6@   $��
361,53,0,0q�6[   $	��Top=�6o   �� 5   
   -   5         ��Name$ Godine_textbox��5      $
��Left=�6W   $��21��6r   $��
361,84,0,0q�6~    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6*   �� *Godine+ �� Mode$ OneWayToSource=�6�   �� 5   
   -   5        $ Golovi_textbox��5      $
��Left=�6W   $��21��6r   $��361,141,0,0q�6~   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6*   �� *Golovi+$ OneWayToSource=�6�   �� 5   
   -   5        $ Ime_textbox��5      $
��Left=�6\   $��21��6w   $��	23,84,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6'   �� *Igrac_prop.ime_igraca+$ TwoWay=�6�   �� 5   
   -   5        $ Odigranih_textbox��5      $
��Left=�6]   $��21��6x   $��361,198,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6-   �� *
Utakmice+$ OneWayToSource=�6�   �� 5   
   -   5        $ Prezime_textbox��5      $
��Left=�6d   $��21��6   $��
23,141,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6+   �� *Igrac_prop.prezime_igraca+$ TwoWay=�6�   �� 5   
    � Cursor$
 Hand��6D   $
��Left=�6�   $��24��6�   $��
23,198,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Naziv_kluba+$ TwoWay=� �� SelectedItem 6R   �� *SelektovaniKlub+$ TwoWay=�6�   �� 5   
   $��Dodaj Igraca��6      RoundButton#��[  6)   $
��Left=�6m   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6N   �� *
addCommand+6�   5      5      