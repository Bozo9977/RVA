   M S B A M L   `   `   `  ����F  BRVAProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RVAProjekat.ViewsRVAProjekat.Views  5   	   #    RVAProjekat.Views.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RVAProjekat.Views     5   	     � Title$  Login��5   	   $��504.733��6   $��490.146��6(    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N    � 	Resources 5	         FocusTextBox �� 
TargetType �� Triggers �� Binding �� ElementName �� Path	 �� Value
 �� Property �� Value��%�   &	        �� 5
   
   " �6%    5      �� 5       6   �� $ textBoxUsername��$ 	IsVisible�	 True6^   .a�5      �� 
 �@+�FocusedElement 6D   �� $ textBoxUsername��5      5      5      .��5      � -   5         �Name$ 	LoginGrid��5      
���   �$��0,0,0,-1q�61   #��[  6C   .+�5   
   �� $��Please login��6   $��Center=�6'   $��66��6K   $��
21,10,23,0q�6W   $	��Top=�6k   $��26(�6�   $��Segoe UI)�6�   ���	#FFFBFB9F6�   �� 5   
   $��	Username:��6   $��Center=�6$   $
��Left=�6H   $��34��6c   $��
113,93,0,0q�6o   $	��Top=�6�   $	��244��6�   $��Segoe UI)�6�   ���	#FFFBFB9F$��20(�6�   �� 5   
   -   5         ��Name$ textBoxUsername��5      $
��Left=�6+   $
��Left=�6F   $��Center=�6h   $��Khmer UI)�6�   $��20(�6�    �� TextWrapping$
 Wrap=�6�   $	��244��6  $��113,137,0,0q�6  ���	#FF2E2E2E���	#FF282829���	#FFFBFB9F$��39��6i  $	��Top=�6u  ��6�   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�   J� InputBindings 5      �� 5      
 �� Key$ Enter��6>    �� Command 6   �� *LoginCommand+6>   .��5   %   5      �� 5   
   -   5        $��usernameError��5   W   $��Center=�6l   $��Center=�6�   $
��Left=�6�   $��34��6�   $��
21,176,0,0q�6�   $	��Top=�6�   $	��440��6  $��Segoe UI)�6  
���  ��$��16(�68  ��6   �� *UsernameError+$ PropertyChanged=�68  �� 5   
   $��	Password:��6   $��Center=�6$   $
��Left=�6H   $��38��6c   $��113,218,0,0q�6o   $	��Top=�6�   $	��244��6�   $��Segoe UI)�6�   ���	#FFFBFB9F$��20(�6�   G� 5    
   -   5         G�Name$ PasswordBox��5       $
��Left=�6,   ���	#FF2E2E2E$��1q�6^   ���	#FF282829$
��Left=�6�   $��Center=�6�   $��34��6�   $	��243��6�   ���	#FFFBFB9F$��114,261,0,169q�6�   5"      �� 5%   
   -   5        $��passwordError��5%   W   $��Center=�6l   $��Center=�6�   $
��Left=�6�   $��34��6�   $��
21,323,0,0q�6�   $	��Top=�6�   $	��440��6  $��Segoe UI)�6  
���  ��$��16(�68  ��6   �� *PasswordError+$ PropertyChanged=�68  �� 5'   
   $��LOGIN��6    �� 	IsDefault . $
��Left=�6T   $��24(�6p   $	��Top=�6~   $	��130��6�   $��168,382,0,0q�6�   $��48��6�    J� RenderTransformOrigin$ 0.769,0.381&�6�   $��Segoe UI)�6�   
������ 
����������	#FFFBFB9F$
��Bold"�6B  ��63   �� *LoginCommand+6B  5)      5*      