using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murahu : MonoBehaviour
{
   
	public GameObject clone_murahu; 
    const float SPEED_TSHA_MURAHU=5.5f;

    void FixedUpdate()
    {
		if(!Nne.PauseGame)
		{
			GetComponent<Rigidbody>().velocity = new Vector3(-Time.deltaTime*SPEED_TSHA_MURAHU,0,0);
			if(transform.position.x <= -1.40f)
			{
				DestroyMurahu();
			}
		}
		else if(Nne.PauseGame)
			GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		
    }
	
	void DestroyMurahu()
	{
		Destroy(gameObject);
		Instantiate(clone_murahu,new Vector3(1.40f,0.01f,0f),Quaternion.identity);
	}
}
