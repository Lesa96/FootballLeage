   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	   clr-namespace:ClientClient  5   	   +clr-namespace:Client.ViewsClient.Views  5   	   5clr-namespace:Client.ViewModelsClient.ViewModels  5	   	   clr-namespace:ClientClient  5
   	       Client.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	   *	viewmodelclr-namespace:Client     5   	   ,viewsclr-namespace:Client.Views     5   	   6
viewModelsclr-namespace:Client.ViewModels     5	   	   $vmlclr-namespace:Client     5
   	     � Title$  Fudbalska Liga��5   	   
������� � Icon$ Pictures/ball.ico��63    � WindowStartupLocation$ CenterScreen=�6L   $	��530��6r   $	��818��6    � 
ResizeMode$ CanMinimize=�6�    � 	Resources 5       �� DataType%   Client.ViewModels.LigaViewModel   Client.Views.LigaView%   Client.ViewModels.KlubViewModel   Client.Views.KlubView'   !Client.ViewModels.TrenerViewModel   Client.Views.TrenerView&    Client.ViewModels.IgracViewModel   Client.Views.IgracView'	   !Client.ViewModels.SudijaViewModel
   Client.Views.SudijaView(   "Client.ViewModels.NavijacViewModel   Client.Views.NavijacView(   "Client.ViewModels.StadionViewModel   Client.Views.StadionView-   'Client.ViewModels.ObezbedjenjeViewModel#   Client.Views.ObezbedjenjeView(   "Client.ViewModels.VlasnikViewModel   Client.Views.VlasnikView)   #Client.ViewModels.MenadzerViewModel   Client.Views.MenadzerView��%   (��       5      *, +)(�� 7     5      *, +)(�� n     5      *, +)(�� �     5       *, +)(�� �     5$      *,	 +)(��     5(      *, +)(�� J    5,      *, +)(�� �    50      *, +)(�� �    54      *, +)(�� �    58      *, +)�� 5   
   "  6   .R�5        6   5      �� 5   
   "  6   .R�5        6   5      �� 5   
   "  6   .R�5        6!   5      �� 5    
   "  6   .R�5!        6    5#      �� 5$   
   " 	 6   .R�5%      
  6!   5'      �� 5(   
   "  6   .R�5)        6"   5+      �� 5,   
   "  6   .R�5-        6"   5/      �� 50   
   "  6   .R�51        6'   53      �� 54   
   "  6   .R�55        6"   57      �� 58   
   "  6   .R�59        6#   5;      5=      .��5>      � .+�5@   
   ]� $��0��6   .+�5A      o� $	��Top=�6   .@�5B      m� -   5         m�Name$ LigaMenu��5B      $
��LIGA��6.    m� CommandParameter$ myLiga��5C      $��73��5D      
���   �$��30��5F       � Cursor$
 Hand��6(   	 m� Command	 5B   <   �� *
NavCommand+5F   (   m� 5G      -   5        $ KlubMenu��5G      $
��KLUB��6-   $ myKlub��5H      $��73��5I      
���   �$��30��5K      $
 Hand��6'   	 5G   ;   �� *
NavCommand+5K   '   m� 5L      -   5        $ 	IgracMenu��5L      $��IGRAC��6.   $ myIgrac��5M      $��73��5N      
���   �$��30��5P      $
 Hand��6'   	 5L   =   �� *
NavCommand+5P   '   m� 5Q      -   5        $ 
TrenerMenu��5Q      $��TRENER��6/   $ myTrener��5R      $��73��5S      
���   �$��30��5U      $
 Hand��6'   	 5Q   ?   �� *
NavCommand+5U   '   m� 5V      -   5        $ 
SudijaMenu��5V      $��SUDIJA��6/   $ mySudija��5W      $��73��5X      
���   �$��30��5Z      $
 Hand��6'   	 5V   ?   �� *
NavCommand+5Z   '   m� 5[      -   5        $ NavijacMenu��5[      $��NAVIJAC��60   $ 	myNavijac��5\      $��73��5]      
���   �$��30��5_      $
 Hand��6'   	 5[   A   �� *
NavCommand+5_   '   m� 5`      -   5        $ StadionMenu��5`      $��STADION��60   $ 	myStadion��5a      $��73��5b      
���   �$��30��5d      $
 Hand��6'   	 5`   A   �� *
NavCommand+5d   '   m� 5e      -   5        $ 
RadnikMenu��5e      $��RADNIK��6/   $ myObezbedjenje��5f      $��73��5g      
���   �$��30��5i      $
 Hand��6'   	 5e   ?   �� *
NavCommand+5i   '   m� 5j      -	   5        $ VlasnikMenu��5j      $��VLASNIK��60   $ 	myVlasnik��5k      $��73��5l      
���   �$��30��5n      $
 Hand��6'   	 5j   A   �� *
NavCommand+5n   '   m� 5o      -
   5        $ MenadzerMenu��5o      $��MENADZER��61   $ 
myMenadzer��5p      $��73��5q      
���   �$��30��5s      $
 Hand��6'   	 5o   C   �� *
NavCommand+5s   '   m� 5t      $y�Hidden=�6   $��35��6/   m� 5u      -   5        $ 
ProfilMenu��5u      $��Profil��6/   $ myProfil��5v      $��36��5w      
�������$��Italic$�5x   .   $��	Underline)�6L   
��� d �$��0q�6�   $��30��5y      $
 Hand��6'   	 5u   ?   �� *
NavCommand+5y   '   5{      5|      � 5}   
   $��0,32,0,0q�6   ��5~      �� 5      
 �� ImageSource$
 Pictures/PocetnaLiga.jpg��6   6F   .+�5�      �� ��6   �� *CurrentViewModel+5�      5�      5�      