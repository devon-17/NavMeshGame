using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{   

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

    public void SaveQuit()
    {
        PlayerPrefs.SetInt("LoadSaved", 1);
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
    }
    public void Quit(){
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
