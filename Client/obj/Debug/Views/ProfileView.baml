   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	   +clr-namespace:Client.ViewsClient.Views  5   	   +clr-namespace:Client.ModelClient.Model  5   	   5clr-namespace:Client.ViewModelsClient.ViewModels  5	   	       Client.Views.ProfileView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Client.Views     5   	   ,viewsclr-namespace:Client.Views     5   	   +dataclr-namespace:Client.Model     5   	   5	viewmodelclr-namespace:Client.ViewModels     5	   	     � Title$  Profile��5   	    � WindowStartupLocation$ CenterScreen=�6    � Icon$ ../Pictures/profil.ico��6>    � 
ResizeMode$ CanMinimize=�6\   $	��450��6u   $	��770��6�   
������� � 	Resources 5       �� DataType*   $Client.ViewModels.MyProfileVIewModel    Client.Views.MyProfileVIew*   $Client.ViewModels.KorisniciVIewModel    Client.Views.KorisniciView��%�   (��       5      *, +)(�� 7     5      *, +)�� 5   
   "  6   .R�5        6$   5      �� 5   
   "  6   .R�5        6$   5      5      .��5      � .+�5   
   ]� .+�5      o� $	��Top=�6   .@�5      m� -   5         m�Name$
 Back��5      $��Povratak Nazad��6)    m� CommandParameter$ myBack��5      $	��108��5      
���   �$��30��5       � Cursor$
 Hand��6'   	 m� Command	 5   A   �� *
NavCommand+5   '   m� 5      $	��108��6   $y�Hidden=�6'   m� 5      $	��108��6   $y�Hidden=�6'   m� 5      $	��100��6   $y�Hidden=�6'   m� 5      -   5        $ 	Korisnici��5      $��Regularni korisnici��6.   $ myKorisnici��5       $	��108��5!      
���   �$��30��5#      $
 Hand��6'   y�5   K   �� *
Visibility+	 6m   �� *
NavCommand+5#   '   m� 5$      -   5        $ Profil��5$      $��
Moj profil��6+   $ myProfil��5%      $	��108��5&      
���   �
�������$��30��5(      $
 Hand��6'   	 5$   ?   �� *
NavCommand+5(   '   m� 5)      -   5        $ LogOut��5)      $��
Izloguj se��6+   $ myLogOut��5*      $	��108��5+      
���   �$��30��5-      $
 Hand��6'   	 5)   @   �� *
NavCommand+5-   '   5/      �� 50      ���#2e3137
 �� CornerRadius$
 20��6*   $��20q�6<   ._�51      � .+�52      �� ��6%   �� *CurrentViewModel+53      54      56      57      59      