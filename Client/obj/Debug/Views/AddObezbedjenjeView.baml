   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      &     Client.Views.AddObezbedjenjeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      .��5	      � .+�5
   
   �� $��Ime Radnika:��6   
�������$
��Left=�6>   $��	23,53,0,0q�6Y   $	��Top=�6l   �� 5   
   -   5          ��Name$  Ime_textbox��5      $
��Left=�6^   $��21��6y   $��	23,84,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6'   �� *Radnik_prop.ime_radnika+ �� Mode$ TwoWay=�6�   �� 5   
   $��Prezime Radnika:��6   
�������$
��Left=�6B   $��
23,110,0,0q�6]   $	��Top=�6q   �� 5   
   -   5        $  Prezime_textbox��5      $
��Left=�6f   $��21��6�   $��
23,141,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6+   �� *Radnik_prop.prezime_radnika+$ TwoWay=�6�   �� 5   
   $��Drzava Navijaca:��6   
�������$
��Left=�6B   $��
23,167,0,0q�6]   $	��Top=�6q   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��
23,198,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� *Radnik_prop.drzava+$ TwoWay=�6�   �� 5   
   $
��Left=�6H   $	��165��6c   $��
364,84,0,0q�6p   $	��Top=�6�   $	��201��6�   ��6   �� *stadioni_klubovi+$ TwoWay=���5      �� 5      .R�5      �� .+�5      ��  d� 	IsChecked 6#   �� *
IsSelected+$ TwoWay=��� 5      ��6$   �� *Klub_Stadion_Nazivi+$ TwoWay=�5      5      5      �� 5   
   $%��Bar jedan stadion na kome radi:��6   
�������$
��Left=�6Q   $��
364,53,0,0q�6l   $	��Top=�6�   �� 5   
   $��Dodaj Radnika��6      RoundButton#��[  6)   $
��Left=�6m   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6N   �� *
addCommand+6�   5      5       