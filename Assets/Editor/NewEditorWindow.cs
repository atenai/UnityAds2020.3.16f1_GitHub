using UnityEngine; 
using UnityEditor;

public class NewEditorWindow : EditorWindow 
{ 

	[MenuItem("Kashiwabara/NewEditorWindow")] 
	static void Open() 
	{ 
		GetWindow <NewEditorWindow> (); 
	} 

	void OnGUI () 
	{
 
	} 

}