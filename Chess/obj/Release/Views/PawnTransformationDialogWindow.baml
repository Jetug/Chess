   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  @ <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Chess.ViewModelsChess.ViewModels 0   *Chess.Views.PawnTransformationDialogWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     -vmclr-namespace:Chess.ViewModels       � Title$#  Выберите фигуру��$	��300��$	��300�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � ShowInTaskbar .   � DataContext , &Chess.ViewModels.DialogWindowViewModel  .��� -   $��mainGrid��   WhiteCellBrush#���   .+���   FieldBorderBrush#���  $��5q�� -   $��
figureGrid��$
��Left=�$��	50,50,0,0q�$	��Top=�$	��200��$	��200��.+��� -   $��
queenLabel��$	��♛��$��45(�$��70��$��70��$��Center=�$��Center=�$	��Top=�$
��Left=���Z� .   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ 	MouseDown��.   (System.Windows.Interactivity.TriggerBase   Actions. 6   0System.Windows.Interactivity.InvokeCommandAction  	   Command	 �� *CloseWindow+
   CommandParameter
 ��  �� ElementName$ 
queenLabel�� �� Path$ Content��� -   $��	rookLabel��$	��♜��$��	130,0,0,0q�$��45(�$��70��$��70��$��Center=�$��Center=�$	��Top=�$
��Left=���Z�    $ 	MouseDown��.   	 �� *CloseWindow+
 �� $ 	rookLabel��$ Content��� -   $��knightLabel��$	��♞��$��	0,130,0,0q�$��45(�$��70��$��70��$��Center=�$��Center=�$	��Top=�$
��Left=�$��Yu Mincho Demibold)���Z�    $ 	MouseDown��.   	 �� *CloseWindow+
 �� $ knightLabel��$ Content��� -   $��bishopLabel��$	��♝��$��130,130,0,0q�$��45(�$��70��$��70��$��Center=�$��Center=�$	��Top=�$
��Left=���Z�    $ 	MouseDown��.   	 �� *CloseWindow+
 �� $ bishopLabel��$ Content��� $#��Выберите фигуру��$
��Left=�$��	50,10,0,0q�$	��Top=�$	��200��$��16(�$��Center=�$
��Bold"�