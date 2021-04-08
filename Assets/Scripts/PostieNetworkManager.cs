using Mirror;
using System;
using System.Collections.Generic;
using Tanks;
using UnityEngine;

public class PostieNetworkManager : NetworkManager
{
	public List<GameObject>         players;
	public event Action<GameObject> newPlayerEvent;
	public event Action<GameObject> playerDisconnectedEvent;
	
	public override void OnServerAddPlayer(NetworkConnection conn)
	{
		base.OnServerAddPlayer(conn);
		
		players.Add(conn.identity.gameObject);
		newPlayerEvent?.Invoke(conn.identity.gameObject);
	}

	public override void OnServerDisconnect(NetworkConnection conn)
	{
		base.OnServerDisconnect(conn);

		players.Remove(conn.identity.gameObject);
		playerDisconnectedEvent?.Invoke(conn.identity.gameObject);
	}
}
