using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour {
	[HideInInspector]
	public int damage; // set in beetower
	[SerializeField] float speedWhenAttacking;
	[SerializeField] float speedWhenIdle;
	[SerializeField] float minAttackDistance;
	[HideInInspector]
	public Transform myHive; // set in beetower
	[HideInInspector]
	public Transform target;
	float targetingCooldown;
	float attackCooldown;
	float distanceToTarget;
	[HideInInspector]
	public CountEnemiesInCollider enemiesInCollider; // set in beetower
	bool frenzy = false; // not currently used for anything. only set in the frenzy function and 
	bool hasAttacked = false;
	void Start () { 
		
	}
	
	// Update is called once per frame   
	void Update () {
		if (!myHive.gameObject.activeInHierarchy)
			gameObject.SetActive(false);
		if (damage < myHive.gameObject.GetComponent<Tower>().GetDamage())
			damage = myHive.gameObject.GetComponent<Tower>().GetDamage();
		if (target != null)
			if (!target.gameObject.activeInHierarchy)
				DeselectEnemy();
		if (target == null && Time.time >= targetingCooldown) // maybe add a cooldown before selecting an enemy
			SelectEnemy();

		if (target == null) // wander
		{
			float distanceToHive = Vector3.Distance(transform.position, myHive.position);
			if (distanceToHive >= 2.5f) // if the bee is too far come closer. 
				{
					Quaternion rotation = Quaternion.LookRotation(myHive.transform.position - transform.position);
					transform.rotation = rotation;
					transform.Translate((myHive.transform.position - transform.position).normalized * speedWhenIdle * Time.deltaTime,Space.World);
				}
			else if (distanceToHive <= 1.5)
				{
					Quaternion rotation = Quaternion.LookRotation(transform.position - myHive.position);
					transform.rotation = rotation;
					transform.Translate((transform.position - myHive.position).normalized * speedWhenIdle * Time.deltaTime, Space.World);
				}
			else						// else rotate around the hive
				{
					transform.Translate((Vector3.Cross((myHive.transform.position - transform.position) // vector pointing tangent to orbit
									,Vector3.up)).normalized // vector pointing up
									* speedWhenIdle * Time.deltaTime, Space.World); // speed modifiers. also makes it depend on time
					Quaternion rotation = Quaternion.LookRotation((Vector3.Cross((myHive.transform.position - transform.position) // vector pointing tangent to orbit
									,Vector3.up)).normalized);
        			transform.rotation = rotation;
				}
		}
		else
		{
			distanceToTarget = Vector3.Distance(transform.position, target.position);
			// where should i write the code that deals with how the bee moves when it's not attacking

			// go towards the target and stick to it. or orbit around it. 
			// if distance to target is greater than the beetower range stop attacking
			if (distanceToTarget > minAttackDistance)
				{
					Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
					transform.rotation = rotation;
					transform.Translate((target.position - transform.position).normalized * speedWhenAttacking * Time.deltaTime,Space.World);
				}
			else{
				if (Time.time >= attackCooldown)
				{
					Attack();
				}
			}
			if (Vector3.Distance(target.position, myHive.transform.position) >= myHive.gameObject.GetComponent<Tower>().GetRange())
			{
				DeselectEnemy();
			}
		}
		if (Time.time >= frenzyTime)
			{
				frenzy = false;
				damage = myHive.gameObject.GetComponent<Tower>().GetDamage();
			}
	}

	void Attack()
	{
		hasAttacked = true;
		attackCooldown = Time.time + 0.5f;
		target.gameObject.GetComponent<Creep>().TakeDamage(damage, Tower.DamageType.POISON);
	}
	void SelectEnemy()
	{
		if (enemiesInCollider.creepsInsideCollider.Count == 0)
			return;
		int randomInt = (int)Random.Range(0,enemiesInCollider.creepsInsideCollider.Count);
		target = enemiesInCollider.creepsInsideCollider[randomInt].transform;
		if (!target.gameObject.activeInHierarchy)
		{
			target = null;
			return;
		}
		hasAttacked = false;
	}
	void DeselectEnemy()
	{
		target = null;
		if (hasAttacked == false)
			return;
		// hasAttacked = false;
		targetingCooldown = Time.time + 3.0f;
	}
	float frenzyTime;
	public void Frenzy()
	{
		frenzy = true;
		frenzyTime = Time.time + 10f;
		damage *= 2;
	}
}
