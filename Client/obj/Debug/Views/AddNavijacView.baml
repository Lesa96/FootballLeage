   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      !    Client.Views.AddNavijacView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      .��5	      � .+�5
   
   �� $��Ime Navijaca:��6   
�������$
��Left=�6?   $��	23,53,0,0q�6Z   $	��Top=�6m   �� 5   
   -   5          ��Name$  Ime_textbox��5      $
��Left=�6`   $��21��6{   $��	23,84,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6'   �� *Navijac_prop.ime_navijaca+ �� Mode$ TwoWay=�6�   �� 5   
   $��Prezime Navijaca:��6   
�������$
��Left=�6C   $��
23,110,0,0q�6^   $	��Top=�6r   �� 5   
   -   5        $  Prezime_textbox��5      $
��Left=�6h   $��21��6�   $��
23,141,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��140��6�   ��6+   �� *Navijac_prop.prezime_navijaca+$ TwoWay=�6�   �� 5   
   $��Drzava Navijaca:��6   
�������$
��Left=�6B   $��
23,167,0,0q�6]   $	��Top=�6q   �� 5   
    � Cursor$
 Hand��6?   $
��Left=�6�   $��24��6�   $��
23,198,0,0q�6�   $	��Top=�6�   $	��140��6�   ��6   �� *Drzave+$ TwoWay=� �� SelectedItem 6M   �� *Navijac_prop.drzava+$ TwoWay=�6�   �� 5   
   $
��Left=�6?   $	��165��6Z   $��
364,84,0,0q�6g   $	��Top=�6{   $	��201��6�   ��6   �� *	klubovi+$ TwoWay=���5      �� 5      .R�5      �� .+�5      ��  d� 	IsChecked 6#   �� *
IsSelected+$ TwoWay=��� 5      ��6$   �� *	K.naziv+$ TwoWay=�5      5      5      �� 5   
   $$��Bar jedan klub za koji navija:��6   
�������$
��Left=�6P   $��
364,53,0,0q�6k   $	��Top=�6   �� 5   
   $��Dodaj Navijaca��6      RoundButton#��[  6+   $
��Left=�6o   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6P   �� *
addCommand+6�   5      5       