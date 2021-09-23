using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour {

	public Player player;
	public GameCamera gameCamera;
	public Text mineralsText;
	public Text messageText;
	public GameObject station1;
	public GameObject rock;
	public GameObject satellitePad;
	public string startingText;
	private IEnumerator coroutine;
	public GameObject skyCam;

	// Use this for initialization
	void Start () {
		messageText.text = "";
		coroutine = TutorialRoutine();
		StartCoroutine (coroutine);
	}
	
	// Update is called once per frame
	void Update () {
		mineralsText.text = "Minerals: " + player.Minerals;

		if(Input.GetKey(KeyCode.G))
		{
			StopCoroutine(coroutine);
			gameCamera.target = player.gameObject;
			messageText.text = "";
			Debug.Log("Skip Cutscene");
		}

		if(Input.GetKeyDown(KeyCode.T))
		{
			gameCamera.target = skyCam.gameObject;
		}
		if(Input.GetKeyUp(KeyCode.T))
		{
			gameCamera.target = player.gameObject;
		}
	}

	private IEnumerator TutorialRoutine () {
		// starting text
		messageText.text = startingText;
		// first move
		yield return new WaitForSeconds (2.0f);
		gameCamera.target = station1;
		yield return new WaitForSeconds (2.0f);
		// second move
		gameCamera.target = satellitePad;
		messageText.text = "Add satellites to the Satellite Pad to Activate the Station by Clicking 'F'";
		yield return new WaitForSeconds(3.5f);
		// third move	
		messageText.text = "Get minerals from rocks!";
		gameCamera.target = rock;
		yield return new WaitForSeconds (3f);
		// fourth move
		messageText.text = "Hold 'T' for a World Map Camera!";
		gameCamera.target = skyCam;
		yield return new WaitForSeconds(2.5f);
		// back to player
		messageText.text = "Click 'G' to skip Tutorial Routine";
		gameCamera.target = player.gameObject;
		yield return new WaitForSeconds(2f);
		messageText.text = "";
	}
}
