using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameSystem : MonoBehaviour
{
    public GameObject errorText;

    void Start()
    {
        errorText.SetActive(false);
    }

    public void LoadGame()
    {

        if(PlayerPrefs.GetInt("LoadSaved") == 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        } 
        else
        {
            StartCoroutine(ErrorPopUp());
            return;
        }
        
    }

    private IEnumerator ErrorPopUp(){
        errorText.SetActive(true);
        yield return new WaitForSeconds(2f);
        errorText.SetActive(false);
    }
}
