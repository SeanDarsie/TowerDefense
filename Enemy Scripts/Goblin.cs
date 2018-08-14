using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Creep {

	// Use this for initialization
	// void  Start () {
		
	// }
	
	// Update is called once per frame
	void Update () {

	}
	public override void getStunned()
	{
		
	}
	public override void takeDamage(int damage){}
	protected override void dieHorribly()
	{
		// TODO: show some effect that the goblin has died.
		// play a death sound as well
		Debug.Log("Goblin DieHorribly");
		playerStats.UpdateScore(rewardForKilling);
		creepManager.removeCreep(gameObject);

	}
	protected override void dieVictoriously()
	{
		// remove 1 life from the player. 
		creepManager.removeCreep(gameObject);
	}
}
