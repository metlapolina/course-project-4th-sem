   M S B A M L   `   `   `  ����C  ?ToDoshka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToDoshkaToDoshka  5           ToDoshka.StatisticsControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:ToDoshka     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NOxyPlot.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5      .��5      � 
������ .+�5   
   �� .+�5      �� $��Center=�6     �� Orientation$  
Horizontal=�66   .+�5      �� $��16(�6      	_FromDate#���   6&   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dp_Start��5      
�������$��80��6C   �� 5      $��16(�6     _ToDate#���  6&     5      -   5        $ 	dp_Finish��5      
�������$��80��6D   �� 5      -   5         ��Name$ 	btn_Build��5      $��10 0 0 0q�6,   
������   	_DblClick � ToolTip# �  6W   
������� 
 _Build#���  6�   6�   5        OxyPlot.Wpf.Plot  5      -   5          Name$ oxy_Plot��5         PlotAreaBorderColor$ White��6)   
������ $��0 10 0 0q�6^   $	��350��6p   $	��300��6|      Series 5        OxyPlot.Wpf.LineSeries  5        OxyPlot.Wpf.Series   Color$ Black��6%     _LegendTasks   Title# �  63   !  OxyPlot.Wpf.DataPointSeries	   
DataFieldX$
	 Date��6[   
   
DataFieldY$
 Value��6m      StrokeThickness$ 1Q�6�      
MarkerSize$ 3Q�6�      
MarkerType$
 Plus=�6�   ��6�   �� *Points+   Axes 5        OxyPlot.Wpf.LinearAxis  5        OxyPlot.Wpf.Axis   TicklineColor$ White��6%      	TextColor$ White��6;      Position$
 Left=�6M      Minimum$ 0Q�6]     OxyPlot.Wpf.DateTimeAxis  5         StringFormat$ 
dd.MM.yyyy��6'   $ White��6A   $ White��6W   $ Bottom=�6i   5      �� 5      -   5         ��Name$ lbl_Scheduled��5        
_Scheduled#���  6+   $��16(�6R   $��Center=�6`   
�������6}   �� 5      -   5        $ lbl_Completed��5        
_Completed#���  6+   $��16(�6R   $��0q�6`   $��Center=�6l   
�������6�   5      5       5!      