@CustomEditor (WallSelector)
#if (UNITY_EDITOR)
public class WallSelectorEditor extends Editor
{
	function OnInspectorGUI()
    {
		if(Application.isPlaying)
			return;
		
		
        var myScript : WallSelector = target;	
		GUILayout.Label(myScript.scriptName);
		myScript.editObj = GUILayout.Toggle(myScript.editObj, "Show List");
        //if(myScript.editObj) DrawDefaultInspector();
		DrawDefaultInspector();
		if(myScript.selectedStyle >= 0 && myScript.selectedStyle < myScript.selector.length){
			//GUILayout.Box("Selected Prefab: " + myScript.selector[myScript.selectedStyle].selectionName);
			if(myScript.editObj)
				for(var i = 0; i < myScript.selector.length; i++){
					if(i == myScript.selectedStyle) GUI.color = Color(0,1,0);
					else GUI.color = Color(1,1,1);
					GUILayout.Box(i + " " + myScript.selector[i].selectionName);
					//if(GUILayout.Button(i + " " + myScript.selector[i].selectionName)){
					//	myScript.selectedStyle = i;
					//}
				}
			
			if(myScript.selectorNames && myScript.selector) if(myScript.selector.length > 0){
				if(myScript.selectorNames.length != myScript.selector.length)
					myScript.SelectorNameUpdate();
				//myScript.selectedStyle = EditorGUILayout.Popup("Select wall prefab:", myScript.selectedStyle, myScript.selectorNames);
				
				myScript.UpdateStyle();
			}
		}else if(myScript.selectedStyle < 0)
			myScript.selectedStyle = 0;
		else if(myScript.selectedStyle >= myScript.selector.length)
			myScript.selectedStyle = myScript.selector.length -1;
	}
}
#endif