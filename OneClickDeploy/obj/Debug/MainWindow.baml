   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.3.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      I EOneClickDeploy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:OneClickDeploy.ViewModelOneClickDeploy.ViewModel 5      9!clr-namespace:OneClickDeploy.ViewOneClickDeploy.View 5         OneClickDeploy.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      <	ViewModel&clr-namespace:OneClickDeploy.ViewModel     5      2View!clr-namespace:OneClickDeploy.View     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6@     � Title$  Mi Amigo Robot��5      $��555.896��6   $��994.866��6+    � Icon$ Images/Robot.png��6;    � 	Resources 5
      0 *OneClickDeploy.ViewModel.TaskFlowViewModel   taskFlowViewModel �� DataType,  &OneClickDeploy.ViewModel.CopyViewModel"  OneClickDeploy.View.CopyView+  %OneClickDeploy.ViewModel.CmdViewModel!  OneClickDeploy.View.CmdView-  'OneClickDeploy.ViewModel.BuildViewModel#  OneClickDeploy.View.BuildView3  -OneClickDeploy.ViewModel.DownloadTfsViewModel)	  #OneClickDeploy.View.DownloadTfsView��%I  &	        (��      5      *, +)(�� E     5      *, +)(�� w     5      *, +)(�� �     5      *, +)  5      6    �� 5      "  6   .R�5        5      �� 5      "  6   .R�5        5      �� 5      "  6   .R�5        5      �� 5      "  6   .R�5      	  5      5      .��5      �  � DataContext# [  6   .+�5      �� $��2��6   $
��Left=�6#   $	��114��6>   $	��Top=�6K   $
��Auto��6c   .@�5      �� $��Archivo��6   .��5      � ���	#FFE5E5E5.+�5      !
   MahApps.Metro.Controls.Tile
  $��	4,0,908,0q�6   $
��Auto��6(   $
��Auto��66   ���	#CC119EDA 
  TitleFontSize$ 13��6z   )   #MahApps.Metro.Controls.ButtonHelper   CornerRadius$ 50��6�    
  
TiltFactor$ 1��6�   ��6C   �� *OpenProject+.��5      �� $��Images/Open Folder-WF.png��6   $��50��61   $��50��6<   $��Center=�6H   $��Center=�6c   $��UniformToFill=�6�   5      
  5       $��
59,0,853,0q�6   $
��Auto��6)   $
��Auto��67   $ 13��6d   $ 50��6w   $ 1��6�   ���	#CC119EDA��6D   �� *SaveProject+.��5!      �� $��Images/Save-02-WF.png��6   $��50��6-   $��50��68   $��Center=�6D   $��Center=�6_   $
��None=�6|    J� RenderTransformOrigin$ 
3.818,0.39&�6�   5"      5#      5$      �� 5%      $��Edición��6   .��5&      � ���	#FFE5E5E5.+�5'      
  $��
10,0,902,0q�6   $
��Auto��6)   $
��Auto��67   ���	#CC119EDA$ 13��6w   $ 50��6�   $ 1��6�   ��6D   �� *	AddCopy+.��5(      �� $��Images/Copy-WF.png��6   $��50��6*   $��50��65   $��Center=�6A   $��Center=�6\   $��UniformToFill=�6y   5)      
  5*      $��
65,0,847,0q�6   $
��Auto��6)   $
��Auto��67   ���	#CC119EDA$ 13��6v   $ 50��6�   $ 1��6�   ��6D   �� *AddCmd+.��5+      �� $��Images/Source Code-WF.png��6   $��50��61   $��50��6<   $��Center=�6H   $��Center=�6c   $��UniformToFill=�6�   5,      
  5-      $��121,0,791,0q�6   $
��Auto��6*   $
��Auto��68   ���	#CC119EDA$ 13��6y   $ 50��6�   $ 1��6�   ��6E   �� *
AddBuild+.��5.      �� $��Images/Brick-02-WF.png��6   $��50��6.   $��50��69   $��Center=�6E   $��Center=�6`   $��UniformToFill=�6}   5/      
  50      $��177,0,735,0q�6   $
��Auto��6*   $
��Auto��68   ���	#CC119EDA$ 13��6   $ 50��6�   $ 1��6�   ��6E   �� *AddDownloadTfs+.��51      �� $��Images/Import-02-WF.png��6   $��50��6/   $��50��6:   $��Center=�6F   $��Center=�6a   $��UniformToFill=�6~   52      
  53      $��487,0,425,0q�6$   $
��Auto��69   $
��Auto��6G   ���	#CC119EDA$ 13��6�   $ 50��6�   $ 1��6�   ��6T   �� *
RemoveTask+.��54      �� $��Images/Trash Can1-WF.png��6    $��50��6B   $��50��6M   $��Center=�6Y   $��Center=�6t   $��UniformToFill=�6�   55      56      57      �� 58      $��
Ejecución��6   .��59      � ���	#FFE5E5E5.+�5:      
  $��
10,0,902,0q�6   $
��Auto��6)   $
��Auto��67   ���	#CC119EDA$ 13��6{   $ 50��6�   $ 1��6�   ��6D   �� *PlayProject+.��5;      �� $��Images/Media Play1-WF.png��6   $��50��61   $��50��6<   $��Center=�6H   $��Center=�6c   $��UniformToFill=�6�   5<      5=      5>      5?      �� 5@      -   5        	 ��Name$	 lvTareas��5@      $��50��6   $��10,119,440,10q�6M   ��6.   �� *Tareas+
 �� SelectedIndex
 6d   �� *SelectedIndex+��5A      �� 5B      .R�5C      ��  �� Padding$ 10q�6    J� InputBindings 5D      d� 5E   	    d� Gesture$ 	LeftClicka�6    �� Command 6*   �� *
ShowDetail+6K   ��5G      `� 5H   	    �� StringFormat$ 	{0} - {1}��6   .1�5I   
   ��  �� Path$ Id�6   �� 5J   
   $ Description�6   5K   
   5M      5N      5P      #   MahApps.Metro.Controls.Flyout  5Q      -   5        $��FlyOutDetalle��5Q         Header$ Detalle de la tarea��6G      Position$ Right=�6d   $	��435��6u    J� Opacity$
 0.75Q�6�   
���   �
�������   CloseButtonIsCancel .    IsOpen 6)   �� *
FlyoutOpen+.��5R      � .+�5S      �� ��6   ��  �� ElementName$ lvTareas��$ SelectedItem�5T      5U      5V      5W      