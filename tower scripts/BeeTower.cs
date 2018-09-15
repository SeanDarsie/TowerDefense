using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeTower : Tower {

	[Header("BeeTower")]
	[SerializeField] int maxBees;
	[SerializeField] CountEnemiesInCollider countEnemiesInCollider;
	public int numberOfBees;
	List<BeeScript> myBees = new List<BeeScript>();

	// Use this for initialization
	
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
				Frenzy(); // ????????????? what ability does a bee tower want to do? Enrage?? spew honey? Slow them?
				// DeactivateAbilityIndicator();
			}
			if (Input.GetMouseButtonDown(1))
			{
				DeactivateAbilityIndicator();
			}
		}
	}

	override public void Fire()
	{
		// summon a bee if there are not full bees
		if (numberOfBees < maxBees)
		{
			shotCD = Time.time + reloadSpeed;
			numberOfBees++;
			GameObject bee = Instantiate(projectile, firePos.position,firePos.rotation);
			bee.GetComponent<BeeScript>().damage = damage;
			bee.GetComponent<BeeScript>().myHive = transform;
			bee.GetComponent<BeeScript>().enemiesInCollider = countEnemiesInCollider;
			myBees.Add(bee.GetComponent<BeeScript>()); // TODO: add a way to remove bees as well. probably make them die when their target leaves
		}
	}
	public void Frenzy()
	{
		foreach(BeeScript x in myBees)
		{
			x.Frenzy();
		}
		DeactivateAbilityIndicator();
		abilityCountdown = Time.time + abilityCooldown;
		// Temporarily increase the attack of all the beez
	}
}
