﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creep : MonoBehaviour {

	protected abstract void dieHorribly();
	protected abstract void dieVictoriously();

	[SerializeField] protected Transform[] corners;
	protected int cornersInd = 0;
	[SerializeField] protected  int rewardForKilling;
	[SerializeField] protected  int health;
	[SerializeField] protected  int damage;
	[SerializeField] protected  float speed;
	[SerializeField] protected  int armor;
	[SerializeField] protected CreepManager creepManager;
	[SerializeField] protected PlayerStats playerStats;

	// Use this for initialization
	protected void Start () {
		creepManager = FindObjectOfType<CreepManager>();
		playerStats = FindObjectOfType<PlayerStats>();
		corners = FindObjectOfType<LevelManager>().getCoreners();
		creepManager.addCreepToActiveList(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Creep Update");
		moveToNextSpot();
	}
	
	protected void moveToNextSpot()
	{
		// move towards next corner if you have reached 
		if (Vector3.Distance(transform.position, corners[cornersInd].position) < 0.5f)
		{
			cornersInd++;
			if (cornersInd >= corners.Length)
			{
				cornersInd = 0;
				gameObject.GetComponent<Goblin>().dieHorribly();
			}
		}
		Vector3 moveDir = transform.position - corners[cornersInd].position;
		transform.Translate(-moveDir.normalized * speed * Time.deltaTime);
	}
}
