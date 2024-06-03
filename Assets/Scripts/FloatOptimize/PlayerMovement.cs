using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private float playerSpeed = 5.0f;
    Vector3 offset = new Vector3(20f, 0, 0f); // added a small offset to keep clone at a distance from the player
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(playerSpeed * Time.fixedDeltaTime * move);
         Vector3 offsetedPosition = transform.position + offset; 
        Vector3 compressedVector = PositionalDataCompressor.CompressData(offsetedPosition);
        NetworkManager.SetPositions(compressedVector.x, compressedVector.y, compressedVector.z);
    }
}
