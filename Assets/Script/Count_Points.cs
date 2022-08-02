using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_Points : MonoBehaviour
{
	
    void Update()
    {
        if(Nne.GetPoint)
		{
			GetComponent<Text>().text = System.Convert.ToString(Nne.Point);
			GetComponent<AudioSource>().Play();
			Nne.GetPoint = false;
		}	
    }
}
