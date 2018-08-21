using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Creep, IHittable, IStunnable, INettable
{	
	// Update is called once per frame
	void Update () {
		moveToNextSpot();
	}
	public void GetStunned(float seconds)
	{
		// TODO: play a stunned animation. and sound!
		if (speed == 0)
			CancelInvoke(); 
		else
			tempSpeed = speed;
		speed = 0;
		// stop for seconds and 
	}
	float tempSpeed;
	public void BeNetted()
	{
		if (speed == 0)
			CancelInvoke(); 
		else
			tempSpeed = speed;
		speed = 0;
		Invoke("ResetSpeed", 2.0f);
	}
	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
			dieHorribly();
	}
	protected override void dieHorribly()
	{
		// TODO: show some effect that the goblin has died.
		// play a death sound as well
		playerStats.UpdateScore(rewardForKilling);
		playerStats.AdjustMonies(moneyForKilling);
		creepManager.removeCreep(gameObject);
	}
	// protected override void dieVictoriously()
	// {
	// 	// remove 1 life from the player. 
	// 	creepManager.removeCreep(gameObject);
	// 	playerStats.AdjustHealth(-damage);
	// }
	void ResetSpeed() {speed = tempSpeed;}
}
