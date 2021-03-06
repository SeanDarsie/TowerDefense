﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockTower : Tower {
	
	// Update is called once per frame
	void Update () {

		if (Time.time >= shotCD)
		{
			Fire();
		}
		if (abilityReady == true)
		{
			FindObjectOfType<TowerPlacingScript>().towerUIAbleToBeSummoned = false;
			if (Input.GetMouseButtonDown(0))
			{
				ChainLightning();
			}
			if (Input.GetMouseButtonDown(1))
			{
				DeactivateAbilityIndicator();
			}
		}	
	}
	[SerializeField] GameObject lightningPrefab;
	[SerializeField] int lightningStrikes;
	float chainLightningCD;
	public override void Fire()
	{

		float rangeFinder = 0f;
		foreach (GameObject x in enemiesInRange.creepsInsideCollider)
		{
			float distanceToTower = Vector3.Distance(firePos.position, x.transform.position);
			if (distanceToTower > rangeFinder && distanceToTower <= range && x.activeInHierarchy && Mathf.Abs(x.transform.position.y - transform.position.y) <= 1f)
				{
					target = x.transform;
					rangeFinder = distanceToTower;
				}
		}
		if (target == null ||
			!target.gameObject.activeInHierarchy ||
			Vector3.Distance(transform.position, target.position) > range)
			return;
		DigitalRuby.LightningBolt.LightningBoltScript lightningBolt = lightningPrefab.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>();
		lightningBolt.EndObject = target.gameObject;
		lightningPrefab.SetActive(true);
		shotCD += reloadSpeed;
		StartCoroutine(LightingFiringSequence(target.gameObject, lightningStrikes));
		// so now we have a target. we can pass that target to a coroutine that will fire x number of shots over some seconds and presumably show some cool lightning effect while it does it. for now i'm just going to throw shit at it i think
		// i think i'm going to start a coroutine to do attacks over a period of time. 
		// Debug.Log("Unimplimented Fire() in Shock tower");
	}
	[SerializeField] GameObject chainLightningIndicator;
	[SerializeField] int howMuchDamageTheChainLightningDoes;
	[SerializeField] int howManyTimesDoesTheLightningJump;
	[SerializeField] float forceOfThrow;
	[SerializeField] int chainLightningDamage;
	void ChainLightning()
	{
		// i think i will send out  a projectile here
		abilityCountdown = Time.time + abilityCooldown;
		LightningBall chainLightningShot = projectile.GetComponent<LightningBall>();
		chainLightningShot.damage = chainLightningDamage;
		chainLightningShot.numberOfBounces = howManyTimesDoesTheLightningJump;
		abilityReady = false;
		GameObject throwthis = Instantiate(projectile, chainLightningIndicator.transform.position, chainLightningIndicator.transform.rotation);
		
		throwthis.GetComponent<Rigidbody>().AddRelativeForce(0,0,forceOfThrow);
		DeactivateAbilityIndicator();
	}
	
	IEnumerator LightingFiringSequence(GameObject targetOfAttack, int howManyTimesToAttack)
	{
		
		yield return new WaitForSeconds(0.5f);
		for (int i = 0; i <howManyTimesToAttack; i++)
		{
			// DigitalRuby.LightningBolt.LightningBoltScript lightningBolt = lightningPrefab.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>();
			// lightningBolt.EndObject = target.gameObject;
			// lightningPrefab.SetActive(true);
			target.GetComponent<IHittable>().TakeDamage(damage, damageType);
			if (!targetOfAttack.activeInHierarchy)
				{
					lightningPrefab.SetActive(false);
					StopAllCoroutines();
					lightningPrefab.SetActive(false);
				}
			yield return new WaitForSeconds(0.25f);
		}
		lightningPrefab.SetActive(false);
		yield return null;
	}
}
