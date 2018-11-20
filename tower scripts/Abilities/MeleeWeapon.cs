using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {
	CountEnemiesInCollider enemiesInCollider;
	[SerializeField] public float rotationSpeed;
	[SerializeField] float spinTime = 5.0f;
	[SerializeField] float originalRotationSpeed;
	[SerializeField] public float attackRate = 2;
	bool dealtDamage;
	float attackCDTimer;
	public int damage;
	bool canDealDamage = true;
	// Use this for initialization
	void Start () {
		enemiesInCollider = GetComponent<CountEnemiesInCollider>();	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed,Space.World);
		if (Time.time >= attackCDTimer)
		{
			canDealDamage = true;
			dealtDamage = false;
		}
	}
	/// <summary>
	/// OnTriggerStay is called once per frame for every Collider other
	/// that is touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerStay(Collider other)
	{
		if (canDealDamage == true)
		{
			foreach(GameObject x in enemiesInCollider.creepsInsideCollider)
			{
				IHittable hitMe = x.GetComponent<IHittable>();
				if (hitMe!= null)
					{
						hitMe.TakeDamage(damage, Tower.DamageType.LIGHTNING);
						dealtDamage = true;
					}
			}
			if (dealtDamage == true)
			{
				canDealDamage = false;
				attackCDTimer = Time.time + attackRate;
			}
		}
	}
	public void SpinTaWin()
	{
		attackRate = 0.1f;
		rotationSpeed *= 5; 
		canDealDamage = true;
		dealtDamage = false;
		Invoke("ResetSpeed", spinTime);
	}
	void ResetSpeed()
	{
		rotationSpeed = originalRotationSpeed;
		attackRate = 2f;
	}
}
