var editObj : boolean = true;
var scriptName : String;
var assets : GameObject[];
var selector : assetSelector[];
@HideInInspector
var selectorNames : String[];
var selectedStyle : int = 0;
var gizmoOffset : Vector3 = Vector3.zero;
var gizmoDimension : Vector3 = new Vector3(1,1,1);
var gizmoColor : Color = Color(0,0,1,0.3);

function OnDrawGizmos () {
	Gizmos.matrix = transform.localToWorldMatrix;
	Gizmos.color = gizmoColor;
	Gizmos.DrawCube(gizmoOffset, gizmoDimension);
	Gizmos.color.a = 0.5;
	Gizmos.DrawWireCube(gizmoOffset, gizmoDimension);
}

function UpdateStyle () {	
	if(selector.length == 0 || assets.length == 0 || !editObj)
		return;
	
	var checked : boolean[] = new boolean[assets.length];
	for(var c = 0; c < checked.length; c++) checked[c] = false;
	
	for(var i = 0; i < assets.length; i++){
		assets[i].SetActive(false);
		
		for(var s = 0; s < selector[selectedStyle].includeAssets.length; s++){
			if(i == selector[selectedStyle].includeAssets[s])
				assets[i].SetActive(true);
		}
	}
}

function SelectorNameUpdate () {
	selectorNames = new String[selector.length];
	
	for(var n = 0; n < selector.length; n++)
		selectorNames[n] = selector[n].selectionName;
}

private class assetSelector {
	var includeAssets : int[];
	var selectionName : String = "";
}