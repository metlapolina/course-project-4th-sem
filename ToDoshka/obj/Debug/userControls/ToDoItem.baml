   M S B A M L   `   `   `  ����C  ?ToDoshka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToDoshkaToDoshka  5          ToDoshka.ToDoItem   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      "localclr-namespace:ToDoshka  5      .��5
      � .+�5   
   ��   �� CornerRadius$  10��6   
�������._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $	��170 �6'   .+�5      ]� $��0��6   .+�5      d� -   5         d�Name$ btn_TaskSolved��5   #    d� 	IsChecked$ FalseY�6;   $��-15 -25 0 0q�6M   $��40��6b   $��40��6m   
������� )  %MaterialDesignActionLightToggleButton#��[  6�   6�   �� 5      -   5         ��Name$ txt_Task��5       �� 	MaxLength$ 40��60     tb_ToDoItem#���  6?   $��Center=�6e    �� 
IsReadOnly . 6�   5      �� 5      $��1��6   $��Right=�6-    �� Orientation$ 
Horizontal=�6I   $��0 0 5 0q�6b   .+�5      �� -   5         ��Name$ btn_EditTask��5        	_EditTask	 � ToolTip#	 �  63   $��0q�6t   $��30��6�   $��30��6�   $��0 0 3 0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        
  Name$
 md_EditTask��5   2   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$
 Edit=�6G   
�������$��25��6f   $��25��6q   5      �� 5      -   5        $ btn_Deadline��5        	_Deadline#	 �  63   $��0q�6Y   $��30��6e   $��30��6p   $��0 0 3 0q�6|   .��5      (  "System.Windows.Controls.DatePicker  -   5          Name$ dp_Deadline��5   %   $	��100��6:   $��55��6F   $��
-86 7 -3 0q�6R   $��8(�6�   
�������$��Center=�6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6�   5      �� 5        _Importance#	 �  6   $��0q�6E   $��0 0 3 0q�6Q   $��30��6b   $��30��6m   .��5      �� -   5         ��Name$ cb_Importance��5   #   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  !��6:   $��0 0 -9 0q�6^   $��26(�6p   $��	ExtraBold"�6~   
������ $��0q�6�   $��Center=�6�   $��Center=�6�   
�������$��30��6  $��30��6  .@�5      (  "MaterialDesignThemes.Wpf.RatingBar  -   5          Name$ BasicRatingBar��5   I   
   Max$ 3��67      Value$ 0��6?   
�������6t   5       5!      �� 5"      -	   5          _AddSub#	 �  5"      $��0q�6^   $��30��6j   $��30��6u   $��0 0 3 0q�6�   .��5#        $	 Add=�63   
�������$��25��6Q   $��25��6\   5$      �� 5%      -
   5          _Delete#	 �  5%      $��0q�6Z   $��30��6f   $��30��6q   .��5&        $ Delete=�62   
�������$��25��6S   $��25��6^   5'      5(      5)      5*      5+      5,      