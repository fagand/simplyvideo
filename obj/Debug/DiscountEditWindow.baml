   M S B A M L   `   `   `  ����H  DGradedUnitWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GradedUnitWPFGradedUnitWPF  5   	   &     GradedUnitWPF.DiscountEditWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:GradedUnitWPF     5   	   -   5          � Title$!  SVHC | Discount Edit Window��5   	   $��410.216��6-   $��576.859��6>    � WindowStartupLocation$ CenterScreen=�6N   
�������.��5	      � -   5         �Name$ myGrid��5	      .+�5
   
   �� $
��Left=�6   $
��Wrap=�6/   $��
Stock Item��6C   $	��Top=�6U   $��	21,72,0,0q�6m   �� 5   
   -   5         ��Name$ 	comboEdit��5      $
��Left=�6&   $	��Top=�6A   $	��408��6Y   $��	82,67,0,0q�6e   $��22��6�   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��Original Cost��6C   $	��Top=�6X   $��181,225,0,0q�6p   �� 5   
   -   5         ��Name$ txtCostEdit��5      $
��Left=�6'   $��23��6B   $��255,218,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $��70��6�    �� 
IsReadOnly . 6�   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��Discount��6C   $	��Top=�6S   $��203,253,0,0q�6k   �� 5   
   -   5        $ txtDiscount��5      $
��Left=�6'   $��23��6B   $
 Wrap=�6N   $	��Top=�6b   $��70��6z   $��255,246,0,0q�6�   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��Discounted Cost��6C   $	��Top=�6Z   $��163,281,0,0q�6r   �� 5   
   -   5        $ txtDiscountApplied��5      $
��Left=�6.   $��23��6I   $��255,274,0,0q�6U   $
 Wrap=�6j   $	��Top=�6~   $��70��6�   �� 5   
   -   5         ��Name$ btnApplyDiscount��5      $��Apply Discount��6+   $
��Left=�6D   $	��Top=�6_   $��330,259,0,0q�6w   6�   �� 5   
   -   5        $ btnSaveDiscountedPrice��5      $��Save New Cost��61   $
��Left=�6I   $	��Top=�6d   $��248,307,0,0q�6|   6�   �� 5   
   -	   5        $ 	btnReturn��5      $��Main Window��6$   $
��Left=�6:   $	��Top=�6U   $��453,307,0,0q�6m   6�   �� 5   
   $��Center=�6   $��129,10,129,0q�61   $
��Wrap=�6G   $	��Top=�6[   $��52��6s   �� 6�   $;�51. Select a stock item from the drop down menu above.��6�   �� 6�   �� 6�   $@�:2. Enter the discount % you want to apply then press apply��6�   �� 6  �� 6#  $A�;3. Finally press save new cost to save the discounted cost.��6'  �� 6l  �� 6x  6  5      5      