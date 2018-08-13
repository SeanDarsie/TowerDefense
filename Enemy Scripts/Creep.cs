using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creep : MonoBehaviour {
	public abstract void die();
	public abstract void move();
	public abstract void getStunned();
	public abstract void takeDamage(int damage);

	[SerializeField] protected  int rewardForKilling;
	[SerializeField] protected  int health;
	[SerializeField] protected  int damage;
	[SerializeField] protected  float speed;
	[SerializeField] protected  int armor;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void destroyME()
	{
		Destroy(gameObject);
	}
}
