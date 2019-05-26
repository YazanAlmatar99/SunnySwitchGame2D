//******************************************************
//
// This class describes the Block object.
//
// There are two sets of blocks in each level: Those that
// begin on the level, and those that begin off the level.
//
// At first, all blocks start on the level,
// their position is recorded, and then
// the ones that are supposed to start
// off-level are immediately moved.
//
// The block has the ability to move once,
// either from on the level to off, or from
// off the level to the original recorded position on the level.
//*****************************************************


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    float xPosition; // x-value of the position of the block
    float yPosition; // y-value of the position of the block

    private void Awake()
    {
        // Store the positions of the block's "on level" positions.
        xPosition = transform.position.x;
        yPosition = transform.position.y;

        // If this block is not in the initial set of blocks for the
        // room (according to the level design), then
        // its x-axis is changed so it is off the level.
        if (!this.CompareTag("blockA"))
            moveOnce();
    }

    // The block is moved once.
    // If the block is on the level, it is moved off.
    // If the block is off the level, it is moved on.
    public void moveOnce()
    {
        // The block's current xPosition is compared to its
        // original "on level" xPosition to decide where the
        // block will move next.
        if (transform.position.x == xPosition)
            transform.position = new Vector2(10, transform.position.y);

        else
            transform.position = new Vector2(xPosition, transform.position.y);
    }
}
