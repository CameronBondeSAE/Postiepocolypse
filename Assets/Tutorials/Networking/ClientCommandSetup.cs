using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientCommandSetup : MonoBehaviour
{

	
	
	// Run on client only. Client->Server
	// The client wants to do something where ALL OTHER CLIENTS should see it. They need to ask the server for permission
	[Command]
	public void CmdMyCommand(float fakeValueToSend)
	{
		RpcMyFunctionToRunOnClients(fakeValueToSend);
	}

	// Runs on each client FROM the server. Server->ALL clients
	// If a client asks the server to do something, then you'll need all the other ghost clients to show that action was performed
	[ClientRpc]
	public void RpcMyFunctionToRunOnClients(float fakeValueToSend)
	{
		
	}
}
