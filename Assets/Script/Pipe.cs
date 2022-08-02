using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
	public GameObject clone;
	const float PIPE_SPEED =12f; 
	
	Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		transform.position = new Vector3(transform.position.x ,Random.Range(-0.4f,0.8f),transform.position.z );
    }

    void Update()
    {
		///(0,-.85) max (x) -> range
		if(!Nne.PauseGame)
		{
			rb.velocity = new Vector3(-PIPE_SPEED*Time.deltaTime,0,0);
			if(transform.position.x <= -1.25f)
			{
				DestroyPipes();
			}
		}
		else if(Nne.PauseGame)
			rb.velocity = new Vector3(0,0,0);
	}
	
	void DestroyPipes()
	{
		///Gap of pipes on (x) -> 1.25f
		///Up Pipe Up (Y)can go from -0.4 to 0.8
		///Spawn at 1.25
		Instantiate(clone,new Vector3(1.75f,Random.Range(-0.4f,0.8f),transform.position.z ),Quaternion.identity);

		Destroy(gameObject);		
	}
}
