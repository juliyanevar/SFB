   M S B A M L   `   `   `  ����>  :SFB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SFB.Admin	SFB.Admin  5          SFB.Admin.MainAdminView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      #localclr-namespace:SFB.Admin  5         MainAdminViewModel  � DataContext#  [  5	        MaterialDesign � 	Resources# [ 5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   � ���#673ab7.+�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� ��6   Z� ��64   Z� ��6K   �� *ToLoginCommand+.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ UserConvert=�62   $��20��6E   $��20��6Q   5      �� 5      $��Change user��6    $��12(�63   $��10q�6A   $��Center=�6M   
�������6h   5      �� 5      $ 
Horizontal=�6   .+�5        $
 Home=�6.   $��15q�6:   
�������6F   �� 5      $
��Home��6   $��Center=�6,   ��6G   Z� ��6]   Z� ��6t   �� *HomePageCommand+5      �� 5      $��Content��6   $��15q�6+   $��DemiBold"�67   
�������6M   �� 5       $��15(�6   
������� �� SelectedIndex 6)   �� *SelectedPage+ �� Mode$ TwoWay=�.@�5!      �� $��1q�6#   .��5"      �� $ 
Horizontal=�6%   .+�5#        $ Monitor=�66   $��15q�6E   �� 5$      $��Serials and actors��6(   $��Center=�6B   5%      5&      �� 5'      $��1q�6#   .��5(      �� $ 
Horizontal=�6%   .+�5)        $ FilmOpenOutline=�66   $��15q�6M   �� 5*      $��Films and actors��6(   $��Center=�6@   5+      5,      �� 5-      $��1q�6#   .��5.      �� $ 
Horizontal=�6%   .+�5/        $ BookOpenOutline=�66   $��15q�6M   �� 50      $��Books��6(   $��Center=�65   51      52      53      54      55      � 56   
   $��1��6   
�������.+�57      �� $ 
Horizontal=�6   .+�58      � $	��600��6   $	��830��6$   .+�59      �� ��6%   �� *MainUserControl+5:      � 5;      .+�5<      �� $ Vertical=�6!   $	��Top=�68   .+�5=      ��  & "MaterialDesignIconForegroundButton#��[ 6!   ��6^   �� *CloseWindowCommand+.��5>        $ WindowClose=�66   $��25��6I   $��25��6U   5?      5@      5A      5B      5C      5D      5E      