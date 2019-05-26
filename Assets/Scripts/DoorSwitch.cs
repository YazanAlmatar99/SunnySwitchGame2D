//********************************************
//
// This class describes the DoorSwitch Object.
//
// It can only be activated once  by the player.
// Once activated, it moves the Door instance off
// of the level.
//********************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public Door[] door;         // Stores all door instances in a level.
    private bool wasPressed;

    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here

    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;
        wasPressed = false;
    }

    // If the player steps on a DoorSwitch that has not been
    // previously stepped on, the "moveOnce()" method
    // is called for all Door instances on the level.
    // The switch's sound effect is played and the
    // "stepped on" sprite replaces the switch's original sprite.
    // wasPressed will become true, and the next time this switch
    // is stepped on, nothing will happen.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!wasPressed)
            {
                for (int i = 0; i < door.Length; i++)
                    door[i].moveOnce();

                AudioManager.Instance.PlaySoundEffect(2);
                spriteRenderer.sprite = sprite2;
                wasPressed = true;
            }
        }
    }
}
