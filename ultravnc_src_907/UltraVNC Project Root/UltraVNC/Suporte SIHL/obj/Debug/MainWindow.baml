   M S B A M L   `   `   `  ����  Suporte SIHL    Suporte_SIHL.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Suporte Sihl��5   	   $	��500��6   $	��600��6+    � WindowStartupLocation$ CenterScreen=�67   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��25 �6   .+�5
   
   �� -   5        $��TabControl1��5
      .@�5      �� -   5        $��tablogar��5      $��Logar��6P   y�6&   �� *Logar+ �� Mode$ TwoWay=���6_   Z� .��5      � .+�5      �� $
��Left=�6    $��5,4,0,0q�6;   $
��Wrap=�6L   $��Usuário��6`   $	��Top=�6o   �� 5      $
��Left=�6    $��5,53,0,0q�6;   $
��Wrap=�6M   $��Senha��6a   $	��Top=�6n   �� 5      -   5        $��txtlogin��5      $
��Left=�6.   $��23��6I   $��5,25,0,0q�6U    �� TextWrapping$
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��223��6�   G� 5      -   5        $��txtsenha��5   "   $
��Left=�62   $��23��6M   $��5,74,0,0q�6Y   $	��Top=�6k   $	��223��6�   �� 5      -   5        $��25��5      $��50��6)   $��Entrar��64   $��178,102,0,0q�6E   $
��Left=�6Z   $	��Top=�6u   ��6�   Z� 5      5      �� 5      -   5        $��
Tabcliente��5      $��Clientes��6S   y�6(   �� *Logado+$ TwoWay=���6e   Z� .��5      �  5      �� 5      $��20 �6(   �� 5      $��* �6(   .+�5      �� -   5        $��	Atualizar��5      ��6L   Z� &   System.Windows.Controls.DataGrid  5      -   5        $��	dgcliente��5      $��1��60      
IsReadOnly .    AutoGenerateColumns .  $��15(�5   4      HeadersVisibility$
 None=�6B      GridLinesVisibility$
 None=�6�   ��5   =   �� *
Clientes+	 �� SelectedItem	 6^   �� *	Cliente+$ TwoWay=�
   HorizontalGridLinesBrush
 5   [   Z�    VerticalGridLinesBrush 6   Z�  �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5         ContainerStyle 5   "   �� 5    &    �� 
TargetType" ��6,   .�5!   *   ��  �� Property � �� �� Value 5"   .   �� 5#   2    �� 
TargetType" ��6B   .R�5$   6   9� 
���   �$��1q�6S    9� 
IsExpanded 6g   ��  �� ElementName$ 	CheckBox1�� �� Path$ 	IsChecked���5%   :   �� 5&   >    �� EndPoint$ 0.5,1&�6R    � MappingMode$ RelativeToBoundingBox=�6c    �� 
StartPoint$ 0.5,0&�6�   .��5'   B   �  � Color$ 	#FF93ACD8��6O    � Offset$ 0.010Q�6a   � 5(   B   $ 	#FF93ACD8��6O   $ 0.010Q�6a   5)   ?   ��5,   :   �� 5-   >    �� Orientation$ 
Horizontal=�6I   .+�5.   B   �� $��15(�6g   $
��Bold"�6u   
���������6L   �� $
 Name�6�   5/   ?   .��51   :   �� 52   7   53   3   55   +   56   '   58       � 	Resources 5:      )  #System.Windows.Controls.DataGridRow �� 	Resources��%>  '        �� 5;      "  6$    5<   "   ���� 5=   &   $ 0.5,1&�6l   $ RelativeToBoundingBox=�6}   $ 0.5,0&�6�   (��       6:   * SystemColors.HighlightBrushKey+).��5>   *   � $ 	#FF8D8D8D��67   $ 0.008Q�6I   � 5?   *   $ 	#FF8D8D8D��67   $ 0.008Q�6I   5@   '   5B   #   5C      5D         Columns 5E      4  .System.Windows.Controls.DataGridTemplateColumn  5F         CellTemplate 5G   "   �� 5H   &   .R�5I   *   �� -	   5        $
��Auto��5I   1   $
��Auto��6?   ��6o   Z� ��6�   Z� ��5J   .   �� 5K   2   $��icone-conexao.jpg��68   $��20��6S   $��20��6_   6l   5M   +   5N   '   5P      0  *System.Windows.Controls.DataGridTextColumn  5R      ,  &System.Windows.Controls.DataGridColumn   Header$
 Nome��61       Width5  /System.Windows.Controls.DataGridLengthConverter$
  Auto 6]   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 6?   �� *	clie_nome+6]     5S      $ Ultimo usuário Logado��61   $
  Auto 6n   ! 6P   �� *	usua_nome+6n   5V      5X      5Y      �� 5Z      -
   5        $��Tabedcliente��5Z      $��Editar Cliente��6U   y�6*   �� *Logado+$ TwoWay=���6m   Z� .��5[      � .+�5\      �� $��25��6N   $	��300��6Z   $	��Top=�6f   $
��Left=�6~   " �� 	MaxLength$	" 200��6�   $��50,2,0,0q�6�   ��6   �� *Cliente.clie_nome+$ TwoWay=�6�   �� 5]      $	��190��6M   $	��300��6Z   $	��Top=�6f   $
��Left=�6~   $	" 200��6�   $��	50,63,0,0q�6�   # �� AcceptsReturn# . $ �� 
AcceptsTab$ . ��6   �� *Cliente.clie_obs+$ TwoWay=�6�   �� 5^      -   5        $��	ComboBox1��5^      % �� DisplayMemberPath$% 	grcl_nome��6�   & �� SelectedValuePath$& grcl_codigo��6�   $��25��6  $	��300��6  $��	50,32,0,0q�6&  $
��Left=�69  $	��Top=�6T  ��60   �� *Grupos+	 6O   �� *Cliente.grcl_codigo+$ TwoWay=�' �� SelectedValue' 6�   �� *!Cliente.grcl_codigo.grcl_codigo+$ TwoWay=�6T  �� 5_      -   5        $��25��5_      $��50��6)   $��Salvar��64   $��250,256,0,0q�6E   $
��Left=�6Z   $	��Top=�6u   6�   �� 5`      $
��Left=�6    $��11,2,0,0q�6;   $
��Wrap=�6M   $��Nome:��6a   $	��Top=�6n   �� 5a      $
��Left=�6    $��	10,32,0,0q�6;   $
��Wrap=�6N   $��Grupo:��6b   $	��Top=�6p   �� 5b      $
��Left=�6    $��
21,134,0,0q�6;   $
��Wrap=�6O   $
��OBS:��6c   $	��Top=�6o   5c      5d      �� 5e      -   5        $��Tabgrupo��5e      $��Editar Grupo��6R   y�6'   �� *Logado+$ TwoWay=���6h   Z� .��5f      � .+�5g      �� $��25��6L   $	��300��6X   $	��Top=�6d   $
��Left=�6|   $	" 200��6�   $��50,2,0,0q�6�   ��6   �� *Grupo.grcl_nome+$ TwoWay=�6�     5h      -   5        $��dggrupos��5h       .  .  $��15(�5i      $��0,32,0,0q�6"   ��5h   /   �� *Grupos+ 5j        5k       5l   "   �� 5m   &   .R�5n   *   �� -   5        $��Deletar��5n   1   $
��Auto��6C   $
��Auto��6Q   ��6t   Z� ��6�   Z� 5o   '   5q        5r      $
 Nome��61   $
  Auto 6]   ! 6?   �� *	grcl_nome+6]   5t      �� 5v      -   5        $��25��5v      $��50��6)   $��Salvar��64   $��	355,0,0,0q�6E   $
��Left=�6X   $	��Top=�6s   6�   �� 5w      $
��Left=�6    $��11,2,0,0q�6;   $
��Wrap=�6M   $��Nome:��6a   $	��Top=�6n   5y      5z      5{      �� 5|   
   $��1��6   $ 
Horizontal=�6"   .+�5}      �� -   5        $��
txtusuario��5}   )   $��5,0,0,0q�6   6)   �� 5~      -   5        $��	CheckBox1��5~      $��5,0,0,0q�6(   $��Abrir Grupos��69   ( d� 	IsChecked$( FalseY�6P   6b   5      5�      5�      