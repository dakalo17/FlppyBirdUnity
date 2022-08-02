using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
	public Button btnQuit;
	public Button btnStart; 
	
    void Start()
    {
        btnQuit.onClick.AddListener(Vaya);
		btnStart.onClick.AddListener(Benninging);
    }

    void Vaya()
	{
		Application.Quit();
	}
	
	void Benninging()
	{
		GetComponent<AudioSource>().Play();
		SceneManager.LoadScene("Main");	
	}
}
