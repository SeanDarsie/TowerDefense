using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemiesInCollider : MonoBehaviour {
	public List<GameObject> creepsInsideCollider = new List<GameObject>();
	void OnTriggerEnter(Collider other)
	{
		IHittable hittable = other.GetComponent<IHittable>();
		if (hittable != null)
			{
				if (!creepsInsideCollider.Contains(other.gameObject))
					creepsInsideCollider.Add(other.gameObject);
				for(int i = 0; i < creepsInsideCollider.Count; i++)
				{
					if (!creepsInsideCollider[i].activeInHierarchy)
					{
						creepsInsideCollider.Remove(creepsInsideCollider[i]);		
					}
				}
				// Debug.Log("Found a pushableThing");
			}
	}

	void OnTriggerExit(Collider other)
	{
		if (creepsInsideCollider.Contains(other.gameObject))
			creepsInsideCollider.Remove(other.gameObject);

	}
}
