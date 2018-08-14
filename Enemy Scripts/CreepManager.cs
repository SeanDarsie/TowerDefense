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
		 return(activeCreeps);
	 }
	 public void removeCreep(GameObject x)
	 {
		 if (activeCreeps.Contains(x))
		 	activeCreeps.Remove(x);	
	 }
}
