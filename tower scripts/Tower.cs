using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// TODO: Add audioclips to play when a tower is placed and when a tower fires. 
//       Add audioclips for upgrading the tower and selling the tower
// 		 Add audioclips for tower abilities and tower selection(maybe unique per tower, likely not)
//		 Add the functionality that makes those sounds play at the right time. For placing it will be the tower block script
//	 	 For firing and ability sounds it will be the abstract class Tower.



abstract public class Tower : MonoBehaviour {
	protected PlayerStats player;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	public enum DamageType {PHYSICAL,LIGHTNING,FROST,FIRE,POISON, MAGIC};
	public DamageType damageType; 
	protected AudioSource audioSource;
	[SerializeField] protected AudioClip firingSound;
	// [SerializeField] protected AudioClip buildingSound;
	// [SerializeField] protected AudioClip sellingSound;
	// [SerializeField] protected AudioClip upgradingSound;
	// [SerializeField] protected AudioClip abilitySound;
	abstract public void Fire(); // All subclasses must implement a function with this name

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
	[SerializeField] protected GameObject abilityIndicator;
	[SerializeField] protected Transform firePos;
	[SerializeField] protected 	CreepManager creepManager;
	[SerializeField] protected float abilityCooldown;
	[SerializeField] protected bool abilityReady = false;
	protected float shotCD;
	// Use this for initialization
	protected void Start () {
		creepManager = FindObjectOfType<CreepManager>();
		player = FindObjectOfType<PlayerStats>();	
		audioSource = GetComponent<AudioSource>();
	}
	
	// =------------------------- Getters ------------------------= //
	public float GetRange() {return range;}
	public int GetDamage() {return damage;}
	public int GetPrice() {return price;}
	public int GetLevel() {return level;}
	public int GetUpgradePrice() {return upgradePrice;}
	public int GetSellPrice() {return sellPrice;}
	public string GetName() {return towerName;}
	public float GetDPS(){return ((float)(damage) / reloadSpeed);}
	// =------------------------- Getters ------------------------= //

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
		level++;
		sellPrice += 1 > upgradePrice/2 ? 1 : upgradePrice/2; 
		upgradePrice *= 2;
		// sellPrice += 1 > upgradePrice/2 ? 1 : upgradePrice/2; 
		// damageUpgrade += 1 > damageUpgrade/2 ? 1 : damageUpgrade/2; 
	}
	protected float abilityCountdown;
	public void ActivateAbilityIndicator() // activateAbilityIndicator in Tower class
	{
		if (Time.time < abilityCountdown)
			return;
		abilityReady = true;
		abilityIndicator.SetActive(true); 
	}
	public void DeactivateAbilityIndicator() // DeactivateAbilityIndicator in Tower class
	{
		abilityIndicator.SetActive(false);
		abilityReady = false;
	}

}
