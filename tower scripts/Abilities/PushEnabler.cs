using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEnabler : MonoBehaviour { // so we need to keep a list of all the gameobjects that are Ipushable that enter the colider when this is active.

	public List<GameObject> creepsInsideCollider = new List<GameObject>();
	public int seeme;
	
	void OnTriggerStay(Collider other)
	{
		IPushable pushable = other.GetComponent<IPushable>();
		if (pushable != null)
			{
				if (!creepsInsideCollider.Contains(other.gameObject))
				creepsInsideCollider.Add(other.gameObject);
				Debug.Log("Found a pushableThing");
			}
	}

	void OnTriggerExit(Collider other)
	{
		// IPushable pushable = other.GetComponent<IPushable>();
		if (creepsInsideCollider.Contains(other.gameObject))
			creepsInsideCollider.Remove(other.gameObject);
	}
}
