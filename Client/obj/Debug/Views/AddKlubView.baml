   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5          Client.Views.AddKlubView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      5	viewmodelclr-namespace:Client.ViewModels     5      .��5      � ��5   
   �� 5        �� ImageSource$!  ../Pictures/PocetnaLiga.jpg��6   6E   .+�5   
   �� $��Naziv kluba:��6   
�������$
��Left=�6>   $��	23,53,0,0q�6Y   $	��Top=�6l   �� 5   
   $��Grad kluba:��6   
�������$
��Left=�6=   $��
23,110,0,0q�6X   $	��Top=�6l   �� 5   
   -   5         ��Name$ Naziv_textbox��5      $
��Left=�6W   $��21��6r   $��	23,84,0,0q�6~    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6)   �� *Klub_prop.naziv+ �� Mode$ TwoWay=�6�   �� 5   
   -   5        $ Grad_textbox��5      $
��Left=�6V   $��21��6q   $��
23,141,0,0q�6}   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6(   �� *Klub_prop.grad+$ TwoWay=�6�   �� 5   
   $��Vrednost kluba ($):��6   
�������$
��Left=�6E   $��
23,167,0,0q�6`   $	��Top=�6t   �� 5   
   -   5        $ Vrednost_textbox��5      $
��Left=�6[   $��21��6v   $��
23,198,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6,   �� *
Vrednost+$ OneWayToSource=�6�   �� 5   
   $$��Odabrati jednu ligu (opciono):��6   
�������$
��Left=�6P   $��
23,225,0,0q�6k   $	��Top=�6   $	��168��6�   �� 5   
   $��
Dodaj klub��6      RoundButton#��[  6'   $
��Left=�6k   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6L   �� *
addCommand+6�   �� 5   
    � Cursor$
 Hand��6C   $
��Left=�6�   $��24��6�   $��
23,256,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *
Naziv_lige+$ TwoWay=� �� SelectedItem 6Q   �� *SelektovanaLiga+$ TwoWay=�6�   �� 5   
   $
��Left=�6@   $	��165��6[   $��
364,84,0,0q�6h   $	��Top=�6|   $	��201��6�   ��6   �� *
stadioni+$ TwoWay=���5      �� 5      .R�5      �� .+�5      ��  d� 	IsChecked 6#   �� *
IsSelected+$ TwoWay=��� 5       ��6$   �� *Naziv_stadiona+$ TwoWay=�5!      5"      5$      �� 5%   
   $!��Odabrati stadion (opciono):��6   
�������$
��Left=�6M   $��
364,53,0,0q�6h   $	��Top=�6|   5)      5*      