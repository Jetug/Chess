   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   @ <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Chess.ViewModelsChess.ViewModels 5   	      Chess.Views.MateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   b ^GalaSoft.MvvmLight.Platform, Version=5.4.1.0, Culture=neutral, PublicKeyToken=5f873c45e98af8a1(j http://www.galasoft.ch/mvvmlight  5   	   'vmclr-namespace:Chess.ViewModels  5   	     � Title$  
MateWindow��5
   	   $	��220��5   	   $	��360��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � ShowInTaskbar .   � DataContext 5      * $Chess.ViewModels.MateWindowViewModel  5   
    � 	Resources 5       �� 
TargetType �� Property	 �� Value
 �� 
TargetType �� Triggers P� Property P� Value��%�  '��       �� 5   
   	MateStyle��" ��6#   .�5      ��  � ��	 �	#FF007ACC6?   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� #��z��6!   
���   �$��1q�6_   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5!      P� 5"       �@J�IsMouseOver . . �5#      ��  � ��
	 �  ��6B   5$      P� 5&       � �� . . �5'      ��  � ��
	 � ���6E   5(      5,      5-      .   (System.Windows.Interactivity.Interaction   Triggers 50      /   )System.Windows.Interactivity.EventTrigger  51   
      	EventName$ KeyDown��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 52      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 53      �� *CloseWindowWithEscape+54      55      .��57      � -   5        $��mainGrid��57         WhiteCellBrush#���   6   .+�58   
   ��   FieldBorderBrush#���  6   $��5q�59      �� 5:   
     Mate#���  6   $��Center=�5;      $��
81,35,83,0q�5<      $	��Top=�5=      $	��200��5>      $��22(�6   $��Center=�5?      $
��Bold"�5@        BlackCellBrush#���  6"   �� 5A   
   $��Center=�5B      $��Center=�5C      $��Center=�5D      $��Center=�5E      $��40��5F      $	��202��6   $��81,78,81,102q�5G      $
��Bold"�5H      #���  6"   $��18(�6P   ��5A      �� *Win+5H   P   �� 5I   
   $
��Left=�5J      $��
80,130,0,0q�5K      $	��Top=�5L      $��80��5M      $��50��6   $
��Bold"�5O      #���  5P        StartButton#���  5Q        MateButtonStyle#���  5R      ��5N      �� *StartNewGame+5R      �� 5S   
   $
��Left=�5T      $��200,130,0,0q�5U      $	��Top=�5V      $��80��5W      $��50��6   $
��Bold"�5Y      #��� ��5Z      #���  5[        CloseButton#���  5\      #���  5]      #���  5^      ��5X      �� *CloseWindow+5^      5_      5a      