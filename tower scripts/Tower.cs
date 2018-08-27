using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Tower : MonoBehaviour {
	protected PlayerStats player;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	public enum DamageType {PHYSICAL,LIGHTNING,FROST,FIRE,POISON, MAGIC};
	public DamageType damageType; 
	abstract public void Fire();

	[Header("From Tower class")]
	[SerializeField] protected string towerName;
	[SerializeField] protected int damage;
	[SerializeField] protected int damageUpgrade;
	[SerializeField] protected float reloadSpeed;
	[SerializeField] protected float reloadSpeedUpgrade;
	[SerializeField] protected  float range;
	[SerializeField] protected float rangeUpgrade;
	[SerializeField] protected  int level;
	[SerializeField] protected  int price;
	[SerializeField] protected  int upgradePrice;
	[SerializeField] protected  int sellPrice;
	[SerializeField] protected Transform target;
	[SerializeField] protected GameObject projectile;
	[SerializeField] protected Transform firePos;
	[SerializeField] protected 	CreepManager creepManager;
	[SerializeField] protected float abilityCooldown;
	[SerializeField] protected bool abilityReady = false;
	// Use this for initialization
	protected void Start () {
		creepManager = FindObjectOfType<CreepManager>();
		player = FindObjectOfType<PlayerStats>();	
	}
	public int GetPrice() {return price;}
	public int GetLevel() {return level;}
	public int GetUpgradePrice() {return upgradePrice;}
	public int GetSellPrice() {return sellPrice;}
	public string GetName() {return towerName;}
	public float GetDPS(){return ((float)(damage) * reloadSpeed);}
	public void SellTower() {
		player.AdjustMonies(sellPrice);
		Debug.Log("Tower class: SellPrice: " + sellPrice);
		// make the space the tower was available again?? not sure how to fit that in
		Destroy(gameObject);
	}
	public void UpgradeTower()
	{
		if (player.monies < upgradePrice)
			return;
		else
			player.AdjustMonies(-upgradePrice);
		damage += damageUpgrade;
		reloadSpeed *= reloadSpeedUpgrade;
		range *= rangeUpgrade;
		// increase damage. 
		// increase rof.
		// increase range.
		// increase level
		level++;
		sellPrice += 1 > upgradePrice/2 ? 1 : upgradePrice/2; 
		upgradePrice *= 2;
		// sellPrice += 1 > upgradePrice/2 ? 1 : upgradePrice/2; 
		damageUpgrade += 1 > damageUpgrade/2 ? 1 : damageUpgrade/2; 
	}

}
