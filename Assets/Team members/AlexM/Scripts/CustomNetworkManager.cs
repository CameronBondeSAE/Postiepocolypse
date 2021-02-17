using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
   [Header(" ")]
   public Transform SpawnPosition;
   public override void OnServerAddPlayer(NetworkConnection conn)
   {
      Transform start = SpawnPosition;
      GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
      NetworkServer.AddPlayerForConnection(conn, player);
   }

   public override void OnServerDisconnect(NetworkConnection conn)
   {
      
   }
}
