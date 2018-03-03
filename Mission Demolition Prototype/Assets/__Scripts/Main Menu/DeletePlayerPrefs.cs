using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
	//found herehttps://docs.unity3d.com/ScriptReference/PlayerPrefs.DeleteAll.html
	//attach this to the main menu if you need to delete playerprefs
	void OnGUI()
	{
		//Delete all of the PlayerPrefs settings by pressing this Button
		if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
		{
			PlayerPrefs.DeleteAll();
		}
	}
}