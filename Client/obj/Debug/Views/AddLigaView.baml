   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5          Client.Views.AddLigaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   �� $��Naziv lige:��6   
�������$
��Left=�6=   $��	23,53,0,0q�6X   $	��Top=�6k   �� 5   
   $��Drzava lige:��6   
�������$
��Left=�6>   $��
23,110,0,0q�6Y   $	��Top=�6m   �� 5   
   -   5         ��Name$ Naziv_textbox��5      $
��Left=�6]   $��21��6x   $��	23,84,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6)   �� *Liga_prop.naziv_lige+ �� Mode$ TwoWay=�6�   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��
25,141,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� *Liga_prop.drzava_lige+$ TwoWay=�6�   �� 5   
   $��
Dodaj Ligu��6      RoundButton#��[  6'   $
��Left=�6k   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6L   �� *
addCommand+6�   �� 5   
   $
��Left=�6>   $	��165��6Y   $��
364,84,0,0q�6f   $	��Top=�6z   $	��201��6�   ��6   �� *sudije+$ TwoWay=���5      �� 5      .R�5      �� .+�5      ��  d� 	IsChecked 6#   �� *
IsSelected+$ TwoWay=��� 5      ��6$   �� *Naziv_sudije+$ TwoWay=�5      5      5      �� 5   
   $ ��Odabrati bar jednog sudiju��6   
�������$
��Left=�6L   $��
364,53,0,0q�6g   $	��Top=�6{   $	��154��6�   �� 5!   
   $
��Left=�6@   $	��165��6[   $��
589,84,0,0q�6h   $	��Top=�6|   $	��201��6�   ��6   �� *
sponzori+$ TwoWay=���5"      �� 5#      .R�5$      �� .+�5%      ��  6#   �� *SelectedItem+$ TwoWay=��� 5&      ��6$   �� *Naziv_sponzora+$ TwoWay=�5'      5(      5*      �� 5+   
   $(��"Odabrati jednog sponzora(opciono):��6   
�������$
��Left=�6T   $��
589,53,0,0q�6o   $	��Top=�6�   $	��201��6�   5.      5/      