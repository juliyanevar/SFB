   M S B A M L   `   `   `  ���� >  :SFB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SFB.MainSFB.Main      SFB.Main.MainView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:SFB.Main     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MainViewModel  � DataContext#  [    MaterialDesign � 	Resources# [ $��15(�$	��600��$
��1080��.���  � ColumnDefinitions �� $	��200 ��� $��* �.+�� ���#673ab7.+��� .+���  �� Orientation$ 
Horizontal=�.+��� ��Z� ��Z� ���� *ToLoginCommand+.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ UserConvert=�$��20��$��20���� $��Change user��$��12(�$��10q�$��Center=�
��������� $ 
Horizontal=�.+�  $
 Home=�$��15q�
��������� $
��Home��$��Center=���Z� ��Z� ���� *HomePageCommand+�� $��Content��$��15q�$��DemiBold"�
��������� $��15(�
������� �� SelectedIndex �� *SelectedPage+ �� Mode$ TwoWay=�.@��� $��1q�.���� $ 
Horizontal=�.+�  $ Monitor=�$��15q��� $��Serials��$��Center=��� $��1q�.���� $ 
Horizontal=�.+�  $ FilmOpenOutline=�$��15q��� $��Films��$��Center=��� $��1q�.���� $ 
Horizontal=�.+�  $ BookOpenOutline=�$��15q��� $��Books��$��Center=�� $��1��
�������.+��� $ 
Horizontal=�.+�� $	��600��$	��830��.+��� ���� *MainUserControl+� .+��� $ Vertical=�$	��Top=�.+���  & "MaterialDesignIconForegroundButton#��[  � ToolTip$( "MaterialDesignIconForegroundButton������ *CloseWindowCommand+.��  $ WindowClose=�$��25��$��25��