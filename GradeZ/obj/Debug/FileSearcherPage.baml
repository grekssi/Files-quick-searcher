   M S B A M L   `   `   `  ����A  =GradeZ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GradeZGradeZ  5          GradeZ.FileSearcherPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:GradeZ     5        N� Title$  FileSearcherPage��5	       N� 
Background
 �   �.��5      �� .+�5   
   � $��
0,-1,0.4,1q�6    � RowDefinitions 5      �� 5      $
��258* �6    �� 5      $
��169* �6     � ColumnDefinitions 5      �� 5      $��0* �6#   �� 5      $
��405* �6#   �� 5      $
��401* �6#   �� 5      $��0* �6#   .+�5      �� -   5        $��SpecificWordCheck��5      $��Center=�61   $��20(�6S   
�������
�������$��Specific word��6�   $��1��6�   $��
264,11,0,0q�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.056,0.293&�6�   $
��Left=�6  $	��144��65  $��26��6A  $��2��6M  �� 5      -   5        $��ExtensionCheck��5      $��Center=�6-   $��20(�6O   
�������
�������$��Extension (e.g .dll)��6�   $
��Left=�6�   $	��Top=�6�   $	��186��6�   $��1��6�   $��
264,50,0,0q�6�   $��27��6"  $ 0.542,0.104&�6.  $��2��6R  �� 5      -   5        $��SearchedFor��5      $��40(�6+   
�������
���   �$
��Bold"�6_   $��2��6q   $
��Left=�6�   $
��Wrap=�6�   $��Search for:��6�   $	��Top=�6�   $��22,2,0,0q�6�   $��60��6�   $	��240��6�   �� 5      -   5        $��SpecifiedWord��5   *   $y�Hidden=�6   $��40(�6?   $
��Bold"�6M   $��Center=�6`   $
��Left=�6�   $��67��6�    �� TextWrapping$
 Wrap=�6�   $��	Type Here��6�   $	��Top=�6�   $	��332��6�   $��55,9,0,0q�6�   $��2��6(  �� 5      -   5        $��FolderSearch��5      $��Center=�6+   $��20(�6M   
�������
�������$��Folder TBD
��6�   $
��Left=�6�   $	��Top=�6�   $	��186��6�   $��1��6�   $��
264,88,0,0q�6�   $��27��6$  $ 0.542,0.104&�60  $��2��6T  �� 5      -   5        $��Search��5   )   $y�Hidden=�6   $��25(�67   $
��Bold"�6E   $��Search��6W   $
��Left=�6h   $	��Top=�6�   $	��304��6�   $��
66,142,0,0q�6�   $��44��6�   $��2��6�   �� 5      -   5        $��foundAt��5      $y�Hidden=�6%   
�������$��2q�6M   $ 0.484,0.452&�6a   $��3��6�   $��
29,7,25,15q�6�   $��1��6�   ._�5      �� -   5        $��FoundAt��5      
�������
���   �$��20(�6O   $
 Wrap=�6]   $�� ��6q   $��	8,33,9,34q�6y   6�   5      �� 5       -	   5        $��FolderSearcher��5    *   $y�Hidden=�6   $��24(�6@   $
��Bold"�6N   $��Select starting folder��6`   $
��Left=�6�   $	��Top=�6�   $	��264��6�   $��2��6�   $��	84,84,0,0q�6�   $��50��6�   6�   �� 5!      -
   5        $��SelectedFolder��5!   *   $y�Hidden=�6    �� 
IsReadOnly . $��Center=�6R   
���   �
�������$��20(�6�   $��3��6�   $
��Left=�6�   $ NoWrap=�6�   $	��Top=�6�   $��
14,144,0,0q�6  $��42��6  $	��442��6%  �� 5"      -   5        $��Status��5"   b   $y�Hidden=�6   
���   �$
��Bold"�6>    . $��30(�6p   
�������
���   � �� TextAlignment$ Center=�6�   $��3��6�   $
��Left=�6�   $
 Wrap=�6�   $��Status:��6�   $	��Top=�6  $��
48,200,0,0q�6%  $��48��69  $	��713��6E  �� 5#      -   5        $��FoundAtText��5#      $y�Hidden=�6,   
�������$��20(�6S   $��2��6a   $
��Left=�6u   $
��Wrap=�6�   $��	Found at:��6�   $	��Top=�6�   $��	41,12,0,0q�6�   $��26��6�   $	��134��6�   $��1��6�   �� 5$      -   5        $��
OpenFolder��5$      $y�Hidden=�6'   $��Open folder��6;   
�������$��20(�6d   $��Center=�6r   $��Center=�6�   $
��Left=�6�   $��Center=�6�   $	��121��6�   $��2��6�   $��243.4,119.6,0,19q�6
  $��1��6$  $��31��61  6=  �� 5%      -   5        $��EditFile��5%      $y�Hidden=�6%   $��	Edit File��69   
�������$��20(�6`   $��Center=�6n   $��Center=�6�   $
��Left=�6�   $��Center=�6�   $	��121��6�   $��2��6�   $��116.4,119.6,0,19q�6  $��1��6   $��31��6-  69   � 5&      -   5        $��	MainFrame��5&        � NavigationUIVisibility$ Visible=�6%   $��4��6F   $��0,-21,-1,-12q�6Z   $��2��6p   5'      5(      5)      5*      