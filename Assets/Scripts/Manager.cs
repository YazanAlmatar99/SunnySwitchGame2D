//**************************************
//
// This class describes the Manager object.
//
// This object traverses through the scenes
// of the game as the player progresses.
//
// For the title, intro, and ending scenes,
// pressing 'Z' will advance the player to
// the next scene.
//
// For the in-game scenes, only traveling
// through the exit will advance the player
// to the next scene.
//**************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public static int currentScene;
    private static Manager _instance;
    
    public static Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Manager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        // If this doesn't exist yet.
        if (_instance == null)
        {
            // Set instance to this.
            _instance = this;
        }
        // If instance already exists and it's not this:
        else if (_instance != null && _instance != this)
            //Then destroy this. This enforces the singleton pattern, meaning there can only ever be one instance of a Manager.
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);        
    }

    // Initialization
    void Start () {
        currentScene = 0;
        AudioManager.Instance.PlaySong(0);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H)) //Room 1 Debug
        {
            currentScene = 8;
            AudioManager.Instance.PlaySong(1); //Room 1 Music
        }
        if (Input.GetKeyDown(KeyCode.I)) //Room 2 Debug
        {
            currentScene = 9;
            AudioManager.Instance.PlaySong(2); //Room 2 Music
        }
        if (Input.GetKeyDown(KeyCode.J)) //Room 3 Debug
        {
            currentScene = 10;
            AudioManager.Instance.PlaySong(3); //Room 3 Music
        }
        if (Input.GetKeyDown(KeyCode.K)) //Room 4 Debug
        {
            currentScene = 11;
            AudioManager.Instance.PlaySong(4); //Room 4 Music
        }

        if (currentScene == 12)
        {
            AudioManager.Instance.PlaySong(5);
        } 

        // If the current scene is one of the IN-GAME levels, pressing 'Z' restarts
        // the level.
        // If the current scene is an intro, title, or ending scene, pressing 'Z' brings
        // you to the next scene.
        // If the current scene is the final scene, pressing 'Z' brings you to the title
        // scene.
        if (Input.GetKeyDown(KeyCode.Z))
        {   
            //Intro
            if (currentScene <= 7)
            {
                currentScene++;
                SceneManager.LoadScene(currentScene);
                AudioManager.Instance.PlaySoundEffect(4);

                if (currentScene == 8)
                {
                    AudioManager.Instance.PlaySong(1);
                }
            }

             // If the current scene is the last scene of the game, go to title screen.
            else if (currentScene >= 14)
            {
                currentScene = 0;
                SceneManager.LoadScene(currentScene);
                AudioManager.Instance.PlaySong(0);
            }

            //If the current scene is a Room
            else if (currentScene <= 11 && currentScene >= 8)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
            //End frames
            else if (currentScene >= 12)
            {
                
                if (currentScene == 13)
                {
                    AudioManager.Instance.PlaySoundEffect(0);
                }

                AudioManager.Instance.PlaySong(5);
                currentScene++;
                SceneManager.LoadScene(currentScene);

            }
        } // End if Input.GetKeyDown
    } // End Update.
}