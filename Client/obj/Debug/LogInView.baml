   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.LogInView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	     � Title$  LogIn��5   	   $	��320��6    � WindowStartupLocation$ CenterScreen=�6$    � 
ResizeMode$ CanMinimize=�6I    � Icon$ Pictures/ball.ico��6b   $	��300��6{   $��14(�6�   
������� � 	Resources 5	         MyButton �� 
TargetType �� Property �� Value �� 
TargetType	 �� Triggers
 P� Property P� Value��%�  &	        �� 5
   
   " ��6!   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver . . �5   "   ��  �@J�Opacity$	 0.8Q�6<   5      5      5      5      5      .��5      �� ���#2e3137 �� CornerRadius$ 20��6"   $��20q�64   ._�5   
   �� $��20,20,20,-12q�6   .+�5       �� $��Log In��6   
�������$��20(�68   $��Center=�6F   �� 5!      $��5��6   �� 5"      $��Username��6   
�������6'   �� 5#      ���#545d6a
�������$��18(�6X   ��6   �� *
Username+6X   �� 5$      $��Password��6   
�������6'   G� 5%      -   5         G�Name$ PassBox��5%      ���#545d6a
�������$��18(�6T   6d   �� 5&      $��Log In��6     RoundButton#��[ 6&    � Cursor$
 Hand��6K   $
��Left=�6�   $��34��6�   $��5,10,0,0q�6�   $	��Top=�6  $	��194��6  ��6Z   �� *LogInCommand+��6{   ��  �� ElementName$ PassBox��{�6�   �� *
CanLogIn+6  �� 5'      -   5         ��Name$ 	RegButton��5'      #��[  6(   $��Registruj se��6J   $
 Hand��6b   ���#2e3137$
��Left=�6�   
���/������#2e3137$
��65,0q�6�   ��6�   �� *RegisterCommand+6�   5(      5*      5+      