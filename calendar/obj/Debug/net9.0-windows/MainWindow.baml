   M S B A M L   `   `   `  ����  calendar    CalendarApp.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Calendar App��5   	   $	��600��6   $	��800��6+   $	��500��67   $	��600��6G    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5	      ��  � ��$ 18(�6)   �� 5
       � ��
 �����6+   �� 5       � ��$ 2q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��0��5      $��前月��6   $
��Left=�6+   $	��150��6F   $��50��6R   6^   �� 5   
   -   5        $��0��5      $��次月��6   $��Right=�6+   $	��150��6G   $��50��6S   6_   �� 5   
   -   5        $��	MonthText��5   !   $��0��6   $��Center=�62   $��Center=�6O   $��24(�6j   5      A� 5!   
   -   5        $��DayGrid��5!   #   $��1��6    A� Columns$ 7��62   $��Stretch=�6>   $��Stretch=�6\   .+�5"      �� $	��日��6   �� 5#      $	��月��6   �� 5$      $	��火��6   �� 5%      $	��水��6   �� 5&      $	��木��6   �� 5'      $	��金��6   �� 5(      $	��土��6   5*      5+      5,      