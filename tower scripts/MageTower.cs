using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : Tower {
	[SerializeField] CountEnemiesInCollider pushEnabler;
	// Use this for initialization

	
	// Update is called once per frame
	private float forcePushCD;
	void Update () {
		if (Time.time >= shotCD)
		{
			Fire();
		}
		if (abilityReady == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				ForcePush();
			}
			if (Input.GetMouseButtonDown(1))
			{
				DeactivateAbilityIndicator();
			}
		}
	}
	override public void Fire()
	{
		float rangeFinder = 10000f;
		foreach(GameObject x in creepManager.getActiveCreeps())
		{
			float distanceToTower = Vector3.Distance(firePos.position, x.transform.position);
			if (distanceToTower < rangeFinder && distanceToTower <= range && x.activeInHierarchy && Mathf.Abs(x.transform.position.y - transform.position.y) <= 1f)
				{
					target = x.transform;
					rangeFinder = distanceToTower;
				}
		}
		if (target == null ||
			!target.gameObject.activeInHierarchy ||
			Vector3.Distance(transform.position, target.position) > range)
			return;
		// shoot an arrow and give it a target to fly towards.
		GameObject myArrow = Instantiate(projectile, firePos.position, firePos.rotation) as GameObject;
		Arrow arrow = myArrow.GetComponent<Arrow>(); 
		arrow.damage = damage;
		arrow.target = target;
		arrow.damageType = damageType;
		shotCD = Time.time + reloadSpeed;
	}
	// bool forcePushReady = false;
	[SerializeField] GameObject forcePushIndicator;
	void ForcePush()
	{
		abilityCountdown = Time.time + abilityCooldown;
		foreach (GameObject x in pushEnabler.creepsInsideCollider)
		{
			Vector3 someDirection = x.transform.position - transform.position;
			// Debug.Log("someDirection: " + someDirection);
			// x.GetComponent<IPushable>().BePushed(someDirection);
			// x.GetComponent<Creep>().enabled = false;
			x.GetComponent<IPushable>().BePushed(-someDirection);
		}
		DeactivateAbilityIndicator();
	}
}
