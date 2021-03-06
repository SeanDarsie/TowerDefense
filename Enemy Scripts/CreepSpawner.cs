﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEditor;

public class CreepSpawner : MonoBehaviour {
	// who is supposed to tell the creep spawner to start spawning. Game Manager???
	[SerializeField] CreepManager CM;
	[SerializeField] public GameObject[] creeps; 
	[SerializeField] Transform whereToSpawn;
	int numberOfUniqueCreepTypes;
	[SerializeField] int wave = 0;
	[SerializeField] float timeTillNextWave;
	[SerializeField] int numberOfCreepsToSpawn;
	[SerializeField] float timeBetweenIndividualCreeps;
	[SerializeField] Transform[] movePointsforCreeps;
	float timeBetweenWaves;
	[HideInInspector]
	public bool canSendWave = true;
	public bool isActive = false;
	int names = 0;
	// Use this for initialization
	void Start () { // commment
		CM = GameObject.FindWithTag("CreepManager").GetComponent<CreepManager>();
		whereToSpawn = transform;
		numberOfUniqueCreepTypes = creeps.Length;
		// sendCreepWave();
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive)
		{
			// Debug.Log(canSendWave);
			if (Time.time >= timeBetweenWaves && canSendWave == true)
				sendCreepWave();
		}
	}

	public void sendCreepWave()
	{
		// Debug.Log("SendCreepWave()");
		canSendWave = false;
		// remove inactive creeps here. 
		StartCoroutine(spawnCreepWave(wave, numberOfCreepsToSpawn, timeBetweenIndividualCreeps));
		wave++;
		// timeBetweenWaves = Time.time + timeTillNextWave;
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
		Creep creep = x.GetComponent<Creep>();
		CreepNav creepNav = x.GetComponent<CreepNav>();
		if (creep != null){
			creep.SetHealth(wave * creep.healthIncrement);
			creep.SetMaxHealth(creep.GetHealth());	
			creep.SetSpeed(Random.Range(-1, 1));
			creep.corners = movePointsforCreeps;
		}
		if (creepNav != null)
		{
			creepNav.SetHealth(wave * creepNav.healthIncrement);
			creepNav.SetMaxHealth(creepNav.GetHealth());	
			creepNav.SetSpeed(Random.Range(-1, 1));
			creepNav.corners = movePointsforCreeps;
		}
		x.name = "Goblin" + names.ToString();
		names++;
	}

	IEnumerator spawnCreepWave(int waveNumber, int creepsToSpawn, float seconds)
	{
		for (int i = 0; i < creepsToSpawn; i++)
		{
			// Debug.Log(creepsToSpawn);
			spawnSingleCreep(waveNumber);
			yield return new WaitForSeconds(seconds);
		}
		canSendWave = true;
		timeBetweenWaves = Time.time + timeTillNextWave;
		yield return null;
	}
	public void SetWave(int wave)
	{
		this.wave = wave;
	}
}
