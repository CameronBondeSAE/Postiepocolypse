using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class PostieNetworkManager : NetworkManager
{
	public List<GameObject> players;
	
	public override void OnServerAddPlayer(NetworkConnection conn)
	{
		base.OnServerAddPlayer(conn);
		
		players.Add(conn.identity.gameObject);
	}
}
