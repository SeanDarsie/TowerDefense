using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreepSpawner : MonoBehaviour {
	// who is supposed to tell the creep spawner to start spawning. Game Manager???
	[SerializeField] CreepManager CM;
	[SerializeField] GameObject[] creeps; 
	[SerializeField] Transform whereToSpawn;
	[SerializeField] int numberOfUniqueCreepTypes;
	[SerializeField] int wave;
	float timeBetweenWaves;
	int names = 0;
	// Use this for initialization
	void Start () { // commment
		CM = GameObject.FindWithTag("CreepManager").GetComponent<CreepManager>();
		whereToSpawn = transform;
		sendCreepWave();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timeBetweenWaves)
			sendCreepWave();
	}

	public void sendCreepWave()
	{
		// remove inactive creeps here. 
		StartCoroutine(spawnCreepWave(wave, 3, 2.0f));
		wave++;
		timeBetweenWaves = Time.time + 25.0f;
		CM.ReMakeList();
	}

	void spawnSingleCreep(int wave)
	{
		// spawn creep at index (wave mod (however many creeps i have - 1))
		// spawn creep at wheretospawn.
		// add creep to list of active creeps
		// If we start repeating the same enemies then we need to start incrimenting their health higher and higher. this is where that should be done
		GameObject x = Instantiate(creeps[wave % numberOfUniqueCreepTypes], whereToSpawn.position, whereToSpawn.rotation) as GameObject;
		CM.addCreepToActiveList(x);
		x.name = "Goblin" + names.ToString();
		names++;
	}

	IEnumerator spawnCreepWave(int waveNumber, int creepsToSpawn, float seconds)
	{
		for (int i = 0; i < creepsToSpawn; i++)
		{
			spawnSingleCreep(waveNumber);
			yield return new WaitForSeconds(seconds);
		}
		yield return null;
	}
}
