using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepManager : MonoBehaviour {
	// protected CreepManager () {}   
	public List<GameObject> activeCreeps = new List<GameObject>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public List<GameObject> getActiveCreeps()
	{
		return(activeCreeps);
	}

	public void addCreepToActiveList(GameObject newlySpawnedCreep)
	{
		activeCreeps.Add(newlySpawnedCreep);
	}
	public void removeCreepFromActiveList(GameObject deadCreep)
	{
		activeCreeps.Remove(deadCreep);
	}
}
