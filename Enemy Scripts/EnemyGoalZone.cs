using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoalZone : MonoBehaviour { // just needs to handle killing the creeps when they get there. 

	CreepManager creepManager;
	// Use this for initialization
	void Start () {
		creepManager = FindObjectOfType<CreepManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		// Debug.Log("GoalZone:" + other.name);
		Creep creep = other.GetComponent<Creep>();
		CreepNav creepNav = other.GetComponent<CreepNav>();
		if (creep != null)
		{
			creep.DieVictoriously();
		}
		if (creepNav != null)
		{
			creepNav.DieVictoriously();
		}
		// if (creepManager.getActiveCreeps().Contains(other.gameObject))
		// {
		// 	Creep creep = other.GetComponent<Creep>();
		// 	CreepNav creepNav = other.GetComponent<CreepNav>();
		// 	if (creep != null)
		// 	{
		// 		creep.DieVictoriously();
		// 	}
		// 	if (creepNav != null)
		// 	{
		// 		creepNav.DieVictoriously();
		// 	}
		// }
	}
}
