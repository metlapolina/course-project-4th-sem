   M S B A M L   `   `   `  ����C  ?ToDoshka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToDoshkaToDoshka  5   	       ToDoshka.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   "localclr-namespace:ToDoshka  5   	     � Title$  ToDoshka��5	   	   $	��600��6   $
��1000��6'    � Icon$ /resources/icon/todo1.ico��64    � WindowStartupLocation$ CenterScreen=�6U   $��Century Gothic)�6z   $��20(�6�   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��8* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��1.5* �6#   �� 5      $��3* �6#   �� 5      $
��1.5* �6#   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6)   $
��Left=�6C   $��Center=�6^   $��20 0 0 0q�6y   .+�5      �� -   5         ��Name$ 	cb_Search��5      $y�Hidden=�6.   $��0��6B   6L   '  !MaterialDesignThemes.Wpf.PackIcon  5      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6*   $��27��68   $��27��6C   $��2 5 0 0q�6O   �� 5      -   5         ��Name$ 
txt_Search��5      	 �� 	MaxLength$	 30��6.      _Search)  #MaterialDesignThemes.Wpf.HintAssist
   Hint#
 �   6=   $��18(�6x   $	��200��6�   $��27��6�   6�   5      �� 5      $��1��6   $��ToDoshka��6$     lbl_ToDoshka#���  67   �� 5      $��2��6   $ 
Horizontal=�6)   $��Right=�6B   $��Center=�6^   $��0 0 10 0q�6y   .+�5       �� -   5        $ cb_Alert��5       $y�Hidden=�6-   $��0��6A   6K   �� 5!      -   5         
 _About � ToolTip# �  5!      
������ 
������ $��0q�6o    � Cursor$
 Hand��6{   .��5"        $ QuestionMarkCircleOutline=�6.   $��30��6O   $��30��6Z   5#      �� 5$      -   5         
 _Alert# �  5$      
������ 
������ $��0q�6o   $��25 0 0 0q�6{   $��40��6�   $��40��6�   $
 Hand��6�   .��5%      %  MaterialDesignThemes.Wpf.Badged  -   5          Name$ 	md_Badged��5%   ,     ControlzEx.BadgedEx   Badge$ 0��6?   .��5&        $ BellRingOutline=�62   $��30��6I   $��30��6T   5'      5(      �� 5)      -   5          	_MainPage# �  5)      
������ 
������ $��0q�6r   $��	25 0 20 0q�6~   $
 Hand��6�   .��5*        $
 Menu=�6.   $��30��6:   $��30��6E   5+      5,      5-       � 5/   
   -   5          �Name$ 	MainFrame��5/      $��1��6#     � NavigationUIVisibility$ Hidden=�60   50      51      