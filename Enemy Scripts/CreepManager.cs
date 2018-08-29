using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepManager : MonoBehaviour {
	// keeps track of all the active creeps. 
	[SerializeField] private List<GameObject> activeCreeps = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
 	public void addCreepToActiveList(GameObject x)
	 {
		 activeCreeps.Add(x);
	 }
	 public List<GameObject> getActiveCreeps()
	 {
		 ReMakeList();
		 return(activeCreeps);
	 }
	 public void ReMakeList() // TODO: find a way to NOT do this!
	 {
		 activeCreeps.Clear();

		Creep[] creepers = FindObjectsOfType<Creep>();
		foreach (Creep x in creepers)
		{
			if (x.gameObject.activeInHierarchy)
				activeCreeps.Add(x.gameObject);
			else
			{
				// Debug.Log("Destroying inactive creep-> " + x.gameObject.name);
				Destroy(x.gameObject);
			}
		}

	 }
	 public void removeCreep(GameObject x)
	 {
		 if (activeCreeps.Contains(x))
		 	{
				//  Debug.Log("Removing" + x);
				 				//  Destroy(x);
				x.SetActive(false);
				//ReMakeList();
				//  activeCreeps.
				//  foreach (GameObject p in activeCreeps)
				//  {
				// 	 Debug.Log(p.name);
				//  }

			 }
	 }
	 public void DestroyAllActiveCreeps()
	 {
		 foreach(GameObject x in activeCreeps)
		 {
			 Destroy(x);
		 }
		 activeCreeps.Clear();
	 }
}
