using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string URL = "https://github.com/B00155567/EatMan";
    
    public void PlayGame() {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadUrl() {

        Application.OpenURL(URL);
    }
    public void ExitGame() {
        
        Debug.Log("Exiting Game!");
        Application.Quit();
    }

}
