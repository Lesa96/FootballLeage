   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      +clr-namespace:Client.ViewsClient.Views  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5	          Client.Views.VlasnikView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      ,viewsclr-namespace:Client.Views     5      6
viewModelsclr-namespace:Client.ViewModels     5	        � 	Resources  5       �� DataType+   %Client.ViewModels.AddVlasnikViewModel!   Client.Views.AddVlasnikView,   &Client.ViewModels.ShowVlasnikViewModel"   Client.Views.ShowVlasnikView.   (Client.ViewModels.UpdateVlasnikViewModel$   Client.Views.UpdateVlasnikView��%�   (��       5      *, +)(�� 7     5      *, +)(�� n     5      *, +)�� 5   
   "  6   .R�5        6%   5      �� 5   
   "  6   .R�5        6&   5      �� 5   
   "  6   .R�5        6(   5      5      .��5      � .+�5   
   ]� .+�5      o� $	��Top=�6   .@�5      m� -   5         m�Name$
 Show��5      $��Prikazi Vlasnike��6)    m� CommandParameter$ myShow��5      
�������$	��108��5       
���   �$��30��5"       � Cursor$
 Hand��6'    m� Command 5   C   �� *
NavCommand+5"   '   m� 5#      -   5        $	 Add��5#      $��Dodaj Vlasnika��6(   $ myAdd��5$      $	��108��5%      
���   �$��30��5'      $
 Hand��6'   y�5#   @   �� *
Visibility+ 6b   �� *
NavCommand+5'   '   m� 5(      -   5        $ Update��5(      $��Promeni Vlasnika��6+   $ myUpdate��5)      $	��108��5*      
���   �$��30��5,      $
 Hand��6'   y�5(   E   �� *
Visibility+ 6g   �� *
NavCommand+5,   '   5.      5/      � 50   
   $��0,33,0,0q�6   ��51      �� 52       �� ImageSource$! ../Pictures/PocetnaLiga.jpg��6   6I   .+�54      �� ��6   �� *CurrentViewModel+55      56      57      