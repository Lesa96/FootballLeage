   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      $    Client.Views.UpdateStadionView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid     DataGridStyle#��[  64       
IsReadOnly  .    AlternatingRowBackground
 �����   SelectionMode$ Single=�6�      AutoGenerateColumns .  $
��Left=�6   $	��199��6  $��	10,85,0,0q�6(  $	��Top=�6;  $	��780��6S  ��6   �� *
Stadioni+ �� SelectedValue 6�   �� *Selektovani_stadion+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6S   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *S.id_stadiona+6S     5      $ Naziv Stadiona��6%   $ * 6b   	 6=   �� *S.naziv_stadiona+6b     5      $ Grad Stadiona��6%   $ * 6W   	 6<   �� *S.grad+6W     5      $ Kapacitet Stadiona��6%   $ * 6a   	 6A   �� *S.kapacitet+6a   5      �� 5   
   $
��Left=�6   $��20��6-   $��224,319,0,0q�69   
 �� TextWrapping$

 Wrap=�6N   $	��Top=�6�   $	��160��6�   ��6b   �� *&$Selektovani_stadion.S.naziv_stadiona+6�   �� 5   
   $��Naziv stadiona��6   
�������$
��Left=�6@   $��25��6[   $��224,289,0,0q�6g   $	��Top=�6|   $��91��6�   �� 5   
   $��Grad stadiona:��6   
�������$
��Left=�6@   $��406,289,0,0q�6[   $	��Top=�6p   �� 5   
   -   5         ��Name$ Drzava_textbox��5      $
��Left=�6d   $��21��6   $��406,319,0,0q�6�   $

 Wrap=�6�   $	��Top=�6�   $	��160��6�   ��6*   �� *Selektovani_stadion.S.grad+$ TwoWay=�6�   �� 5   
   $)��#Kapacitet stadiona (broj sedista) :��6   
�������$
��Left=�6U   $��224,352,0,0q�6p   $	��Top=�6�   �� 5   
   -   5        $ Kapacitet_textbox��5      $
��Left=�6V   $��21��6q   $��224,383,0,0q�6}   $

 Wrap=�6�   $	��Top=�6�   $	��160��6�   ��6-   �� *	Kapacitet+$ TwoWay=�6�   �� 5   
   $&�� Klubovi koji igraju na stadionu:��6   
�������$
��Left=�6R   $��599,289,0,0q�6m   $	��Top=�6�   �� 5   
   
�������$
��Left=�6S   $��76��6n   $��599,319,0,0q�6z   $	��Top=�6�   $	��153��6�   ��6   �� *	Klubovi+$ TwoWay=���5      �� 5      .R�5      �� .+�5      ��  d� 	IsChecked 6#   �� *
IsSelected+$ TwoWay=��� 5      ��6$   �� *	K.naziv+$ TwoWay=�5       5!      5#      �� 5%   
   $��Promeni Stadion��6     RoundButton#��[ 6,   $
��Left=�6�   $��50��6�   $��
23,328,0,0q�6�   $	��Top=�6�   $	��142��6�   ��6Q   �� *UpdateCommand+{�6s   �� *	CanUpdate+6�   5'      5(      