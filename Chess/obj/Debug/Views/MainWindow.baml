   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      @ <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Chess.ViewModelsChess.ViewModels 5         Chess.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -vmclr-namespace:Chess.ViewModels     5      b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1(j http://www.galasoft.ch/mvvmlight  5        � WindowStartupLocation$  CenterScreen=�5   	      MainWindowTitle � Title# �   5   	   $	��650��63   $	��750��6@   $	��750��5   	   $	��650��6     MainWindowBrush#���  5   	    � 
ResizeMode$ NoResize=�5   	    � DataContext 5      $ Chess.ViewModels.MainViewModel  5   
    � 	Resources 5       �� 
TargetType  
btTemplate �� CornerRadius��%�   &	       �� 5   
   " ��6   .R�5      �� $ 25��6   
�����_�$��2q�6?   ._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��Hello��6d   5      5      5      .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ KeyDown��6   .   (System.Windows.Interactivity.TriggerBase	   Actions.	 5      /  )GalaSoft.MvvmLight.Command.EventToCommand  
   PassEventArgsToCommand
 .    Command 5      �� *
EscapeDown+5       5!      .��5#      � -   5        $��mainGrid��5#       � RowDefinitions 5$   
   �� 5%       � ColumnDefinitions 5'   
   �� 5(      $��0* �6   �� 5)      $
��115* �6   �� 5*      $
��635* �6   �� 5+      $��3* �6   .+�5.   
   �� -   5         ��Name$ StartButton��5/      $
��Left=�50      $��
18,262,0,0q�51      $	��Top=�52      $��80��53      $��60��6   $��2��54      $
��Bold"�55   '     MainButtonStyle#���  56      ��55      �� *Start+.��57      ��   StartButton#���  6    J� Effect 58      3  -System.Windows.Media.Effects.DropShadowEffect  59         Color$
 Gray��5:         	Direction$	 310Q�6&      ShadowDepth$ 2Q�5;         Opacity$	 0.6Q�6)   5=      5>      �� 5?   
   -   5        $��MainContent��5A      $	��600��5B      $	��600��6   $
��Left=�5C      $	��Top=�5D      $��10.333,0,0,0q�5E      $��2��5F       J� OpacityMask
 �   ���5@      �� *	Content+5G      �� 5H   
   -   5        $��
flipButton��5J        FlipIcon#���  5I      $��2��5L      $
��Left=�5M      $��
28,343,0,0q�5N      $	��Top=�5O      $��60��5P      $��60��6     ButtonBrush#���  5Q      ���	#FF9CABAB  FieldBorderBrush#���  5S      $
��Bold"�5T      $��Center=�5U      #���  5W      y�5K      �� *
Visibility+��5V      �� *Flip+ � ToolTip$4 .Перевернуть чрные фигуры��5Z      5[      5\      5]      