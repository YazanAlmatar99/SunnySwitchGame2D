//**********************************************
//
// This class describes the Switch object.
//
// Switches can only be activated once by the
// player. Once activated, the switch calls the
// move() method of all blocks on the level.
//**********************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Block[] block;       // Store all block instances in a level.
    private bool wasPressed;    // Has this switch been pressed before?

    public Sprite sprite1; // Drag your first sprite here
    public Sprite sprite2; // Drag your second sprite here

    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite1;
        wasPressed = false;
    }

    // If the player steps on a switch that has not been
    // previously stepped on, the "moveOnce()" method
    // is called for all block instances on the level.
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
                for (int i = 0; i < block.Length; i++)
                    block[i].moveOnce();

                AudioManager.Instance.PlaySoundEffect(3);
                spriteRenderer.sprite = sprite2;
                wasPressed = true;
            }
        }
    }
}
