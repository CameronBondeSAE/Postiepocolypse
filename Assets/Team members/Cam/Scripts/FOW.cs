using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOW : MonoBehaviour
{
	public Camera       cam;
	public Texture2D    tex;
	public Renderer     rend;
	public MeshCollider meshCollider;

	void Start()
	{
		// cam = GetComponent<Camera>();

		tex            = new Texture2D(1024, 1024, TextureFormat.RGB24, false);
		tex.filterMode = FilterMode.Point; // Removes blurring

		
		Debug.Log("tex.isReadable = "+tex.isReadable);
		rend           = transform.GetComponent<Renderer>();
		// meshCollider                       = collider as MeshCollider;
		rend.material.mainTexture = tex;
	}

	void Update()
	{
		// if (!Input.GetMouseButton(0))
			// return;

		// RaycastHit hit;
		// if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
			// return;

		
		// if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
			// return;

		// Texture2D tex     = rend.material.mainTexture as Texture2D;
		// Vector2   pixelUV = hit.textureCoord;
		// pixelUV.x *= tex.width;
		// pixelUV.y *= tex.height;

		// tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);

		tex.SetPixel(Random.Range(0,tex.width), Random.Range(0,tex.height), Color.black);
		tex.Apply(false);
	}
}

public static class Tex2DExtension
{
	public static Texture2D Circle(this Texture2D tex, int x, int y, int r, Color color)
	{
		float rSquared = r * r;

		for (int u=0; u<tex.width; u++) {
			for (int v=0; v<tex.height; v++) {
				if ((x-u)*(x-u) + (y-v)*(y-v) < rSquared) tex.SetPixel(u, v, color);
			}
		}

		return tex;
	}
}