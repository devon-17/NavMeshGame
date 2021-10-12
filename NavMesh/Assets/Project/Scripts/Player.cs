using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour 
{
	[Header("Mining")]
	public float miningDuration = 0.5f;

	[Header("Audio")]
	public AudioSource moveSound;
	public AudioSource mineSound;
	public AudioSource activateSound;

	private NavMeshAgent agent;
	private float miningTimer;
	private int minerals;
	public int Minerals { get { return minerals; } }

	[Header("Satellite Instantiate Stats")]
	public GameObject satellite;
	public int satelliteNeeded;
	public int satelliteMineralsNeeded;

	[Header("Portal Instantiate Stats")]
	public GameObject portal;
	public int portalNeeded;
	public int portalMineralsNeded;

	

	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				agent.SetDestination (hit.point);
				moveSound.Play ();
			}
		}

		// Make the mining timer work.
		miningTimer -= Time.deltaTime;  


		
		
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.GetComponent<Station> () != null) 
		{
				Station station = other.gameObject.GetComponent<Station> ();

			if (!station.IsActive && minerals >= station.requiredMinerals && satelliteNeeded <= 0 && portalNeeded <= 0) 
			{
				minerals -= station.requiredMinerals;
				station.Activate ();

				activateSound.Play ();
			}
		}

		/*
		if (otherCollider.gameObject.GetComponent<Station> () != null) {
			Station station = otherCollider.gameObject.GetComponent<Station> ();

			if (!station.IsActive && minerals >= station.requiredMinerals) {
				minerals -= station.requiredMinerals;
				station.Activate ();

				activateSound.Play ();
			}
		}
		*/


		

		if (other.tag == "Pad")
		{
			// satellite instantiate
		if(minerals >= satelliteMineralsNeeded) // if we have more minerals than needed for satellites
		{
			if (Input.GetKeyDown(KeyCode.F) && satelliteNeeded != 0) // if f clicked and minerals needed is more than 0
			{
				Instantiate(satellite, transform.position, Quaternion.identity); // instantiating satellite at the players position
				satelliteNeeded --;
				minerals -= satelliteMineralsNeeded;
				
				if(satelliteNeeded <= 0)
				{
					satelliteNeeded = 0;
				}
			}
		}

		// portal instantiate
		if(minerals >= portalMineralsNeded)
		{
			if (Input.GetKeyDown(KeyCode.E) && portalNeeded != 0 && satelliteNeeded <= 0)
			{
				Instantiate(portal, transform.position, Quaternion.identity);
				portalNeeded --;
				minerals -= portalMineralsNeded;

				if (portalNeeded <= 0)
				{
					portalNeeded = 0;
				}
			}
		}
		}

	}

	void OnTriggerStay (Collider otherCollider) {
		if (otherCollider.gameObject.GetComponent<Rock> () != null) {
			Rock rock = otherCollider.gameObject.GetComponent<Rock> ();

			if (miningTimer <= 0 && rock.minerals > 0) {
				miningTimer = miningDuration;

				minerals++;

				rock.Mine ();

				mineSound.Play ();
			}
		}
	}
}
