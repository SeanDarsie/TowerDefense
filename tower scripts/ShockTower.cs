using System.Collections;
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
			if (Input.GetMouseButtonDown(0))
			{
				ChainLightning();
			}
			if (Input.GetMouseButtonDown(1))
			{
				DeactivateChainLightningIndicator();
			}
		}	
	}
	[SerializeField] GameObject lightningPrefab;
	float shotCD;
	float chainLightningCD;
	public override void Fire()
	{
		shotCD += reloadSpeed;
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
		DigitalRuby.LightningBolt.LightningBoltScript lightningBolt = lightningPrefab.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>();
		lightningBolt.EndObject = target.gameObject;
		lightningPrefab.SetActive(true);
		StartCoroutine(LightingFiringSequence(target.gameObject, 5));
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
		chainLightningCD = Time.time + abilityCooldown;
		LightningBall chainLightningShot = projectile.GetComponent<LightningBall>();
		chainLightningShot.damage = chainLightningDamage;
		chainLightningShot.numberOfBounces = howManyTimesDoesTheLightningJump;
		abilityReady = false;
		GameObject throwthis = Instantiate(projectile, chainLightningIndicator.transform.position, chainLightningIndicator.transform.rotation);
		
		throwthis.GetComponent<Rigidbody>().AddRelativeForce(0,0,forceOfThrow);
		DeactivateChainLightningIndicator();
	}
	public void DeactivateChainLightningIndicator()
	{
		abilityReady = false;
		chainLightningIndicator.SetActive(false);
	}
	public void ActivateChainLightningIndicator()
	{
		if (Time.time < chainLightningCD)
			return;
		chainLightningIndicator.SetActive(true);
		abilityReady = true;	
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
