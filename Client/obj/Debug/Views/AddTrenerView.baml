   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5           Client.Views.AddTrenerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   �� $��Ime Trenera:��6   
�������$
��Left=�6>   $��	23,47,0,0q�6Y   $	��Top=�6l   �� 5   
   $��Prezime Trenera:��6   
�������$
��Left=�6B   $��
23,104,0,0q�6]   $	��Top=�6q   �� 5   
   $/��)Slobodni klubovi za treniranje (opciono):��6   
�������$
��Left=�6[   $��
23,221,0,0q�6v   $	��Top=�6�   �� 5   
   -   5         ��Name$ Ime_textbox��5      $
��Left=�6^   $��21��6y   $��	23,78,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6'   �� *Trener_prop.ime_trenera+ �� Mode$ TwoWay=�6�   �� 5   
   -   5        $ Prezime_textbox��5      $
��Left=�6f   $��21��6�   $��
23,135,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6+   �� *Trener_prop.prezime_trenera+$ TwoWay=�6�   �� 5   
   $��Drzava Trenera:��6   
�������$
��Left=�6A   $��
24,161,0,0q�6\   $	��Top=�6p   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��
23,192,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� *Trener_prop.drzava+$ TwoWay=�6�   �� 5   
   $
 Hand��6D   $
��Left=�6�   $��24��6�   $��
23,252,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Naziv_kluba+$ TwoWay=� 6R   �� *SelektovaniKlub+$ TwoWay=�6�   �� 5   
   $��Dodaj Trenera��6      RoundButton#��[  6*   $
��Left=�6n   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6O   �� *
addCommand+6�   5      5      