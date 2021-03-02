using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerView : NetworkBehaviour
{
	public TextMeshProUGUI textMesh;
	public ScoreManager    ScoreManager;

	public override void OnStartServer()
	{
		base.OnStartServer();
		
		if (isServer)
		{
			ScoreManager.UpdateScoreEvent += RpcUpdateScore;
		}
	}

	void OnEnable()
	{
	}

	void OnDisable()
	{
		// if (isServer)
		{
			ScoreManager.UpdateScoreEvent -= RpcUpdateScore;
		}
	}

	[ClientRpc]
	public void RpcUpdateScore(int score)
	{
		textMesh.text = score.ToString();
	}
}
