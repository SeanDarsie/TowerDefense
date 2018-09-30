using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoisonable {
	void BePoisoned(int poisonDamage, int poisonTicks);
}
