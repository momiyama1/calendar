   M S B A M L   `   `   `  ����  calendar     CalendarApp.ScheduleDialog   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  予定の入力��5   	   $	��140��6   $	��300��6$    � 
ResizeMode$ 	CanResize=�60   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5
      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��ScheduleTextBox��5      $	��Top=�6)   $��10q�6A   $��50��6M   $��0��6Y   $��3��6f   �� 5   
   -   5        $��保存��5      $��Stretch=�6   $��Center=�6<   $��5q�6W   $��1��6b   $��0��6o   6   �� 5   
   -   5        $��削除��5      $��Stretch=�6   $��Center=�6<   $��5q�6W   $��1��6b   $��1��6o   6   �� 5!   
   -   5        $��キャンセル��5!      $��Stretch=�6!   $��Center=�6?   $��5q�6Z   $��1��6e   $��2��6r   6�   5"      5#      