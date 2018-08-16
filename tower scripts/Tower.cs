using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Tower : MonoBehaviour {

	abstract public void Fire();
	abstract public void Upgrade();
	abstract public void Sell();
	[Header("From Tower class")]
	[SerializeField] protected int damage;
	[SerializeField] protected float reloadSpeed;
	[SerializeField] protected  float range;
	[SerializeField] protected  int level;
	[SerializeField] protected  int price;
	[SerializeField] protected  int upgradePrice;
	[SerializeField] protected  int sellPrice;
	[SerializeField] protected Transform target;
	[SerializeField] protected 	CreepManager creepManager;
	// Use this for initialization
	protected void Start () {
		creepManager = FindObjectOfType<CreepManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
