   M S B A M L   `   `   `  ����E  ACoronaProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CoronaProj
CoronaProj  5   	       CoronaProj.list   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:CoronaProj     5   	     � Title$+  %공적마스크 조회 서비스 List��5   	   $	��720��6#   $
��1283��60   .��5	      � .+�5
   
   �� -   5        $��SearchButton��5
      $��25(�6%   $��주소 검색��63   $
��Left=�6C   $	��Top=�6^   $	��123��6v   $��	39,10,0,0q�6�   $��82��6�   6�   �� 5   
   -   5        $��
SearchText��5      $��20(�6$   $
��Left=�62   $��82��6M    �� TextWrapping$
 Wrap=�6Y   $����주의! 예-) '서울특별시 강남구' or '서울특별시 강남구 논현동' 와 같은 주소 체계로 검색이 되어야 합니다.                   ('서울특별시' 와 같이 '시'단위만 입력하는 것은 불가능합니다.)��6m   $	��Top=�5   9   $
��1072��6Q   $��
190,10,0,0q�6^   �� 5   
   -   5         ��Name$ 
ListView01��5      $
��Left=�6'   $
��1265��6B   $	��553��6O   $	��Top=�6\   $��0,97,0,0q�6t    �� View 5      �� 5      .P�5      �� $��판매처 코드번호��6%    �� Width$	 100��67    �� DisplayMemberBinding 6C   �� *code+�� 5      $��판매처 이름��6%   $	 160��65    6A   �� *name+�� 5      $��판매처 주소��6%   $	 300��65    6A   �� *addr+�� 5      $��재고 보유 현황��6%   $	 100��67    6C   �� *remain_stat+�� 5      $��입고 시간��6%   $	 200��64    6@   �� *
stock_at+�� 5      $��판매처 타입��6%   $	 100��65    6A   �� *type+�� 5      $��판매처 위도��6%   $	 100��65    6A   �� *lat+�� 5      $��판매처 경도��6%   $	 100��65    6A   �� *lng+5      5      �� 5    
   -   5        $��SaveListView��5       $��Save(Excel)��6%   $
��Left=�6;   $��20(�6V   $��1139,46,0,0q�6d   $	��Top=�6y   $	��123��6�   $��46��6�   6�   5"      5#      