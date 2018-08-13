using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepSpawner : MonoBehaviour {
	[SerializeField] CreepManager CM;
	[SerializeField] GameObject[] creeps; 
	[SerializeField] Transform whereToSpawn;
	[SerializeField] int numberOfUniqueCreepTypes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnSingleCreep(int wave)
	{
		// spawn creep at index (wave mod (however many creeps i have - 1))
		// spawn creep at wheretospawn.
		// add creep to list of active creeps
		GameObject x = Instantiate(creeps[wave % numberOfUniqueCreepTypes], whereToSpawn.position, whereToSpawn.rotation) as GameObject;
		CM.addCreepToActiveList(x);
	}
}
