   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      !    Client.Views.AddStadionView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      .��5	      � .+�5
   
   �� $��Naziv stadiona:��6   
�������$
��Left=�6A   $��	23,53,0,0q�6\   $	��Top=�6o   �� 5   
   -   5          ��Name$  Ime_textbox��5      $
��Left=�6b   $��21��6}   $��	23,84,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6'   �� *Stadion_prop.naziv_stadiona+ �� Mode$ TwoWay=�6�   �� 5   
   $��Grad stadiona:��6   
�������$
��Left=�6@   $��
23,110,0,0q�6[   $	��Top=�6o   �� 5   
   -   5        $  Drzava_textbox��5      $
��Left=�6[   $��21��6v   $��
23,141,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6*   �� *Stadion_prop.grad+$ TwoWay=�6�   �� 5   
   $)��#Kapacitet stadiona (broj sedista) :��6   
�������$
��Left=�6U   $��
23,167,0,0q�6p   $	��Top=�6�   �� 5   
   -   5        $  Kapacitet_textbox��5      $
��Left=�6^   $��21��6y   $��
25,198,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6-   �� *	Kapacitet+$ OneWayToSource=�6�   �� 5   
   $
��Left=�6?   $	��165��6Z   $��
364,84,0,0q�6g   $	��Top=�6{   $	��201��6�   ��6   �� *	klubovi+$ TwoWay=���5      �� 5      .R�5      �� .+�5      ��  d� 	IsChecked 6#   �� *
IsSelected+$ TwoWay=��� 5      ��6$   �� *	K.naziv+$ TwoWay=�5      5      5      �� 5   
   $"��Klub kome pripada (opciono):��6   
�������$
��Left=�6N   $��
364,53,0,0q�6i   $	��Top=�6}   �� 5   
   $��Dodaj Stadion��6      RoundButton#��[  6*   $
��Left=�6n   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6O   �� *
addCommand+6�   5      5       