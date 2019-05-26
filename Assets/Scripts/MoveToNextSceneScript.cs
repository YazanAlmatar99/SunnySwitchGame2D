using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    int currentScene;
    void Start()
    {
        //What if I want my object to persist throughout my game
        DontDestroyOnLoad(this);  //this is bad alone.
        currentScene = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Button presses!
        if (currentScene == 0 && Input.GetKeyDown(KeyCode.C))
        {
            //Move to the "Game" screen
            currentScene++;
            SceneManager.LoadScene(currentScene);
        } else if (currentScene == 1 && Input.GetKeyDown(KeyCode.A))
        {
            currentScene++;
            SceneManager.LoadScene(currentScene);
        } else if (currentScene == 2 && Input.GetKeyDown(KeyCode.T))
        {
            currentScene = 0;
            SceneManager.LoadScene(currentScene);
        }
    }
}
