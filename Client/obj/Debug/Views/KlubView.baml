   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      +clr-namespace:Client.ModelClient.Model  5      +clr-namespace:Client.ViewsClient.Views  5      5clr-namespace:Client.ViewModelsClient.ViewModels  5	      clr-namespace:ClientClient  5
          Client.Views.KlubView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      +dataclr-namespace:Client.Model     5      ,viewsclr-namespace:Client.Views     5      6
viewModelsclr-namespace:Client.ViewModels     5	      $vmlclr-namespace:Client     5
        � 	Resources  5       �� DataType(   "Client.ViewModels.AddKlubViewModel   Client.Views.AddKlubView)   #Client.ViewModels.ShowKlubViewModel   Client.Views.ShowKlubView+   %Client.ViewModels.UpdateKlubViewModel!   Client.Views.UpdateKlubView��%�   (��       5      *, +)(�� 7     5      *, +)(�� n     5      *, +)�� 5   
   "  6   .R�5        6"   5      �� 5   
   "  6   .R�5        6#   5      �� 5   
   "  6   .R�5        6%   5      5      .��5      � .+�5   
   ]� .+�5      o� $	��Top=�6   .@�5       m� -   5         m�Name$
 Show��5       $��Prikazi klubove��6)    m� CommandParameter$ myShow��5!      
�������$	��108��5"      
���   � � Cursor$
 Hand��5#   /   $��30��5$       m� Command 5    B   �� *
NavCommand+5$      m� 5%      -   5        $	 Add��5%      $��
Dodaj Klub��6(   $ myAdd��5&      $	��108��5'      
���   �$
 Hand��5(   /   $��30��5)      y�5%   <   �� *
Visibility+ 6^   �� *
NavCommand+5)      m� 5*      -   5        $ Update��5*      $��Promeni klub��6+   $ myUpdate��5+      $	��108��5,      
���   �$
 Hand��5-   /   $��30��5.      y�5*   A   �� *
Visibility+ 6c   �� *
NavCommand+5.      50      51      � 53   
   $��0,33,0,0q�6   ��54      �� 55       �� ImageSource$! ../Pictures/PocetnaLiga.jpg��6   6I   .+�57      �� ��6   �� *CurrentViewModel+58      5:      5;      