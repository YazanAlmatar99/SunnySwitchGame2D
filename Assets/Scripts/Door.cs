//************************************
//
// This class describes the Door object.
//
// The Door object covers the exit of a
// level.
// Once the DoorSwitch is pressed, the
// door is moved off of the level.
//************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    float xPosition;
    float yPosition;

    private void Awake()
    {
        // The original x and y positions of the
        // door are recorded.
        xPosition = transform.position.x;
        yPosition = transform.position.y;
    }

    // Moves the door/inactiveExit off of the level.
    public void moveOnce()
    {
        // The x-value of the position is changed to a value
        // that would move the door completely off of the level.
        transform.position = new Vector2(10, transform.position.y);
    }
}
