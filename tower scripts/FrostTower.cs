using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostTower : Tower {

	[SerializeField] float flashFreezeCD;
	[SerializeField] GameObject flashFreezeIndicator;
	// [SerializeField] 
	// [SerializeField] 
	// [SerializeField] 

	float shotCD;
	bool flashFreezeReady;
	void Update () {
		if (Time.time >= shotCD)
		{
			Fire();
		}
		if (flashFreezeReady == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				FlashFreeze();
			}
			if (Input.GetMouseButtonDown(1))
			{
				DeactivateFlashFreezeIndicator();
			}
		}
	}
	[SerializeField] CountEnemiesInCollider countEnemiesInCollider;
	[SerializeField] float howMuchToSlowEnemies;
	public override void Fire()
	{
		shotCD += reloadSpeed;
		// slow all units within it's radius by a percentage. 
		foreach(GameObject x in countEnemiesInCollider.creepsInsideCollider)
		{
			ISlowable slow = x.GetComponent<ISlowable>();
			if (slow != null)
			{
				slow.BeSlowed(howMuchToSlowEnemies);
			}
		}
	}
	[SerializeField] float howLongToFreezeEnemies;
	void FlashFreeze()
	{
		foreach(GameObject x in countEnemiesInCollider.creepsInsideCollider)
		{
			INettable net = x.GetComponent<INettable>();
			if (net != null)
			{
				net.BeNetted(howLongToFreezeEnemies);
			}
		}
		DeactivateFlashFreezeIndicator();
		// freeze some enemies. doesn't hit air units Air units will have their own path.
	}
	public void ActivateFlashFreezeIndicator()
	{
		if (Time.time < flashFreezeCD)
			return;
		flashFreezeReady = true;
		flashFreezeIndicator.SetActive(true);
	}
	public void DeactivateFlashFreezeIndicator() 
	{
		flashFreezeIndicator.SetActive(false);
		flashFreezeReady = false;	
	}
}
