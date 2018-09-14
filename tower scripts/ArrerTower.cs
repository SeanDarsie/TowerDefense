using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrerTower : Tower {
    protected ArrerTower() // constructor
    {
		
	}
	void Update () {
		if (abilityReady)
		{
			if (Input.GetMouseButtonDown(0))
				throwNet();
			if (Input.GetMouseButtonDown(1))
				DeactivateAbilityIndicator();
		}
		if (Time.time >= shotCD)
		{
			Fire();
		}
	}

    public override void Fire()
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
        // throw new System.NotImplementedException();
    }	
	// scatter arrow section
	// [Header("Scatter Ability")]
	// [HideInInspector]
	// bool scatterSelected; // for ui and indicator purposes. 
	// public int scatterDamage;
	// public float scatterRadius;
	// public float scatterCD;
	// private float creepDist;
	// public void upgradeScatterArrowAbility()
	// {
	// 	scatterDamage++; // increase scatter damage.
	// 	scatterRadius++; // increase radius ??
	// 	scatterCD--; // reduce CD
	// }
	// void /// <summary>
	// /// Callback to draw gizmos that are pickable and always drawn.
	// /// </summary>
	// public Color color;
	// void OnDrawGizmos()
	// {
	// 	Gizmos.color = color;
	// 	Gizmos.DrawSphere(transform.position, range);
	// }
	// public void scatterArrow() // list or array. doesn't matter to me atm.
    // {
	// 	List<GameObject> creeps = creepManager.getActiveCreeps();
    //     // deal damage to all creeps within tower range.
	// 	// Debug.Log("Creeps   " + creeps[0].name);
	// 	int something = 0;
    //     foreach (GameObject x in creeps)
    //     {
	// 		// Debug.Log("foreach loop ScatterArrow " + something);
	// 		creepDist = Vector3.Distance(transform.position, x.gameObject.transform.position);
	// 		if (creepDist <= scatterRadius && x.activeInHierarchy)
	// 		{
	// 			IHittable badGuy = x.GetComponent<IHittable>();
	// 			if (badGuy != null)
	// 				badGuy.TakeDamage(scatterDamage);
	// 		}
	// 		something++;
    //     }
	// 	something = 0;
    // }
    // throw net section
    [Header("Net Ability Settings")]
    [HideInInspector]
	// [SerializeField] bool netSelected = false;
	[SerializeField] float netRange;
	[SerializeField] float netCD;
	[SerializeField] GameObject netObject;
	[SerializeField] Transform throwPos;
	[SerializeField] float forceOfThrow;
	[SerializeField] GameObject netIndicator; // AbilityIndicator in TowerClass
	public void throwNet() // simply needs to throw the net in the netThrowDir 
	{
		abilityCountdown = Time.time + abilityCooldown;
		abilityReady = false;
		GameObject throwthis = Instantiate(netObject, netIndicator.transform.position, netIndicator.transform.rotation);
		
		throwthis.GetComponent<Rigidbody>().AddRelativeForce(0,0,forceOfThrow);
		DeactivateAbilityIndicator();
	}

	// private float shotCooldown;
	// public void activateNetIndicator() // activateAbilityIndicator in Tower class
	// {
	// 	if (Time.time < shotCooldown)
	// 		return;
	// 	abilityReady = true;
	// 	netIndicator.SetActive(true); 
	// }
	// public void deactivateNetIndicator() // DeactivateAbilityIndicator in Tower class
	// {
	// 	netIndicator.SetActive(false);
	// 	abilityReady = false;

	// }

}
	