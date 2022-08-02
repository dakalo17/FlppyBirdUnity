using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

	public Button thisBtn;
	
	
	void Start()
	{
		//Scene thisScene = SceneManager.GetSceneByName("PauseScreen");
		
		// if(thisScene.isLoaded)
		// {
			// if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Escape))
			// {
				// // print("nUMBER OF SCENES : " + SceneManager.sceneCount);
				// // if(SceneManager.sceneCount > 2)
				// // {
					
					// // for(int i=1;i<SceneManager.sceneCount; i++)
					// // {
						// // print("Unload Scene" + i);
						// // SceneManager.UnloadSceneAsync("PauseScreen");
						// // Resources.UnloadUnusedAssets();
					// // }
					
				// // }
				// // Unpause();
			// }
			// else
			
			thisBtn.onClick.AddListener(Unpause);

		//}
	}
	
	void Unpause()
	{
		
		SceneManager.UnloadSceneAsync("PauseScreen");
		Resources.UnloadUnusedAssets();
		GameObject.FindWithTag("Point").GetComponent<Text>().text = System.Convert.ToString(Nne.Point);

		if(Time.timeScale <= 0 || Time.timeScale != 1)
			Time.timeScale=1;
	}
    
	
	
	
}
