   M S B A M L   `   `   `  ����F  BRVAProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RVAProjekat.ViewsRVAProjekat.Views  5   	   %    RVAProjekat.Views.AddUserWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RVAProjekat.Views     5   	     � Title$  AddUserView��5   	   $	��717��6   $	��566��6*    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L    � 	Resources 5	         TextBoxBaseControlTemplate �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers	 P� Property
 P� Value �� Value �� 
TargetName �� Property��%�  &	        �� 5
   
   " ��6=   .R�5      �� $ Bd��5      #��z��5      ���	#FF252323#��z��5      $ 5��6E   ._�5      �� $ PART_ContentHost��6   5       5      P� 5      	 � {�
 .  . �5      �� # � ��63   $ Bd��6u    � ���� 5      # � ��63    � ��5      P� 5      	 � ��$

 Auto��6+   . �5      ��  � ��$	 100��61   5      P� 5      	 � ��$

 Auto��6,   . �5      ��  � ��$ 20��62   5      5      5      .��5       � 
���   �.+�5!   
   �� $��Center=�6*   $
��Left=�6N   $��66��6i   $��
137,18,0,0q�6u   $	��Top=�6�   $	��299��6�   $��28(�6�   $��Segoe UI)�6�   ���	#FFFBFB9F��6   �� *Title+6�   �� 5#   
   #��[  6   $
��Left=�6I   $��39��6d    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��227��6�   $��170,163,0,0q�6�   ���	#FF2E2E2E���	#FFA7A9A8$��22(�6.  ��6�   �� *NewUser.Name+ �� UpdateSourceTrigger$ PropertyChanged=�6.  �� 5$   
   #��[  6   $
��Left=�6I   $��39��6d   $��170,259,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $	��227��6�   ���	#FF2E2E2E���	#FFA7A9A8$��22(�62  ��6�   �� *NewUser.LastName+$ PropertyChanged=�62  �� 5%   
   #��[  62   $
��Left=�6i   $��39��6�   $��170,351,0,0q�6�   $
 Wrap=�6�   $	��Top=�6   $	��227��6  ���	#FF2E2E2E���	#FFA7A9A8$��22(�6R   �� 
IsReadOnly 6   �� *
IsChange+��6�   �� *NewUser.Username+$ PropertyChanged=�6R  �� 5&   
   #��[  6   $
��Left=�6I   $��39��6d   $��170,451,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $	��227��6�    J� RenderTransformOrigin$ 0.476,0.506&�6  ���	#FF2E2E2E���	#FFA7A9A8$��22(�6V  ��6�   �� *NewUser.Password+$ PropertyChanged=�6V  �� 5'   
   $��Name:��6   $
��Left=�6!   $��40��6<   $��170,123,0,0q�6H   $	��Top=�6]   $	��227��6u   $��Segoe UI)�6�   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 5(   
   $��	Lastname:��6   $
��Left=�6%   $��42��6@   $��170,217,0,0q�6L   $	��Top=�6a   $	��227��6y   $��Segoe UI)�6�   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 5)   
   $��	Username:��6   $
��Left=�6%   $��36��6@   $��170,315,0,0q�6L   $	��Top=�6a   $	��227��6y   $��Segoe UI)�6�   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 5*   
   $��	Password:��6   $
��Left=�6%   $��37��6@   $��170,409,0,0q�6L   $	��Top=�6a   $	��227��6y   $��Segoe UI)�6�   ���	#FFFBFB9F$��22(�6�   $��Center=�6�   �� 5+   
   $	��ADD��6   $
��Left=�6a   $	��Top=�6|   $	��221��6�   $��176,582,0,0q�6�   $��63��6�   $��Segoe UI)�6�   ���	#FFFBFB9F
������ 
�������$��36(�6  $
��Bold"�6)  y�6   �� *	Visible+��6>   �� *AddUserCommand+6)  �� 5,   
   $��Segoe UI)�62   ���	#FFFBFB9F$��Admin��6_   $
��Left=�6�   $��45��6�   $��235,518,0,0q�6�   $	��Top=�6�   $��95��6  $��24(�6  ���	#FFFBFB9F���	#FF1F5076y�6   �� *	Visible+ d� 	IsChecked 6o   �� *Admin+$ PropertyChanged=�65  �� 5/   
   $
��Left=�6/   $��29��6J   $��170,194,0,0q�6V   $	��Top=�6k   $	��227��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *	ErrorName+6�   �� 50   
   $
��Left=�63   $��29��6N   $��170,286,0,0q�6Z   $	��Top=�6o   $	��227��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *ErrorLastname+6�   �� 51   
   $
��Left=�63   $��30��6N   $��170,384,0,0q�6Z   $	��Top=�6o   $	��227��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *ErrorUsername+6�   �� 52   
   $
��Left=�63   $��30��6N   $��170,483,0,0q�6Z   $	��Top=�6o   $	��227��6�   $��Segoe UI)�6�   
���  ��$��14(�6�   ��6   �� *ErrorPassword+6�   �� 54   
   $��CHANGE��6   $
��Left=�6h   $	��Top=�6�   $	��221��6�   $��176,582,0,0q�6�   $��63��6�   $��Segoe UI)�6�   ���	#FFFBFB9F
������ 
�������$��36(�6"  $
��Bold"�60  y�6"   �� *
Visible2+��6B   �� *ChangeInfoCommand+60  56      57      