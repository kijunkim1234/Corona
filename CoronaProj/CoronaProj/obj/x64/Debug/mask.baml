   M S B A M L   `   `   `  ����E  ACoronaProj, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:CoronaProj
CoronaProj  5   	       CoronaProj.mask   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:CoronaProj     5   	     � Title$&   공적마스크 조회 서비스��5   	   $	��720��6   $
��1280��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��640 �6   �� 5      $	��640 �6   .+�5   
   �� -   5         ��Name$ 	titleText��5      $��	85,76,0,0q�6'   $
��Wrap=�6:    �� TextAlignment$ Center=�6N   $��40(�6e   $	��Top=�6s   $��2��6�   $	��160��6�   $
��1110��6�   $
��Left=�6�   �� 6�   $*�$< 공적마스크 조회 서비스 >��6�   �� 6�   �� 6  $��20(�6	  $H�B마스크 재고 현황은 실시간 업데이트가 아닙니다.��6  6<  �� 5   
   -   5        $��
resultText��5      $
��Left=�6&   $ Center=�6A   $��
85,241,0,0q�6X   $��35(�6l   $
��Wrap=�6z   $�� ��6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.069,-0.812&�6�   $��2��6�   $	��275��6�   $
��1110��6�   �� 5   
   $��1��6   $
��Left=�6$   $��	0,613,0,0q�6?   $
��Wrap=�6R   $��20(�6f   $ Right=�6t   $	��Top=�6�   $��56��6�   $	��612��6�   �� 6�   $F�@데이터 출처 : 한국정보화진흥원 (maskdata@nia.or.kr)��6�   �� 6�   �� 6�   $	�   ��6�   �� 6  $3�-공공데이터포털 (http://www.dwata.go.kr��6  6:  �� 5   
   -   5        $��
listButton��5      $��리스트로 보기��6#   $��25(�65   $
��Left=�6C   $	��Top=�6^   $	��188��6v   $��370,482,0,0q�6�   $��97��6�   6�   �� 5   
   -   5        $��	MapButton��5      $��지도보기��6"   $
��Left=�61   $��25(�6L   $��	0,482,0,0q�6Z   $	��Top=�6m   $	��186��6�   $��97��6�   $��1��6�   �� 5   
   -   5        $��
ExitButton��5      $��종료��6#   $
��Left=�60   $��25(�6K   $	��Top=�6Y   $	��186��6q   $��
85,482,0,0q�6}   $��97��6�   6�   5      5      