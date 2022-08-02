using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes_1_2 : MonoBehaviour
{
	public static bool PlayerDead;
	void Start()
	{
		PlayerDead =false;
	}
    void OnTriggerEnter(Collider nne)
	{
		if(nne.tag == "Player")
		{
			Nne.PauseGame = true;
			PlayerDead = true;
		}
	}
}
