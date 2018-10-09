using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creep : MonoBehaviour, IPushable, IHittable, IStunnable, INettable, ISlowable, IShockable,IBurnable,IPoisonable {

	// protected abstract void dieHorribly();
	// protected abstract void dieVictoriously();
	public delegate void CreepDies();
	public event CreepDies ThisCreepHasDied;
	[SerializeField] public 	Transform[]	corners;
	[SerializeField] protected  int 		rewardForKilling;
	[SerializeField] protected 	int 		moneyForKilling;
	[SerializeField] protected  int 		health;
	[SerializeField] protected  int 		maxHealth;
	[SerializeField] public 	int 		healthIncrement; // public so it can be used by the creepspawner. Serialized so it looks more pretty!
	[SerializeField] protected  int 		damage;
	[SerializeField] protected  float 		speed;
	[SerializeField] protected 	float 		turnSpeed = 5.0f;
	[SerializeField] protected  int 		physicalResistance; 
	[SerializeField] protected 	int 		shockResistance;
	[SerializeField] protected 	int 		fireResistance;
	[SerializeField] protected 	int 		frostResistance;
	[SerializeField] protected 	int 		poisonResistance;
	[SerializeField] protected 	int 		magicResistance;
	[SerializeField] protected 	int 		physicalVulnerability;	
	[SerializeField] protected 	int 		shockVulnerability;
	[SerializeField] protected 	int 		fireVulnerability;
	[SerializeField] protected 	int 		frostVulnerability;
	[SerializeField] protected 	int 		poisonVulnerability;
	[SerializeField] protected 	int 		magicVulnerability;
	[SerializeField] protected 	float 		frostResistanceToSlow; // the interface function beslowed will be affected by this ????? percentage i guess
	[SerializeField] protected 	CreepManager creepManager;
	[SerializeField] protected 	PlayerStats	 playerStats;
	[SerializeField] public 	bool		 isPoisoned;
	[SerializeField] protected	float		 poisonTimeTick = 1.0f;
	[SerializeField] public		int			 poisonDamage;
	protected int cornersInd = 0;
	protected int poisonTicks = 0;
	protected float poisonTime;

	void OnEnable()
	{
		ThisCreepHasDied += dieHorribly;
	}
	void OnDisable()
	{
		ThisCreepHasDied -= dieHorribly;
	}
	protected void Start () {
		creepManager = FindObjectOfType<CreepManager>();
		playerStats = FindObjectOfType<PlayerStats>();
		// corners = FindObjectOfType<LevelManager>().getCoreners();
		creepManager.addCreepToActiveList(gameObject);
	}
	
	// Update is called once per frame
	protected float timeSincePush;
	void Update () {
		//Debug.Log("Creep Update");
		LookAtDestination();
		moveToNextSpot();
		
		if (gotPushed && Time.time >= timeSincePush)
		{
			RaycastHit hit;
			Ray downRay = new Ray(transform.position, -Vector3.up);
			if (Physics.Raycast(downRay, out hit, 100))
			{
				if (hit.collider.tag == "Cloud")
				{
					GetComponent<Rigidbody>().useGravity = true;
				}
				else
				{
					GetComponent<Rigidbody>().useGravity = false;
					GetComponent<Rigidbody>().isKinematic = true;
				}
			}
			else
			{
				GetComponent<Rigidbody>().useGravity = true;

			}
		}
		if (transform.position.y <= -10f)
				dieHorribly();
		if (isPoisoned == true && Time.time >= poisonTime)
		{
			TakeDamage(poisonDamage, Tower.DamageType.POISON);
			poisonTicks--;
			if (poisonTicks <= 0)
				isPoisoned = false;
			else
				poisonTime = Time.time + poisonTimeTick;
		}
	}
	
	protected void moveToNextSpot()
	{
		// move towards next corner if you have reached 
		if (Vector3.Distance(transform.position, corners[cornersInd].position) < 0.5f)
		{
			cornersInd++;
			if (cornersInd >= corners.Length)
			{
				cornersInd = 0;
				Destroy(gameObject);
				dieVictoriously();
			}
		}
		Vector3 moveDir = transform.position - corners[cornersInd].position;
		transform.Translate(-moveDir.normalized * speed * Time.deltaTime, Space.World);
	}
	protected void LookAtDestination()
	{
  
        Vector3 targetDir = corners[cornersInd].position - transform.position;

        // The step size is equal to speed times frame time.
        float step = turnSpeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        // Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);

	}

	public int GetHealth() {return (health);}
	public int GetMaxHealth() {return maxHealth;}
	public  void SetHealth(int bonus)
	{
		health += bonus;
	}
	public void SetMaxHealth(int health)
	{
		maxHealth = health;
	}
	public void SetSpeed(float adjustment)
	{
		speed += adjustment;
	}
	protected void dieVictoriously()
	{
		// GetComponent<Rigidbody>().useGravity = true;
		// GetComponent<Rigidbody>().isKinematic = false;
		// GetComponent<Rigidbody>().AddRelativeForce(Random.Range(-2000, 2000),Random.Range(0, 1000),Random.Range(-2000, 2000));
		
		creepManager.removeCreep(gameObject);
		creepManager.ReMakeList();
		playerStats.AdjustHealth(-damage);
	}
	[SerializeField] float howLongAmIPushedFor;
	protected bool gotPushed = false;
	[SerializeField] protected float forceToBePushedBy;
	public void BePushed(Vector3 directionOfPush)
	{
		// move away from the tower that did the pushing. After a certain amount of seconds check if what is below isa  cloud in a certain amount of seconds
		// how do i turn off this script or it's child class once it's supposed to fall. 
		// preserve how long 
		if (forceToBePushedBy == 0)
			return;
		timeSincePush = Time.time + howLongAmIPushedFor;
		gotPushed = true;
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().AddForce(directionOfPush * forceToBePushedBy);
	}
	public void TakeDamage(int damage, Tower.DamageType damageType)
	{
		if (health <= 0)
			return;
		switch(damageType)
		{
			case Tower.DamageType.PHYSICAL:
				damage -= physicalResistance;
				damage += physicalVulnerability;
				break;
			case Tower.DamageType.LIGHTNING:
				damage -= shockResistance;
				damage += shockVulnerability;
				break;
			case Tower.DamageType.FROST:
				damage -= frostResistance;
				damage += frostVulnerability;
				break;
			case Tower.DamageType.FIRE:
				damage -= fireResistance;
				damage += fireVulnerability;
				break;
			case Tower.DamageType.POISON:
				damage -= poisonResistance;
				damage += poisonVulnerability;
				break;
			case Tower.DamageType.MAGIC:
				damage -= magicResistance;
				damage += magicVulnerability;
				break;
			default:
				damage -= physicalResistance;
				break;
		}
		if (damage < 5)
			damage = 5;
		health -= damage;
		if (health <= 0)
		{
			if (ThisCreepHasDied != null)
				ThisCreepHasDied();
		}
	}

	protected void dieHorribly()
	{
		// TODO: show some effect that the goblin has died.
		// play a death sound as well
		// GetComponent<Rigidbody>().useGravity = true;
		// GetComponent<Rigidbody>().isKinematic = false;
		// GetComponent<Rigidbody>().AddRelativeForce(Random.Range(-2000, 2000),Random.Range(0, 1000),Random.Range(-2000, 2000));
		// Debug.Log(gameObject.name + " has just died horribly");
		playerStats.UpdateScore(rewardForKilling);
		playerStats.AdjustMonies(moneyForKilling);
		creepManager.removeCreep(gameObject);
	}
	public void GetStunned(float seconds)
	{
		// TODO: play a stunned animation. and sound!
		if (speed == 0)
			CancelInvoke(); 
		else
			tempSpeed = speed;
		speed = 0;
		Invoke("ResetSpeed", seconds);
		// stop for seconds and 
	}
	float tempSpeed;
	public void BeNetted(float seconds)
	{
		if (speed == 0)
			CancelInvoke(); 
		else
			tempSpeed = speed;
		speed = 0;
		Invoke("ResetSpeed", seconds);
	}
	public void BeSlowed(float amt)
	{
		if (speed < tempSpeed)
			{
				CancelInvoke();
				Invoke("ResetSpeed", 2.0f);
				return;
			}
		else
			tempSpeed = speed;
		speed *= amt;
		// Debug.Log("Creep Speed: " +speed);
		// speed = speed > amt ? (speed - amt) : 0f;

		Invoke("ResetSpeed", 2.0f);
	}
	public void BeShocked(int shockDamage, int numberOfBounces)
	{
		TakeDamage(shockDamage, Tower.DamageType.LIGHTNING);
		BeNetted(0.5f);
	}
	public void BeBurned(int burnDamage, int burnTicks)
	{
		Debug.Log("Got burned");
	}
	public void BePoisoned(int poisonDamage, int poisonTicks)
	{
		if (isPoisoned == false)
		{
			this.poisonDamage = poisonDamage;
			this.poisonTicks += poisonTicks;
			isPoisoned = true;
		}
		else
		{
			this.poisonDamage = this.poisonDamage > poisonDamage ? this.poisonDamage : poisonDamage;
			this.poisonTicks += poisonTicks;
		}
	}
	IEnumerator ShockTheNextGuy(int shockDamage, int numberOfBounces)
	{
		yield return new WaitForSeconds(0.5f);
		// find the closest shockable gameobject and call it's shockable function
		float rangeFinder = 10000f;
		GameObject target = null;
		foreach(GameObject x in creepManager.getActiveCreeps())
		{
			float distanceToTower = Vector3.Distance(transform.position, x.transform.position);
			if (distanceToTower < rangeFinder && x.activeInHierarchy && x != this)
				{
					target = x;
					rangeFinder = distanceToTower;
				}
		}
		if (target != null)
			{
				DigitalRuby.LightningBolt.LightningBoltScript freeLightning = GameObject.FindWithTag("LightningBolt").GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>();
				freeLightning.StartObject = gameObject;
				freeLightning.EndObject = target;
				target.GetComponent<IShockable>().BeShocked(shockDamage, numberOfBounces);
			}
		yield return null;
	}
	void ResetSpeed() {speed = tempSpeed;}

	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		
	}
}
