   M S B A M L   `   `   `  ����  WPFCountDown    WPFCountDown.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5   	     � Title$  Tea Time. By Michael Z.��5   	   $	��161��6)   $	��280��66   ���	#FFCCFFCE � Icon$ tea.ico��6Y    � 	Resources 5         TrayStatusPopup��%   &	        J� 5   
   6   5      .��5	      � $��	0,0,2,-20q�6    � ColumnDefinitions 5
   
   �� 5      $	��54* �6   �� 5      $
��245* �6   .+�5   
   3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon     
IconSource$ tea.ico��6      ToolTipText$ Tea Tea Tea!!!��5       � ContextMenu 5      �� 5      
�������.@�5      m� -   5        $
��Show��5      6-   m� 5      -   5        $
��Exit��5      6-   5      5      �� 5   
   -   5        $��inputBox��5      $
��Left=�6"   $��23��6=   $��	21,41,0,0q�6I    �� TextWrapping$
 Wrap=�6\   $��5��6p   $	��Top=�6y   $��45��6�   $��2��6�   �� 5   
   $��Input Sleep Time:��6   $
��Left=�6,   $��	21,10,0,0q�6G   $	��Top=�6Z   $	��120��6r   $��2��6~   $��26��6�   �� 5   
   -   5        $��startBtn��5      $��Start��6!   $
��Left=�61   $��	21,84,0,0q�6L   $	��Top=�6_   $��75��6w   $��22��6�   $��2��6�   �� 5   
   $��Time Remain:��6   $
��Left=�6'   $��	87,10,0,0q�6B   $	��Top=�6U   $��86��6m   $��26��6x   $��1��6�   �� 5   
   -   5        $��tbRemain��5      $
��Left=�6"   $��25��6=   $��	87,41,0,0q�6I   $
 Wrap=�6\   $��0��6p   $	��Top=�6y   $	��120��6�    J� RenderTransformOrigin$ 
0.5,-0.304&�6�   $��1��6�   �� 5   
   -   5        $��cboxUnit��5      $
��Left=�6#   $��	34,41,0,0q�6>   $	��Top=�6Q   $��34��6i   $��22��6�   $��1��6�   �� 5   
   -   5        $��pauseBtn��5      $��Pause��6!   $
��Left=�61   $��	53,84,0,0q�6L   $	��Top=�6_   $��75��6w   $��22��6�   $��1��6�   �� 5   
   -   5        $��resetBtn��5      $��Reset��6!   $
��Left=�61   $��
133,84,0,0q�6L   $	��Top=�6`   $��75��6x   $��22��6�   $��1��6�   5       5!      