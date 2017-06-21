using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameDiffBehaviour : MonoBehaviour {

	public RenderTexture renderTexture;

	private Color[] lastColors;

	// Use this for initialization
	void Start () {
	}

	private Vector4 toVector4(Color color)
	{
		return new Vector4 (color.a, color.r, color.g, color.b);
	}
	
	// Update is called once per frame
	void Update () {
		RenderTexture.active = renderTexture;
		Texture2D virtualPhoto = new Texture2D (renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
		virtualPhoto.ReadPixels (new Rect (0, 0, renderTexture.width, renderTexture.height), 0, 0);

		Color[] currentColors = virtualPhoto.GetPixels ();

		if (lastColors != null) {
			float variantColors = 0;

			for (int i = 0; i < renderTexture.width * renderTexture.height; ++i) {
				if (!lastColors [i].Equals (currentColors [i])) {
					variantColors += 1;
				}
			}

			print (variantColors / renderTexture.width / renderTexture.height);
		}

		lastColors = currentColors;
	}
}
