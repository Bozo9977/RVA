   M S B A M L   `   `   `  ����F  BRVAProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RVAProjekat.ViewsRVAProjekat.Views  5   	   )    #RVAProjekat.Views.ModifyCheckWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RVAProjekat.Views     5   	     � Title$  ModifyCheckWindow��5   	   $	��376��6#   $	��570��60    � WindowStartupLocation$ CenterScreen=�6<    � 
ResizeMode$ NoResize=�6a    � 	Resources 5	      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value ��Name �� 
IsReadOnly	 �� Path
 �� StringFormat �� RelativeSource �� AncestorType(  "System.Windows.Controls.DatePicker��%�   '        �� 5
   
   "  6   .�5      ��  � �� 5      �� 5      .R�5      �� $ PART_TextBox��6"    . ��5      �� $	 SelectedDate�$
 dd MMM yyyy�� �� "  5      5      5      5      .��5      � 
���   �.+�5   
     -   5          Name$ 
DatePicker��5      $��Center=�6)   $��40��6G   $��
10,78,10,0q�6S   
������ 
���   �$��22(�6�   $	��Top=�6�   $	��544��6     SelectedDate 6�   �� *SelectedDate+ �� Mode$ TwoWay=�$
 
dd/MM/yyyy��6  �� 5   
   -   5         ��Name$ button��5      $��ModifyCheck��6B   
�������$��22(�6l   ���	#FFFBFB9F
������ $��Center=�6�   $��64��6�   $��179,239,171,0q�6�   $	��Top=�6�   $	��214��6  ��6!   �� *ModifyCheck+6  �� 5   
   -   5         ��Name$ label��5      
���  ��$��24(�6t   $��Center=�6�   $��Center=�6�   $
��Left=�6�   $��53��6�   $��
10,157,0,0q�6�   $	��Top=�6  $	��544��6  ��6   �� *
ErrorLabel+ �� UpdateSourceTrigger$ PropertyChanged=�6  5      5      