using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tutorial(){
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Tutorial Level");
    }

    public void Quit(){
        Application.Quit();
        Debug.Log("Quit game");
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
}
