   M S B A M L   `   `   `  ����N  JPracticeApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PracticeApplication.AddPracticeApplication.Add  5      %    PracticeApplication.Add.AddRoom   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PracticeApplication.Add     5        N� Title$  AddRoom��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��3* �6#   .+�5      �� $��4��5      $��0��5      $!��Номер кабинета��5       $��16(�6'   $��77,144,0,-74q�65   �� 5!      -   5         ��Name$ 	numberBox��5!      $��4��5"      $��1��5#      $��16(�5$   Q   $	��500��6_   $��88,150,128,-68q�6k   $��28��6�   ��6   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5%      -   5         ��Name$ departmentSelect��5%       �� Text$' !Список должностей��62   $��1��6K   $
��Left=�6[   $��	88,84,0,0q�6v   $��4��6�   $	��Top=�6�   $	��500��6�   $��16(�6�    � Cursor$
 Hand��6�   �� 5&      $��4��5'      $��0��5(      $��
Отдел��5)      $��77,84,0,-21q�6   $��16(�63   5+      �� 5-   
   -   5         ��Name$ goBack��5-      $
��Left=�6"   $��	75,10,0,0q�6=   $	��Top=�6P   $��58��6h   $��50��6s   $��16(�6   $
 Hand��6�   ��6�   Z� ��6�   Z� ��6�   Z� .��5.      �� 	 �� Orientation$	 
Horizontal=�6   .+�5/      �� $��../Resources/back.png��6   $
��Fill=�67   $��43��6F   $��54��6R   50      51      �� 52   
   -   5        $��
errorLabel��52   �   $�� ��6   $
��Left=�6   $��
75,542,0,0q�66   $	��Top=�6J   $	��349��6b   
���  ��$��16(�6�   ��6n   Z� 6�   �� 54   
   -   5        $
 Hand��54      $��Добавить��6   $
��Left=�62   $��1076,545,0,0q�6M   $	��Top=�6c   $��89��6{   $��18(�6�   6�   55      56      