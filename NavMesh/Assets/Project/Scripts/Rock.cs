using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
	public int minerals = 6;
	public float pulseScale = 0.1f;
	public float pulseDuration = 0.3f;
	public GameObject rockModel;
	public GameObject rockOreModel;

	private float pulseTimer;

	// Use this for initialization
	void Start () {
		rockModel.SetActive (false);
		rockOreModel.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		pulseTimer -= Time.deltaTime;

		float extraScale = pulseScale * Mathf.Max(pulseTimer / pulseDuration, 0);
		transform.localScale = new Vector3 (1 + extraScale, 1 + extraScale, 1 + extraScale);
	}

	public void Mine () {
		minerals--;
		pulseTimer = pulseDuration;
		if (minerals == 0) 
		{
			rockModel.SetActive (true);
			rockOreModel.SetActive (false);
		}
	}
}
