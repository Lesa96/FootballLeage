   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      "    Client.Views.AddMenadzerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      .��5	      � .+�5
   
   �� $��Ime Menadzera:��6   
�������$
��Left=�6@   $��	23,53,0,0q�6[   $	��Top=�6n   �� 5   
   -   5          ��Name$  Ime_textbox��5      $
��Left=�6a   $��21��6|   $��	23,84,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6'   �� *Menadzer_prop.ime_menagera+ �� Mode$ TwoWay=�6�   �� 5   
   $��Prezime Menadzera:��6   
�������$
��Left=�6D   $��
23,110,0,0q�6_   $	��Top=�6s   �� 5   
   -   5        $  Prezime_textbox��5      $
��Left=�6i   $��21��6�   $��
23,141,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6+   �� * Menadzer_prop.prezime_menagera+$ TwoWay=�6�   �� 5   
   $��Drzava Menadzera:��6   
�������$
��Left=�6C   $��
23,167,0,0q�6^   $	��Top=�6r   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��
23,198,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� *Menadzer_prop.drzava+$ TwoWay=�6�   �� 5   
   $
��Left=�6>   $	��165��6Y   $��
364,84,0,0q�6f   $	��Top=�6z   $	��201��6�   ��6   �� *igraci+$ TwoWay=���5      �� 5      .R�5      �� .+�5      ��  d� 	IsChecked 6#   �� *
IsSelected+$ TwoWay=��� 5      ��6$   �� *Ime_Prezime+$ TwoWay=�5      5      5      �� 5   
   $,��&Bar jedan igrac kome ce biti menadzer:��6   
�������$
��Left=�6X   $��
364,53,0,0q�6s   $	��Top=�6�   �� 5   
   $��Dodaj Menadzera��6      RoundButton#��[  6,   $
��Left=�6p   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6Q   �� *
addCommand+6�   5      5       