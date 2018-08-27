using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetScript : MonoBehaviour { // could use this as a single standalone class or make a class to inherit from that simply interacts with minions

	void Start () {
		Destroy(gameObject, 3.0f);	
	}
	void OnTriggerEnter(Collider other)
	{	
		INettable x = other.GetComponent<INettable>();
		if (x != null)
		{
			x.BeNetted(1.0f);
		}
	}
}
