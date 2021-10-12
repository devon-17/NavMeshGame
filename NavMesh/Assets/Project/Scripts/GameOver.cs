using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameOverScreen());
    }

    private IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Menu");
    }
}
