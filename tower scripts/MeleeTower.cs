using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTower : Tower {
	
	[SerializeField] MeleeWeapon weapon;
	// Update is called once per frame
	void Update () {
		if (weapon.damage < damage)
			weapon.damage = damage;
		if (abilityReady == true)
		{
			FindObjectOfType<TowerPlacingScript>().towerUIAbleToBeSummoned = false;
			if (Input.GetMouseButtonDown(0))
			{
				SpinToWin();
			}
			if (Input.GetMouseButtonDown(1))
			{
				DeactivateAbilityIndicator();
			}
		}
	}
	public override void Fire()
	{

	}

	public void SpinToWin()
	{
		// spin the melee weapon. Give it a lower cd for doing damage. 
		weapon.SpinTaWin();
		DeactivateAbilityIndicator();
		abilityCountdown = Time.time + abilityCooldown;
	}

}
