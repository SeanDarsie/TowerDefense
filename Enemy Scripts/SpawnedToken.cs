using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedToken : Creep {

	// Use this for initialization
	int index;
	Transform[] myCorners;
	[SerializeField] float timeTillMoving;
	public void Spawn(int currentInd, Transform[] waypoints, Vector3 lilPush, int health,string myName)
	{
		myCorners = waypoints;
		index = currentInd;

		// hopefully i can find a convenient way around this
		this.corners = myCorners;
		cornersInd = index;
		// for now it will have to do because i don't want to have errors.

		this.health = health / 4;
		this.maxHealth = health / 4;
		this.name = name + ((int)Random.Range(1, 1000)).ToString();
		FindObjectOfType<CreepManager>().addCreepToActiveList(gameObject);
		GetComponent<Rigidbody>().AddForce(lilPush);
		Invoke("StartMoving",timeTillMoving);
	}

	void StartMoving()
	{
		this.corners = myCorners;
		cornersInd = index;
		GetComponent<Rigidbody>().useGravity =false;
		GetComponent<Rigidbody>().isKinematic =true;
	}
}
