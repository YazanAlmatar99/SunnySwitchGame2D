//*****************************************************
//
// This class describes the Player's movement and animations
// as well as the Player's interactions with sunlight
// (death) and exits (advance to next level).
//
//******************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMovement : MonoBehaviour {

    public Animator animator;
	
	void Update () {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player makes contact with sunlight,
        // the player dies, the sound effect is played,
        // and the level is restarted along with its music.
        if (collision.CompareTag("sunlight"))
        {
            // Play death sound.
            AudioManager.Instance.PlaySoundEffect(6);
            SceneManager.LoadScene(Manager.currentScene);
            if (Manager.currentScene == 8) //Room 1
            {
                AudioManager.Instance.PlaySong(1); //Room 1 Music
            }
            else if (Manager.currentScene == 9) //Room 2
            {
                AudioManager.Instance.PlaySong(2); //Room 2 Music
            }
            else if (Manager.currentScene == 10) //Room 3
            {
                AudioManager.Instance.PlaySong(3); //Room 3 Music
            }
            else if (Manager.currentScene == 11) //Room 4
            {
                AudioManager.Instance.PlaySong(4); //Room 4 Music 
            }
        }

        // When the player makes contact with the exit, the sceneManager
        // loads the next scene along with its music.
        if (collision.CompareTag("exit"))
        {
            // currentScene is incremented and the new scene is loaded.
            Manager.currentScene++;
            SceneManager.LoadScene(Manager.currentScene);

            // Play the sound of the player exiting.
            AudioManager.Instance.PlaySoundEffect(1);

            if (Manager.currentScene == 8) //Room 1
            {
                AudioManager.Instance.PlaySong(1); //Room 1 Music
            }
            else if (Manager.currentScene == 9) //Room 2
            {
                AudioManager.Instance.PlaySong(2); //Room 2 Music
            }
            else if (Manager.currentScene == 10) //Room 3
            {
                AudioManager.Instance.PlaySong(3); //Room 3 Music
            }
            else if (Manager.currentScene == 11) //Room 4
            {
                AudioManager.Instance.PlaySong(4); //Room 4 Music 
            }
        }
    } // End OnTriggerEnter2D
}
