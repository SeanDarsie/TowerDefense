using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrerTower : Tower {
    protected ArrerTower() // constructor
    {
		
	}

	private float netCooldown;
	void Update () {
		if (netSelected)
		{
			// line = GetComponent<LineRenderer>();

			// 	// RaycastHit hit;
                
            //     // if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
			// 	// 	pos = hit.point;
			// 	// 	pos.y = 5.0f;
			// 	// 	line.SetPosition(0, pos.normalized * 5.0f);
            //     // }
		
			// RaycastHit hit;
			// if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000))
			// {
			// 	// netThrowDir = hit.poinst - transform.position;
			// 	netThrowDir = hit.point;
			// 	// netThrowDir = transform.position - Input.mousePosition; // points from tower to mouse
			// 	netThrowDir.y = transform.position.y;

			// 	// RaycastHit hit;

			// 	line.SetPosition(1, netThrowDir/*hit.point*/);
			// 	line.SetPosition(0, transform.position);
			// }
			// // draw a line from the tower to the mouse.
			if (Input.GetMouseButtonDown(0))
				throwNet();
			if (Input.GetMouseButtonDown(1))
				deactivateNetIndicator();
		}
		if (Time.time >= shotCD)
		{
			Fire();
		}
	}
	[Header("Basic Attack")]
	private float shotCD;

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
		shotCD = Time.time + reloadSpeed;
        // throw new System.NotImplementedException();
    }	
	// scatter arrow section
	[Header("Scatter Ability")]
	[HideInInspector]
	bool scatterSelected; // for ui and indicator purposes. 
	public int scatterDamage;
	public float scatterRadius;
	public float scatterCD;
	private float creepDist;
	public void upgradeScatterArrowAbility()
	{
		scatterDamage++; // increase scatter damage.
		scatterRadius++; // increase radius ??
		scatterCD--; // reduce CD
	}
	// void /// <summary>
	// /// Callback to draw gizmos that are pickable and always drawn.
	// /// </summary>
	public Color color;
	void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawSphere(transform.position, range);
	}
	public void scatterArrow() // list or array. doesn't matter to me atm.
    {
		List<GameObject> creeps = creepManager.getActiveCreeps();
        // deal damage to all creeps within tower range.
		// Debug.Log("Creeps   " + creeps[0].name);
		int something = 0;
        foreach (GameObject x in creeps)
        {
			// Debug.Log("foreach loop ScatterArrow " + something);
			creepDist = Vector3.Distance(transform.position, x.gameObject.transform.position);
			if (creepDist <= scatterRadius && x.activeInHierarchy)
			{
				IHittable badGuy = x.GetComponent<IHittable>();
				if (badGuy != null)
					badGuy.TakeDamage(scatterDamage);
			}
			something++;
        }
		something = 0;
    }
    // throw net section
    [Header("Net Ability Settings")]
    [HideInInspector]
	[SerializeField] bool netSelected = false;
	private LineRenderer line;
	[SerializeField] float netRange;
	[SerializeField] float netCD;
	[SerializeField] GameObject netObject;
	[SerializeField] Transform throwPos;
	[SerializeField] float forceOfThrow;
	Vector3 netThrowDir = new Vector3();
	[SerializeField] GameObject netIndicator;
	public void throwNet() // simply needs to throw the net in the netThrowDir 
	{
		shotCooldown = Time.time + shotCD;
		// direction is from tower position to mouse pointer. 
		netSelected = false;
		//Quaternion shoot = new Quaternion(0, throwPos.rotation.y, 0, throwPos.rotation.w);
		GameObject throwthis = Instantiate(netObject, netIndicator.transform.position, netIndicator.transform.rotation);
		
		throwthis.GetComponent<Rigidbody>().AddRelativeForce(0,0,forceOfThrow);
		deactivateNetIndicator();
	}

	private float shotCooldown;
	public void activateNetIndicator()
	{
		if (Time.time < shotCooldown)
			return;
		netSelected = true;
		netIndicator.SetActive(true);
		// line = GetComponent<LineRenderer>();
	}
	public void deactivateNetIndicator() 
	{
		netIndicator.SetActive(false);
		netSelected = false;
		// line.SetPosition(1, transform.position);
	}
    // Use this for initialization
    // void Start () {
			
	// }

}
	// public float damage;
	// public float range;
	// public int level;
	// public int price;
	// public int upgradePrice;
	// public int sellPrice;