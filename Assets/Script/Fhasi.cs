using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Analytics;

public class Fhasi : MonoBehaviour
{
	public GameObject clone_fhasi; 
    const float SPEED_TSHA_FHASI=14.5f;

    void FixedUpdate()
    {
		if(!Nne.PauseGame)
		{	GetComponent<Rigidbody2D>().velocity = new Vector2(-Time.deltaTime*SPEED_TSHA_FHASI,0);
			if(transform.position.x <= -1.438f)
			{
				DestroyFhasi();
			}
		}
		else if(Nne.PauseGame)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
		}
			
		
    }
	
	void DestroyFhasi()
	{
		Destroy(gameObject);
		Instantiate(clone_fhasi,new Vector2(1.505f,-1.1f),Quaternion.identity);
	}
	
	
}
