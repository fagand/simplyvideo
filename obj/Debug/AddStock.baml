   M S B A M L   `   `   `  ����H  DGradedUnitWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GradedUnitWPFGradedUnitWPF  5   	       GradedUnitWPF.AddStock   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:GradedUnitWPF     5   	   -   5          � Title$  SVHC | Add Film��5   	   $	��379��6!   $��346.491��6.    � WindowStartupLocation$ CenterScreen=�6>   .��5	      � -   5         �Name$ myGrid��5	       � ColumnDefinitions 5
   
   �� 5      $	��85* �6   �� 5      $	��84* �6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��
105,10,0,0q�6B   $
��Wrap=�6V   $��Simply Video Hire Club��6j   $	��Top=�6�   $
��Bold"�6�   $��2��6�   $��16��6�   $	��131��6�   	� 5   
   -   5         	�Name$ radioButtonFilm��5      $��
Input Film��6/   $
��Left=�6D   $��
135,31,0,0q�6_   $	��Top=�6s    J� RenderTransformOrigin$ -1,-3.75&�6�   $��85��6�    d� 	IsChecked$
 TrueY�6�    	� 	GroupName$ Buttons��6�   $��2��6�   	� 5   
   -   5        $ radioButtonGame��5      $��
Input Game��6/   $
��Left=�6D   $	��Top=�6_   $��
135,52,0,0q�6w   $ Buttons��6�   $��2��6�   6�   �� 5   
   -   5        	 ��Name$	 textStockID��5      $
��Left=�6'   $��23��6B   $��	10,75,0,0q�6N   
 �� TextWrapping$

 Wrap=�6a   $��Stock ID��6u   $	��Top=�6�   $	��120��6�   {�.  6�   �� 5   
   -   5        $	 textBoxTitle��5      $
��Left=�6(   $��23��6C   $

 Wrap=�6O   $��
Film Title��6c   $	��Top=�6u   $	��120��6�   $��	38,75,0,0q�6�   $��1��6�    � ToolTip$ 
Film Title��6�   �� 5   
   -   5        $	 textBoxCertificate��5      $
��Left=�6.   $��23��6I   $��
10,103,0,0q�6U   $

 Wrap=�6i   $��Certificate��6}   $	��Top=�6�   $	��120��6�   $ Certificate��6�   �� 5   
   -	   5        $	 textBoxDistributor��5      $
��Left=�6.   $��23��6I   $

 Wrap=�6U   $��Distributor��6i   $	��Top=�6|   $	��120��6�   $��
38,103,0,0q�6�   $��1��6�   $ Distributor��6	  �� 5   
   -
   5        $	 textBoxDateOfRelease��5      $
��Left=�60   $��23��6K   $��
10,131,0,0q�6W   $

 Wrap=�6k   $��Date of Release��6   $	��Top=�6�   $	��120��6�   $ Date of Release��6   J� Opacity$ 0Q�6  {�.  6'  (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ releaseDatePicker��5      $
��Left=�60   $��
10,130,0,0q�6K   $	��Top=�6_   $	��120��6w   $ Date of Release��6�   �� 5   
   -   5        $	 textBoxCost��5      $
��Left=�6'   $��23��6B   $

 Wrap=�6N   $��Cost Bracket��6b   $	��Top=�6v   $	��120��6�   $��
38,131,0,0q�6�   $��1��6�   $ Cost Bracket��6�   �� 5   
   -   5        $	 textBoxPlatCat��5      $
��Left=�6*   $��23��6E   $��
10,159,0,0q�6Q   $

 Wrap=�6e   $��Category��6y   $	��Top=�6�   $	��120��6�   $ Category��6�   �� 5   
   -   5        $	 textBoxQuantity1��5      $
��Left=�6,   $��23��6G   $��
38,159,0,0q�6S   $

 Wrap=�6g   $��DVD Quantity��6{   $	��Top=�6�   $	��120��6�   $��1��6�   $ DVD Quantity��6  �� 5   
   -   5        $	 textBoxQuantity2��5      $
��Left=�6,   $��23��6G   $��
38,187,0,0q�6S   $

 Wrap=�6g   $��VHS Quantity��6{   $	��Top=�6�   $	��120��6�   $��1��6�   $ VHS Quantity��6  �� 5   
   -   5        $	 textBoxDescr��5      $
��Left=�6(   $��65��6C   $��
10,215,0,0q�6O   $

 Wrap=�6c   $��Description��6w   $	��Top=�6�   $	��318��6�   $��2��6�   $ Description��6  �� 5   
   -   5         ��Name$ buttonSubmit��5      $��Submit��6'   $
��Left=�68   $��
85,285,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ buttonCancel��5      $��Main Window��6'   $��1��6=   $
��Left=�6M   $��
10,285,0,0q�6h   $	��Top=�6|   $��80��6�   6�   �� 5   
   -   5        $ buttonClear��5      $��Clear Contents��6&   $
��Left=�6?   $��127,313,0,0q�6Z   $	��Top=�6o   $��87��6�   $��2��6�   {�.  6�   �� 5   
   -   5        $ 
labelTitle��5      $��Title��6(   $��1��65   $��Right=�6E   $��0,80,18.5,0q�6a   $	��Top=�6v   $��8(�6�   $ 0Q�6�   �� 5    
   -   5        $ labelDistro��5       $��Distributor��6)   $��Right=�6<   $��0,108,18.5,0q�6X   $	��Top=�6n   $��8(�6�   $��1��6�   $ 0Q�6�   �� 5!   
   -   5        $ 	labelCost��5!      $��Cost Bracket��6'   $��1��6;   $��Right=�6K   $��0,135,17.5,0q�6g   $	��Top=�6}   $��8(�6�   $
��Wrap=�6�    �� TextAlignment$ Right=�6�   $ 0Q�6�   �� 5"   
   -   5        $ labelDVD��5"      $��DVD Quantity��6&   $��Right=�6:   $��0,164,17.5,0q�6V   $	��Top=�6l   $��8(�6�   $
��Wrap=�6�   $��1��6�   $ Right=�6�   $ 0Q�6�   �� 5#   
   -   5        $ labelVHS��5#      $��VHS Quantity��6&   $��0,192,17.5,0q�6:   $	��Top=�6P   $��8(�6h   $��Right=�6u   $
��Wrap=�6�   $��1��6�   $ Right=�6�   $ 0Q�6�   �� 5$   
   -   5        $ labelCertif��5$      $��Certificate��6)   $
��Left=�6<   $��
92,108,0,0q�6W   $	��Top=�6k   $��8(�6�   $ 0Q�6�   �� 5%   
   -   5        $ 	labelDate��5%      $��Date of Release��6'   $
��Left=�6>   $��132,138,0,0q�6Y   $	��Top=�6n   $��8(�6�   $
��Wrap=�6�   $��2��6�   $��58��6�   $ 0Q�6�   �� 5&   
   -   5        $ 
labelCateg��5&      $��Category��6(   $
��Left=�68   $��
96,164,0,0q�6S   $	��Top=�6g   $��8(�6   $ 0Q�6�   �� 5'   
   -   5        $ labelDescri��5'      $��Description��6)   $
��Left=�6<   $��
14,201,0,0q�6W   $	��Top=�6k   $��8(�6�   $ 0Q�6�   5(      5)      