using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeLeft;
    public Text secondsRemaining;

    void Start()
    {
        StartCoroutine(GameOverScreen());
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        secondsRemaining.text = "Seconds Remaining Until You Return to The Menu: " + Mathf.Round(timeLeft).ToString();
    }

    private IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(timeLeft);
        SceneManager.LoadScene("Menu");
    }
}
