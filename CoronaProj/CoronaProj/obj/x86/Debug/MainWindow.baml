   M S B A M L   `   `   `  ����E  ACoronaProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CoronaProj
CoronaProj  5   	   V RCefSharp.Wpf, Version=81.3.100.0, Culture=neutral, PublicKeyToken=40c4b6fc221f4138A0clr-namespace:CefSharp.Wpf;assembly=CefSharp.WpfCefSharp.Wpf 5   	       CoronaProj.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:CoronaProj     5   	   Hcefsharpwpf0clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf     5   	     � Title$  
MainWindow��5	   	   $	��720��6   $
��1280��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $
��140* �6   �� 5      $	��500 �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��41* �6   �� 5      $��1170* �6   �� 5      $	��56* �6   .+�5   
   �� $��286,10,263,56q�6   $
��Wrap=�6+   $%��공적마스크 조회서비스��6?   $	��626��6R   $��50(�6^   $��Center=�6l   $��1��6�   �� 5   
   -   5         ��Name$ AddressText��5      $
��Left=�6'   $��41��6B    �� TextWrapping$
 Wrap=�6N   $��검색할 주소 입력��6b   $	��Top=�6s   $	��435��6�   $��1��6�   $��	10,88,0,0q�6�   $��15(�6�    �� 	UndoLimit$	 200��6�   �� 5   
   -   5        $��조회��5      $
��Left=�6   $	��Top=�69   $��75��6Q   $��1��6\   $��
461,88,0,0q�6l   $��41��6�   $��15(�6�   6�   (  "System.Windows.Controls.WebBrowser  5   
   -   5          Name$ 
MapBrowser��5         Source$$ http://localhost:5000/inv.html?�6)   $
��Left=�6Q   $	��366��6l   $	��Top=�6y   $	��796��6�    � Cursor$
 None��6�   $��	64,45,0,0q�6�   $��1��6�   $��1��6�   ]� 5   
   .+�5      ]� ��. $	��Top=�6-   .+�5      �� -   5        $��BackBtn��5   ,   $��<Back��6   6S   �� 5      -   5        $��NavigateBtn��5   ,   $��Navigate��6   6[   �� 5      -   5        $��
ForwardBtn��5   /   $��Forward>��6   6\   �� 5      -   5        $��
AddressBox��5      6.   5       %  CefSharp.Wpf.ChromiumWebBrowser  5!      -   5        $��Browser��5!   q   	   Address$	 
github.com��6-   6�   5"      5%      5&      