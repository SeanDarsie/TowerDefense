using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemiesInCollider : MonoBehaviour {
	public List<GameObject> creepsInsideCollider = new List<GameObject>();
	
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
