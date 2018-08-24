using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : Tower {
	[SerializeField] PushEnabler pushEnabler;
	// Use this for initialization

	
	// Update is called once per frame
	private float shotCD;
	private float forcePushCD;
	void Update () {
		if (Time.time >= shotCD)
		{
			Fire();
		}
		if (forcePushReady == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				ForcePush();
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
		shotCD = Time.time + reloadSpeed;
	}
	bool forcePushReady = false;
	[SerializeField] GameObject forcePushIndicator;
	[SerializeField] float forcePushCooldown;
	void ForcePush()
	{
		forcePushCD = Time.time + forcePushCooldown;
		foreach (GameObject x in pushEnabler.creepsInsideCollider)
		{
			Vector3 someDirection = x.transform.position - transform.position;
			Debug.Log("someDirection: " + someDirection);
			x.GetComponent<IPushable>().BePushed(someDirection);
			// x.GetComponent<Creep>().enabled = false;
			x.GetComponent<IPushable>().BePushed(someDirection);
		}
		DeactivateForcePushIndicator();
	}
	public void ActivateForcePushIndicator()
	{
		if (Time.time < forcePushCD)
			return;
		forcePushReady = true;
		forcePushIndicator.SetActive(true);
		// line = GetComponent<LineRenderer>();
	}
	public void DeactivateForcePushIndicator() 
	{
		forcePushIndicator.SetActive(false);
		forcePushReady = false;
		// line.SetPosition(1, transform.position);
	}
}
