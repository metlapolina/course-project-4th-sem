   M S B A M L   `   `   `  ����C  ?ToDoshka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToDoshkaToDoshka  5          ToDoshka.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      "localclr-namespace:ToDoshka  5        N� Title$  MainPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.4* �6   $	��150��6,   $	��300��6;   �� 5      $��3* �6   $	��300��6*   $
��1000��69   �� 5      $
��1.6* �6   $	��150��6,   $	��300��6;   .+�5   
   � $��0��6      gd_ProfileColor#���   6    � RowDefinitions 5      �� 5      $	��270 �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� $��0��6   .+�5      �� $��0q�6   
������ 
������ $	��150��6X   $	��150��6d   $
��0 15q�6q   .��5      A� $	��150��6   $	��150��6*   ��5      �� 5      -   5        img_ProfilePhoto�� �� ImageSource$ /resources/icon/todo.png��5   C    j� Stretch$ UniformToFill=�6j    j� 
AlignmentX$ Center=�6�    j� 
AlignmentY$ Center=�6�   5       5!      �� 5"      -   5         ��Name$ lbl_Name��5"      $��Surname Name��6*   $��18(�6A   $��Center=�6O   �� 5#      -   5        $ lbl_Discription��5#      $�� ��61   $��16(�6<   $��Italic$�6J   $��Center=�6]   5$      �� 5%      -   5        $��1��5%        _Profile#���  6"   $��70��6G   
�������
������ 
������ $��20(�6�   6�   �� 5&      -   5        $��2��5&        _Statistics#���  6"   $��70��6J   
�������
������ 
������ $��20(�6�   6�   �� 5'      -   5        $��3��5'       	 _Exit#���  6"   $��70��6D   
�������
������ 
������ $��20(�6�   6�   5(      �� 5*   
   $��0��6   � 5,   
   $��1��6   .+�5-      A�  A� Columns$ 2��6   $��0 0 5 0q�6&   .+�5.      � -   5        $��c1��5.   #   � 5/      -   5        $��c2��5/   #   50      �� 52      -	   5        	 ��Name$	 
tabControl��52   4   
 �� TabStripPlacement$
 Bottom=�6   
������ 
������ .@�53      ��   ti_Tasks#���  6     _PersonalTask#���  6=   $��50��6�   ��6f   ��  �� ElementName$ c1�� �� Path$ ActualWidth���54      � 55        gd_ColorTasks#���  6    56      �� 57   "   $��60 �60   �� 58   "   $��* �60   .+�5:      �� $��0��6)   $��Center=�66   $��Center=�6S    �� Orientation$ 
Horizontal=�6n   .+�5;   "   �� -
   5         ��Name$ txt_AddTaskP��5;   *    �� 	MaxLength$ 40��6@     _AddTask)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6O   
�������$��18(�6�   $	��360��6�   $��30��6�   �� 5<   "   -   5        $��50��5<   )   $��50��65    � ToolTip# �  6@   $��0q�6e   
������ 
������ .��5=   &   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ 	AddCircle=�6>   
�������$��45��6b   $��45��6m   $��	-10 0 0 0q�6y   5>   #   5?      �� 5@      $��1��6+   $
��Auto��68   $
��Auto=�6F   .��5A   "   �� -   5         ��Name$ 
pnl_TasksP��5A   -   5B      5C      5E      �� 5F      #���  6     	_WorkTask#���  6=   $��50��6�   ��6b   �� $ c2��$ ActualWidth���5G      � 5H      #���  6    5I      �� 5J   "   $��60 �60   �� 5K   "   $��* �60   .+�5M      �� $��0��6)   $��Center=�66   $��Center=�6S   $ 
Horizontal=�6n   .+�5N   "   �� -   5        $ txt_AddTaskW��5N   *   $ 40��6@   # �  6O   
�������$��18(�6�   $	��360��6�   $��30��6�   �� 5O   "   -   5        $��50��5O   )   $��50��65   $��0q�6@   
������ 
������ .��5P   &     $ 	AddCircle=�6>   
�������$��45��6b   $��45��6m   $��	-10 0 0 0q�6y   5Q   #   5R      �� 5S      $��1��6+   $
��Auto��68   $
��Auto=�6F   .��5T   "   �� -   5        $ 
pnl_TasksW��5T   -   5U      5V      5X      5Y      5Z      �� 5\   
   $��1��6   � 5^   
   $��2��6   #���  6     5_      �� 5`      $	��350 �6    �� 5a      $��* �6    �� 5b      $��* �6    �� 5c      $��* �6    �� 5d      $��* �6    �� 5e      $��* �6    .+�5g      &   System.Windows.Controls.Calendar  $��2��6   $��Center=�6'    � Language$ en�6D   ]� 5h      $	��5 5q�6   $��1��6%   .+�5i        $ CalendarCheck=�6*   $��20��6?   $��20��6J   $��Center=�6V   $	��3 0q�6q   
�������$
��Left=�6�   �� 5j      -   5         ��Name$ txt_Date��5j      $��16(�6.    	 _CurrentDate#��� 	 6<   
�������$��Center=�6u   5k      �� 5l      -   5        $ lbl_Scheduled��5l      $��2��6+    
 
_Scheduled#��� 
 68   $��16(�6_   �� 5m      -   5        $ lbl_Completed��5m      $��3��6+     
_Completed#���  68   $��16(�6_   �� 5n      -   5          	_AllTasks#���  5n      $��4��6;   $��16(�6H   
�������
������ 
������ 6�   5o      5p      5q      