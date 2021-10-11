﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapFourStation : MonoBehaviour 
{
	[Header("Minerals")]
	public int requiredMinerals = 10;

	[Header("Activation Bools")]
	public bool active;
	public bool IsActive { get { return active; } }

	// Use this for initialization
	void Start () {
		active = false;
		ChangeTransparency (0.3f);
	}
	
	public void Activate () {
		active = true;
		ChangeTransparency (1.0f);
		
		if(gameObject.tag == "FourStation")
		{
			SceneManager.LoadScene("Game Over");
		}
	}

	void ChangeTransparency (float value) 
	{
		foreach (Renderer renderer in GetComponentsInChildren<Renderer>()) {
			foreach (Material material in renderer.materials) {
				// Set rendering mode.
				material.SetFloat ("_Mode", value < 1.0f ? 3 : 0);

				// Change color.
				Color currentColor = material.GetColor ("_Color");
				currentColor.a = value;
				material.SetColor("_Color", currentColor);

				// Rendering adjustments.
				material.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
				material.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
				material.SetInt ("_ZWrite", 0);
				material.DisableKeyword ("_ALPHATEST_ON");
				material.EnableKeyword ("_ALPHABLEND_ON");
				material.renderQueue = 3000;
			}
		}
	}
}
