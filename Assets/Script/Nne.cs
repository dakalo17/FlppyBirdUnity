using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Nne : MonoBehaviour
{	
	Scene pauseScene; 
	
	public static int Point=0;
	public static bool GetPoint;
	public static bool PauseGame;
	public Transform GameOver;
	public float FlapSpeed = 24;
	Rigidbody rb;
	
	
    void Start()
    {
		GameObject.FindWithTag("FinalScore").GetComponent<Text>().text ="";
		GameOver.position = new Vector3(0,1.5f,0);
		transform.position = new Vector3(transform.position.x,transform.position.y,0.01f);			
		PauseGame =false;
		GetPoint = false;
        rb = GetComponent<Rigidbody>();
		pauseScene = SceneManager.GetSceneByName("PauseScreen");
        StartCoroutine(BackToMenu());

    }

    void FixedUpdate()
    {
		
        if(Input.GetKey("space") && !Pipes_1_2.PlayerDead && !PauseGame)
		{
			GetComponent<Animator>().SetBool("Clicking",true);
			GetComponent<Animator>().SetFloat("Movement",1f);
			rb.velocity = new Vector3(0,FlapSpeed*Time.fixedDeltaTime,0);
		}
		else
		{
			GetComponent<Animator>().SetBool("Clicking",false);
			GetComponent<Animator>().SetFloat("Movement",0f);
			rb.AddForce(new Vector3(0,-4.5f*FlapSpeed*rb.mass*Time.fixedDeltaTime,0), ForceMode.Force);
		}
		if(PauseGame)
		{
			transform.position = new Vector3(transform.position.x,transform.position.y,-1);
		}
		if((Input.GetKeyDown(KeyCode.Escape) || 
		Input.GetKeyDown(KeyCode.Mouse0)) && 
		!pauseScene.isLoaded)
		{
			GameObject.FindWithTag("Point").GetComponent<Text>().text = "";
			Time.timeScale = 0;
			PauseScreen();
		}
        
    }
	   

    void UnloadMain()
    {
        Point = 0;
        ///Unload Main Scene and load menu scene
        SceneManager.UnloadSceneAsync("Main");
	    Resources.UnloadUnusedAssets();
        SceneManager.LoadScene("Start");
    }
	
    IEnumerator BackToMenu()
    {
        while (!(transform.position.y <= -0.765f || transform.position.y >= 1.26))
            yield return null;

        //Stop Nne
        rb.velocity = new Vector3(0, 0, 0);
		GameOver.position = new Vector3(0,1f,0);
		
		GameObject.FindWithTag("Point").GetComponent<Text>().text = "";
		GameObject.FindWithTag("FinalScore").GetComponent<Text>().text = "Score: " + System.Convert.ToString(Point);
		
        GetComponent<Animator>().enabled = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        //Play hit sfx
        GetComponent<AudioSource>().Play();
        PauseGame = true;
        yield return new WaitForSeconds(2f);

        UnloadMain();
    }

	void PauseScreen()
	{
		SceneManager.LoadScene("PauseScreen",LoadSceneMode.Additive);		
	}
}
