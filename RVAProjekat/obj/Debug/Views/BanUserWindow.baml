   M S B A M L   `   `   `  ����F  BRVAProjekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RVAProjekat.ViewsRVAProjekat.Views  5   	   %    RVAProjekat.Views.BanUserWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RVAProjekat.Views     5   	     � Title$  BanUserWindow��5   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68   .��5	      � 
���   �.+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridUser��5
      $
��Left=�6�   $	��224��6�   $��0,60,0,0q�6�   $	��Top=�6�   $	��397��6�      AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6+  ��6)   �� *Users+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� SelectedItem 6y   �� *SelectedUser+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6%    �� TextAlignment$ Center=�63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *Name+   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$
 Wrap=�6=   �� 5       � ��$ Center=�6D   �� 5       � ��$ Center=�6B   5      5        5      $
 	Last Name��6%   $ Center=�68    6Y   �� *
LastName+ 5      �� 5      " ��6    .�5      ��  � ��$
 Wrap=�6=   �� 5       � ��$ Center=�6D   �� 5       � ��$ Center=�6B   5      5        5!      $
 Username��6%   $ Center=�67    6X   �� *
Username+ 5"      �� 5#      " ��6    .�5$      ��  � ��$
 Wrap=�6=   �� 5%       � ��$ Center=�6D   �� 5&       � ��$ Center=�6B   5'      5)        5+      $

 Type��6%   $ Center=�63      
IsReadOnly .  6T   �� *Type+ 5,      �� 5-      " ��6    .�5.      ��  � ��$
 Wrap=�6=   �� 5/       � ��$ Center=�6D   �� 50       � ��$ Center=�6B   51      53      56        58   
   -   5        $ dataGridGate��58      $
��Left=�6�   $	��224��6�   $��
402,60,0,0q�6�   $	��Top=�6�   $	��390��6�    .   . $ * 6.  ��6*   �� *Gates+$ PropertyChanged=�$ TwoWay=� 6z   �� *SelectedGate+	 59        5:      $
 GateID��6%   $ Center=�65    .  6V   �� *GateID+ 5;      �� 5<      " ��6    .�5=      ��  � ��$
 Wrap=�6=   �� 5>       � ��$ Center=�6D   �� 5?       � ��$ Center=�6B   5@      5B        5D      $

 Name��6%   $ Center=�63    .  6T   �� *Name+ 5E      �� 5F      " ��6    .�5G      ��  � ��$
 Wrap=�6=   �� 5H       � ��$ Center=�6D   �� 5I       � ��$ Center=�6B   5J      5L      5O      �� 5P   
   -   5         ��Name$ button��5P      $��Ban User��6!   
������ $��Segoe UI)�6i   ���	#FFFBFB9F
���  ��$��22(�6�   $
��Left=�6�   $��44��6�   $��329,365,0,0q�6�   $	��Top=�6�   $	��132��6
  ��64   �� *	BanUser+6
  �� 5Q   
   -   5         ��Name$ label��5Q      $��Select User��6   ���	#FFFBFB9F$��22(�6L   $
��Left=�6Z   $��45��6u   $��	10,10,0,0q�6�   $	��Top=�6�   $	��341��6�   �� 5R   
   -   5        $ 
label_Copy��5R      $��Select Gate��6$   ���	#FFFBFB9F$��22(�6Q   $
��Left=�6_   $��45��6z   $��
402,10,0,0q�6�   $	��Top=�6�   $	��341��6�   �� 5S   
   -   5        $ label1��5S      
���  ��$��24(�6u   $��Center=�6�   $��Center=�6�   $
��Left=�6�   $��43��6�   $��	0,300,0,0q�6�   $	��Top=�6  $	��792��6  ��6    �� *
ErrorLabel+$ PropertyChanged=�6  5U      5V      