﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creep : MonoBehaviour, IPushable {

	protected abstract void dieHorribly();
	// protected abstract void dieVictoriously();

	[SerializeField] protected Transform[] corners;
	protected int cornersInd = 0;
	[SerializeField] protected  int rewardForKilling;
	[SerializeField] protected int moneyForKilling;
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
		if (gotPushed)
		{
			RaycastHit hit;
			Ray downRay = new Ray(transform.position, -transform.up);
			if (Physics.Raycast(downRay, out hit, 100))
			{
				if (hit.collider.tag == "Cloud")
				{
					GetComponent<Rigidbody>().useGravity = true;
					// GetComponent<Rigidbody>().AddForce(directionOfPush);
					this.enabled = false;
				}
			}
			else
			{
				GetComponent<Rigidbody>().useGravity = true;
				// GetComponent<Rigidbody>().AddForce(directionOfPush);
				// this.enabled = false;
			}
		}
		if (transform.position.y <= -10f)
			{
				damage = 0;
				playerStats.AdjustMonies(moneyForKilling);
				dieVictoriously();
			}
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
				Destroy(gameObject);
				dieVictoriously();
			}
		}
		Vector3 moveDir = transform.position - corners[cornersInd].position;
		transform.Translate(-moveDir.normalized * speed * Time.deltaTime);
	}
	public  void SetHealth(int bonus)
	{
		health += bonus;
	}
	public void SetSpeed(float adjustment)
	{
		speed += adjustment;
	}
	protected void dieVictoriously()
	{
		// remove 1 life from the player. 
		// creepManager.ReMakeList();
		creepManager.removeCreep(gameObject);
		creepManager.ReMakeList();
		playerStats.AdjustHealth(-damage);
	}
	[SerializeField] float howLongAmIPushedFor;
	bool gotPushed = false;
	public void BePushed(Vector3 directionOfPush)
	{
		// move away from the tower that did the pushing. After a certain amount of seconds check if what is below isa  cloud in a certain amount of seconds
		// how do i turn off this script or it's child class once it's supposed to fall. 
		// preserve how long 
		float howLongToBePushedBack = Time.time + howLongAmIPushedFor;
		gotPushed = true;
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().AddRelativeForce(directionOfPush * 180f);
		//StartCoroutine(PushedAway(howLongToBePushedBack, directionOfPush));
		// gameObject.GetComponent<Rigidbody>().useGravity = true;
	}
	// IEnumerator PushedAway(float lengthOfPushback, Vector3 directionOfPush)
	// {
	// 	float speedOfPush = 1.0f;
	// 	while (Time.time <= lengthOfPushback)
	// 	{
	// 		//move back from the pusher
	// 		transform.Translate(directionOfPush * Time.deltaTime * speedOfPush);
	// 		speedOfPush += 0.2f;
	// 		yield return new WaitForSeconds(Time.deltaTime);
	// 	}
	// 	// check if a cloud is directly beneath me
	// 	RaycastHit hit;
		
	// 	// }	// if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000))
	// 	Ray downRay = new Ray(transform.position, -transform.up);
	// 	if (Physics.Raycast(downRay, out hit, 100))
	// 	{
	// 		if (hit.collider.tag == "Cloud")
	// 			{
	// 				GetComponent<Rigidbody>().useGravity = true;
	// 				// GetComponent<Rigidbody>().AddForce(directionOfPush);
	// 				this.enabled = false;
	// 			}
	// 	}
	// 	yield return null;
	// }
}
