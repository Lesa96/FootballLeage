   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	       Client.Views.RegisterView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Client.Views     5   	     � Title$  Register��5   	   $	��320��6    � WindowStartupLocation$ CenterScreen=�6'    � 
ResizeMode$ CanMinimize=�6L    � Icon$ ../Pictures/ball.ico��6e   $	��300��6�   $��14(�6�   
�������.��5	      �� ���#2e3137 �� CornerRadius$ 20��6"   $��20q�64   ._�5
   
   �� $��20,20,20,-12q�6   .+�5      �� $��Register��6   
�������$��20(�6:   $��Center=�6H   �� 5      $��5��6   �� 5      $"��Username (barem 6 karaktera)��6   
�������6;   �� 5      ���#545d6a
�������$��18(�6X   ��6   �� *
Username+6X   �� 5      $"��Password (barem 6 karaktera)��6   
�������6;   G� 5      -   5         G�Name$ PassBox��5      ���#545d6a
�������$��18(�6T   6d   �� 5      $��Register��6      RoundButton#��[  6(    � Cursor$
 Hand��6M   
������$
��Left=�6�   $��34��6�   $��5,10,0,0q�6�   $	��Top=�6  $	��194��6  ��6t   �� *RegisterCommand+��6�   ��  �� ElementName$ PassBox��6  5      5      5      