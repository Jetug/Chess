   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  @ <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Chess.ViewModelsChess.ViewModels    Chess.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -vmclr-namespace:Chess.ViewModels     b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1(j http://www.galasoft.ch/mvvmlight    � WindowStartupLocation$  CenterScreen=�   MainWindowTitle � Title# �   $	��650��$	��750��$	��750��$	��650��  MainWindowBrush#���   � 
ResizeMode$ NoResize=� � DataContext $ Chess.ViewModels.MainViewModel   � 	Resources  �� 
TargetType  
btTemplate �� CornerRadius��%n   &	       �� " ��.R��� $ 25��
�����_�$��2q�._��� $��5q�$��Center=�$��Center=�$��Hello��.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ KeyDown��.   (System.Windows.Interactivity.TriggerBase	   Actions.	 /  )GalaSoft.MvvmLight.Command.EventToCommand  
   PassEventArgsToCommand
 .    Command �� *
EscapeDown+.��� -   $��mainGrid�� � RowDefinitions ��  � ColumnDefinitions �� $��0* ��� $
��115* ��� $
��635* ��� $��3* �.+��� -    ��Name$ StartButton��$
��Left=�$��
18,262,0,0q�$	��Top=�$��80��$��60��$��2��$
��Bold"�  MainButtonStyle#���  ���� *Start+.����   StartButton#���   J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$
 Gray��   	Direction$	 310Q�   ShadowDepth$ 2Q�   Opacity$	 0.6Q��� -   $��MainContent��$	��600��$	��600��$
��Left=�$	��Top=�$��10.333,0,0,0q�$��2�� J� OpacityMask
 �   ����� *	Content+�� -   $��
flipButton��  FlipIcon#���  $��2��$
��Left=�$��
28,343,0,0q�$	��Top=�$��60��$��60��  ButtonBrush#���  ���	#FF9CABAB  FieldBorderBrush#���  $
��Bold"�$��Center=�#���  y��� *
Visibility+���� *Flip+ � ToolTip$4 .Перевернуть чрные фигуры��