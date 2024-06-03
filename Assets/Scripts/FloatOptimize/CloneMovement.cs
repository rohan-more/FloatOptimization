using System;
using UnityEngine;

public class CloneMovement : MonoBehaviour
{
    private float x_coord, y_coord, z_coord;

    private void OnEnable()
    {
        Events.Set_X += SetXPosition;
        Events.Set_Y += SetYPosition;
        Events.Set_Z += SetZPosition;
    }

    private void OnDisable()
    {
        Events.Set_X -= SetXPosition;
        Events.Set_Y -= SetYPosition;
        Events.Set_Z -= SetZPosition;
    }

    /// <summary>
    /// Simulates values sent over the network, only updates when corresponding coordinate value changes for the actual player
    /// </summary>
    /// <param name="value"></param>
    private void SetXPosition(float value)
    {
        x_coord = value; 
    }

    private void SetYPosition(float value)
    {
        y_coord = value;
    }

    private void SetZPosition(float value)
    {
        z_coord = value;
    }

    void FixedUpdate()
    {
        MoveClonePlayer();
    }

    private void MoveClonePlayer()
    {
        Vector3 relativePositionVector = new Vector3(x_coord, y_coord, z_coord);
        transform.position = Vector3.Lerp(relativePositionVector, transform.position, 2 * Time.fixedDeltaTime);
        Debug.Log("Position: " + relativePositionVector + " - Bits sent " + NetworkManager.NumBits);
    }
}
