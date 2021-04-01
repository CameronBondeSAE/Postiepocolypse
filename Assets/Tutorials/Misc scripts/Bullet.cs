using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IPoolObject
{
	void Reset();
}


// public class Monitor : ComputerPeripheral, IHDMI, IVGA, IDisplayPort, IComposite
// {
	
// }

public class Bullet : MonoBehaviour, IPoolObject
{
	public TextMeshProUGUI TextMeshProUGUI;
	
	public void Reset()
	{
		
		
		// stop soundfx
		// stop smoke
		// stop animation
	}
}

public class CamsMonster : CreatureBase, IPoolObject
{
	public void Reset()
	{
		// stop growl sound
		// 
	}
}


