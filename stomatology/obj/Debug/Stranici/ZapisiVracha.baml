   M S B A M L   `   `   `  ����F  Bstomatology, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:stomatology.Stranicistomatology.Stranici  5      '    !stomatology.Stranici.ZapisiVracha   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:stomatology.Stranici     5        N� Title$"  Записи на прием��5	      .��5      � .+�5   
   �� -   5        $��Pechat��5   "   $��Печать��6    
  Button#��[  6E   $��Right=�6e   $��Bottom=�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
ZapisiGrid��5   ?   $��0 0 0 35q�6   $��0 1 0 0q�6%      AutoGenerateColumns .     CanUserReorderColumns .     
IsReadOnly .    CanUserResizeColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6%   	   Header$	 Услуга��62   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6B   ��  �� Path$ Uslugi.Nazvanie_Uslugi�6u     5      $	 100 6%   $	 Дата приема��61   
 6F   �� *Date_priema+ �� StringFormat$ 
dd/MM/yyyy��6�     5      $ 70 6%   $	 Пациент��60   
 6A   �� *User.Familia+6d     5      $ 70 6%   $	  ��60   
 6:   �� *	User.Name+6Z     5      $ 70 6%   $	  ��60   
 6:   �� *User.Otchestvo+6_   ��5      �� 5      6   5      5      5      