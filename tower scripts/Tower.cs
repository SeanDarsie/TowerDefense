using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Tower : MonoBehaviour {

	abstract public void Fire();
	abstract public void Upgrade();
	abstract public void Sell();
	
	[SerializeField] protected float damage;
	[SerializeField] protected  float range;
	[SerializeField] protected  int level;
	[SerializeField] protected  int price;
	[SerializeField] protected  int upgradePrice;
	[SerializeField] protected  int sellPrice;
	[SerializeField] protected 	CreepManager creepManager;
	// Use this for initialization
	protected void Start () {
		creepManager = GameObject.FindWithTag("CreepManager").GetComponent<CreepManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
