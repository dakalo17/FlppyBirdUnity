using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point_Zone : MonoBehaviour
{	
	void OnTriggerEnter(Collider me)
	{
		if(me.tag =="Player")
		{
			Nne.GetPoint = true;
			Nne.Point++;
		}
			
	}   
}
