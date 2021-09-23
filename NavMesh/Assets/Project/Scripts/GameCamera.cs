using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

	public GameObject target;
	public Vector3 offset;
	public float smoothness = 5f;

	public Transform playerTarget;
    public float degrees;

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			targetPosition = target.transform.position + offset;
			transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smoothness);
		}

		if (Input.GetMouseButton (1)) 
        {    
         
         	transform.RotateAround (playerTarget.position, Vector3.up, Input.GetAxis ("Mouse X")* degrees);
            //transform.RotateAround (target.position, Vector3.left, Input.GetAxis ("Mouse Y")* dragSpeed);
        }

	}
}
