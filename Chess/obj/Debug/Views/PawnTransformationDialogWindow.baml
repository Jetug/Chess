   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   @ <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Chess.ViewModelsChess.ViewModels 5   	   0   *Chess.Views.PawnTransformationDialogWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   -vmclr-namespace:Chess.ViewModels     5   	     � Title$#  Выберите фигуру��5	   	   $	��300��5
   	   $	��300��6    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � ShowInTaskbar .   � DataContext 5      , &Chess.ViewModels.DialogWindowViewModel  5   
   .��5      � -   5        $��mainGrid��5         WhiteCellBrush#���   6   .+�5   
   ��   FieldBorderBrush#���  6   $��5q�6B   � 5   
   -   5        $��
figureGrid��5      $
��Left=�5      $��	50,50,0,0q�5      $	��Top=�5      $	��200��5      $	��200��6   .+�5      �� -   5        $��
queenLabel��5      $	��♛��5      $��45(�5      $��70��5      $��70��6!   $��Center=�5       $��Center=�5!      $	��Top=�5"      $
��Left=�5#      ��5      Z� .   (System.Windows.Interactivity.Interaction   Triggers 5$      /   )System.Windows.Interactivity.EventTrigger  5%         	EventName$ 	MouseDown��6%   .   (System.Windows.Interactivity.TriggerBase   Actions. 5&      6   0System.Windows.Interactivity.InvokeCommandAction  	   Command	 5'   !   �� *CloseWindow+
   CommandParameter
 5(   !   ��  �� ElementName$ 
queenLabel�� �� Path$ Content�5)      5,      �� 5-      -   5        $��	rookLabel��5-      $	��♜��5.      $��	130,0,0,0q�5/      $��45(�50      $��70��51      $��70��6!   $��Center=�53      $��Center=�54      $	��Top=�55      $
��Left=�56      ��52      Z�  57        58      $ 	MouseDown��6%   . 59        	 5:      �� *CloseWindow+
 5;      �� $ 	rookLabel��$ Content�5<      5>      �� 5?      -   5        $��knightLabel��5?      $	��♞��5@      $��	0,130,0,0q�5A      $��45(�5B      $��70��5C      $��70��6!   $��Center=�5E      $��Center=�5F      $	��Top=�5G      $
��Left=�5H      $��Yu Mincho Demibold)�60   ��5D      Z�  5I        5J      $ 	MouseDown��6%   . 5K        	 5L      �� *CloseWindow+
 5M      �� $ knightLabel��$ Content�5N      5P      �� 5Q      -   5        $��bishopLabel��5Q      $	��♝��5R      $��130,130,0,0q�5S      $��45(�5T      $��70��5U      $��70��6!   $��Center=�5W      $��Center=�5X      $	��Top=�5Y      $
��Left=�5Z      ��5V      Z�  5[        5\      $ 	MouseDown��6%   . 5]        	 5^      �� *CloseWindow+
 5_      �� $ bishopLabel��$ Content�5`      5b      5c      �� 5d   
   $#��Выберите фигуру��6   $
��Left=�5e      $��	50,10,0,0q�5f      $	��Top=�5g      $	��200��5h      $��16(�6   $��Center=�5i      $
��Bold"�64   5j      5k      