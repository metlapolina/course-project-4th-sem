   M S B A M L   `   `   `  ����C  ?ToDoshka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToDoshkaToDoshka  5          ToDoshka.ToDoSubItem   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      "localclr-namespace:ToDoshka  5      .��5
      � .+�5   
   ��   �� CornerRadius$  10��6   
�������._�5      �  � ColumnDefinitions 5      �� 5      $
��1.1* �6'   �� 5      $��* �6'   .+�5      ]� $��0��6   .+�5      d� -   5         d�Name$ btn_SubtaskSolved��5   #   $��-15 -25 0 0q�6>   $��40��6S   $��40��6^   
������� )  %MaterialDesignActionLightToggleButton#��[  6�   6�   �� 5      -   5         ��Name$ txt_Subtask��5       �� 	MaxLength$ 30��63    �� 
IsReadOnly . $	��380��6T     tb_ToDoItem#���  6`   $��Center=�6�   5      �� 5      $��1��6   $��Right=�6-   $��0 0 5 0q�6I    �� Orientation$ 
Horizontal=�6Z   $��2��6s   .+�5      �� -   5         ��Name$ btn_EditSubtask��5        	_EditTask � ToolTip# �  66   $��0q�6z   $��30��6�   $��30��6�   $��-2 0 3 0q�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  -   5        	  Name$	 md_EditSubtask��5   2   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]
   Kind$

 Edit=�6J   
�������$��25��6i   $��25��6t   5      �� 5      -   5        $ btn_AddPhoto��5        _AddImg# �  63   $��0q�6r   $��30��6~   $��30��6�   $��0 0 3 0q�6�   .��5        -   5        $	 md_AddPhoto��5   2   $
 InsertPhoto=�6G   
�������$��25��6m   $��25��6x   5      �� 5      -   5        $ btn_AddFile��5        _AddFile# �  62   $��0q�6q   $��30��6}   $��30��6�   $��0 0 3 0q�6�   .��5        -   5        $	 
md_AddFile��5   2   $
 FileDocument=�6F   
�������$��25��6m   $��25��6x   5      �� 5       -	   5          _Delete# �  5       $��0q�6Z   $��30��6f   $��30��6q   .��5!        $
 Delete=�62   
�������$��25��6S   $��25��6^   5"      5#      5$      5%      5&      5'      