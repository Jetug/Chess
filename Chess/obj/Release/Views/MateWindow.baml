   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  @ <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Chess.ViewModelsChess.ViewModels    Chess.Views.MateWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1(j http://www.galasoft.ch/mvvmlight  'vmclr-namespace:Chess.ViewModels    � Title$  
MateWindow��$	��220��$	��360�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � ShowInTaskbar .   � DataContext * $Chess.ViewModels.MateWindowViewModel   � 	Resources  �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� Triggers P� Property P� Value��%  '��       �� 	MateStyle��" ��.���  � ��	 �	#FF007ACC��  � ��	 �� "
 ��.R��� #��z��
���   �$��1q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
	 �  ��P�  � �� . . ���  � ��
	 � ���.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ KeyDown��.   (System.Windows.Interactivity.TriggerBase   Actions. /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command �� *CloseWindowWithEscape+.��� -   $��mainGrid��   WhiteCellBrush#���   .+���   FieldBorderBrush#���  $��5q���   Mate#���  $��Center=�$��
81,35,83,0q�$	��Top=�$	��200��$��22(�$��Center=�$
��Bold"�  BlackCellBrush#���  �� $��Center=�$��Center=�$��Center=�$��Center=�$��40��$	��202��$��81,78,81,102q�$
��Bold"�#���  $��18(����� *Win+�� $
��Left=�$��
80,130,0,0q�$	��Top=�$��80��$��50��$
��Bold"�#���    StartButton#���    MateButtonStyle#���  ���� *StartNewGame+�� $
��Left=�$��200,130,0,0q�$	��Top=�$��80��$��50��$
��Bold"�#��� ��#���    CloseButton#���  #���  #���  ���� *CloseWindow+