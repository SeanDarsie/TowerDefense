using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrerTower : Tower {
    protected ArrerTower() // constructor
    {
		
	}
	void Update () {
		if (netSelected)
		{
			line = GetComponent<LineRenderer>();

				// RaycastHit hit;
                
                // if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				// 	pos = hit.point;
				// 	pos.y = 5.0f;
				// 	line.SetPosition(0, pos.normalized * 5.0f);
                // }
		
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000))
			{
				// netThrowDir = hit.point - transform.position;
				netThrowDir = hit.point;
				Debug.Log(hit.point);
				// netThrowDir = transform.position - Input.mousePosition; // points from tower to mouse
				netThrowDir.y = transform.position.y;

				// RaycastHit hit;

				line.SetPosition(0, transform.position);
				line.SetPosition(1, netThrowDir/*hit.point*/);
			}
			// draw a line from the tower to the mouse.
			if (Input.GetMouseButtonDown(0))
				throwNet();
		}	
	}
	

    public override void Fire()
    {
        throw new System.NotImplementedException();
    }

    public override void Sell()
    {
        throw new System.NotImplementedException();
    }

    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
	
	// scatter arrow section
	// [Header("scatter ability")]
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
	public void scatterArrow() // list or array. doesn't matter to me atm.
    {
		List<GameObject> creeps = creepManager.getActiveCreeps();
        // deal damage to all creeps within tower range.
        foreach (GameObject x in creeps)
        {
			creepDist = Vector3.Distance(transform.position, x.gameObject.transform.position);
			if (creepDist <= range)
			{
				x.GetComponent<Creep>().takeDamage(scatterDamage);
			}
        }
    }
    // throw net section
    // [Header("Net Ability Settings")]
    [HideInInspector]
	public bool netSelected;
	private LineRenderer line;
	public float netRange;
	public float netCD;
	public GameObject netObject;
	public Transform throwPos;
	Vector3 netThrowDir = new Vector3();
	public void throwNet() // simply needs to throw the net in the netThrowDir 
	{
		// direction is from tower position to mouse pointer. 
		netSelected = false;
		//Quaternion shoot = new Quaternion(0, throwPos.rotation.y, 0, throwPos.rotation.w);
		GameObject throwthis = Instantiate(netObject, throwPos.position, throwPos.rotation);
		
		throwthis.GetComponent<Rigidbody>().AddRelativeForce(0,0,500);
		deactivateNetIndicator();
	}

	public void activateNetIndicator()
	{
		netSelected = true;
		line = GetComponent<LineRenderer>();
	}
	public void deactivateNetIndicator() 
	{
		netSelected = false;
		line.SetPosition(1, transform.position);
	}
    // Use this for initialization
    void Start () {
			
	}

}
	// public float damage;
	// public float range;
	// public int level;
	// public int price;
	// public int upgradePrice;
	// public int sellPrice;