   M S B A M L   `   `   `  ����N  JPracticeApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PracticeApplication.AddPracticeApplication.Add  5      )    #PracticeApplication.Add.AddPosition   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PracticeApplication.Add     5        N� Title$  AddPosition��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��3* �6#   .+�5      �� $��4��5      $��0��5      $��
Оклад��5      $��16(�6   $��77,144,0,-74q�6,   �� 5      -   5         ��Name$ nameBox��5      $��1��5       $��1��5!      $��16(�5"   Q   $	��500��6_   $��88,76,128,10q�6k   $��28��6�   ��6   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5#      -   5        $ 	salaryBox��5#      $��1��5$      $��1��5%      $��16(�5&   Q   $	��500��6_   $��88,144,128,-59q�6k   $��28��6�   ��6   �� *	FirstName+$ PropertyChanged=�6�   �� 5'      $��4��5(      $��0��5)      $)��#Название должности��5*      $��77,84,0,-21q�6+   $��16(�6@   5,      �� 5.   
   -   5         ��Name$ goBack��5.      $
��Left=�6"   $��	75,10,0,0q�6=   $	��Top=�6P   $��58��6h   $��50��6s   $��16(�6    � Cursor$
 Hand��6�   ��6�   Z� ��6�   Z� ��6�   Z� .��5/      ��  �� Orientation$ 
Horizontal=�6   .+�50      �� $��../Resources/back.png��6   $
��Fill=�67   $��43��6F   $��54��6R   51      52      �� 53   
   -   5        $��
errorLabel��53   �   $�� ��6   $
��Left=�6   $��
75,542,0,0q�66   $	��Top=�6J   $	��349��6b   
���  ��$��16(�6�   ��6n   Z� 6�   �� 55   
   -   5        $
 Hand��55      $��Добавить��6   $
��Left=�62   $��1076,545,0,0q�6M   $	��Top=�6c   $��89��6{   $��18(�6�   6�   56      57      