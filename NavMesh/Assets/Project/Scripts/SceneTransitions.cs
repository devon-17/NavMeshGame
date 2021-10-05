using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{  

    [SerializeField] GameObject errorText;
    
    void Start(){
        errorText.SetActive(false);
    }

    public void Tutorial(){
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Tutorial Level");
    }

    public void Menu(){
        SceneManager.LoadScene("Menu");
    }

    public void MapOne(){
        SceneManager.LoadScene("MapOne");
    }

    public void MapTwo(){
        SceneManager.LoadScene("MapTwo");
    }
    public void MapThree(){
        SceneManager.LoadScene("MapThree");
    }

    public void MapFour(){
        SceneManager.LoadScene("MapFour");
    }

    public void SaveQuit(){
        PlayerPrefs.SetInt("LoadSaved", 1);
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
    }
    public void Quit(){
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void LoadGame(){

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
