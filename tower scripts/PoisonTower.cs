using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTower : Tower {
	
	[SerializeField] Transform gunHolder;
	[SerializeField] AutoRotate gunRotator;
	[SerializeField] CountEnemiesInCollider enemiesInCollider;
	[SerializeField] int poisonDamage;
	[SerializeField] int poisonTicks;

	void Update () {
		if (target == null || !target.gameObject.activeInHierarchy)
		{
			// gunRotator.enabled = true;
		}
		else
		{
			Quaternion rotation = Quaternion.LookRotation(target.position - gunHolder.position);
			gunHolder.rotation = rotation;
		}
		if (Time.time >= shotCD)
		{
			FindTarget();
			Invoke("Fire", 0.1f);
			shotCD = Time.time + reloadSpeed + 0.1f;
			// Fire();
		}
		if (abilityReady == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				PoisonCloud();
			}
			if (Input.GetMouseButtonDown(1))
			{
				DeactivateAbilityIndicator();
			}
		}
	}
	// public override void Fire()
	// {
	// 	float rangeFinder = 10000f;
	// 	foreach(GameObject x in enemiesInCollider.creepsInsideCollider)
	// 	{
	// 		float distanceToTower = Vector3.Distance(firePos.position, x.transform.position);
	// 		if (distanceToTower < rangeFinder 								&&
	// 		distanceToTower <= range          								&&
	// 		x.activeInHierarchy               								&&
	// 		Mathf.Abs(x.transform.position.y - transform.position.y) <= 2f 	&&
	// 		!x.GetComponent<Creep>().isPoisoned)
	// 		{
	// 			target = x.transform;
	// 			rangeFinder = distanceToTower;
	// 		}
	// 	}
	// 	if (target == null 							||
	// 		!target.gameObject.activeInHierarchy 	||
	// 		Vector3.Distance(transform.position, target.position) > range)
	// 		return;
	// 	// shoot an arrow and give it a target to fly towards.
	// 	GameObject poisonProjectile = Instantiate(projectile, firePos.position, firePos.rotation) as GameObject;
	// 	PoisonBall poisonBall = poisonProjectile.GetComponent<PoisonBall>(); 
	// 	poisonBall.damage = damage;
	// 	poisonBall.target = target;
	// 	poisonBall.poisonDamage = damage;
	// 	poisonBall.poisonTicks = poisonTicks;
	// 	poisonBall.damageType = damageType;
	// 	shotCD = Time.time + reloadSpeed;
	// }
	void PoisonCloud()
	{
		abilityCountdown = Time.time + abilityCooldown;
		foreach(GameObject x in enemiesInCollider.creepsInsideCollider)
		{
			x.GetComponent<Creep>().BePoisoned(50, 3);
		}
		DeactivateAbilityIndicator();
		// Instantiate an effect. 
		// Play a sound

		// Debug.Log("poisonShot");
	}
	void FindTarget()
	{
		float rangeFinder = 10000f;
		foreach(GameObject x in enemiesInCollider.creepsInsideCollider)
		{
			float distanceToTower = Vector3.Distance(firePos.position, x.transform.position);
			if (distanceToTower < rangeFinder 								&&
			distanceToTower <= range          								&&
			x.activeInHierarchy               								&&
			Mathf.Abs(x.transform.position.y - transform.position.y) <= 2f 	&&
			!x.GetComponent<Creep>().isPoisoned)
			{
				target = x.transform;
				rangeFinder = distanceToTower;
			}
		}
	}
	public override void Fire()
	{
		if (target == null 							||
			!target.gameObject.activeInHierarchy 	||
			target.GetComponent<Creep>().isPoisoned ||
			Vector3.Distance(transform.position, target.position) > range)
			return;
		// shoot an arrow and give it a target to fly towards.
		GameObject poisonProjectile = Instantiate(projectile, firePos.position, firePos.rotation) as GameObject;
		PoisonBall poisonBall = poisonProjectile.GetComponent<PoisonBall>(); 
		poisonBall.damage = damage;
		poisonBall.target = target;
		poisonBall.poisonDamage = damage;
		poisonBall.poisonTicks = poisonTicks;
		poisonBall.damageType = damageType;
		// shotCD = Time.time + reloadSpeed;
	}
}
