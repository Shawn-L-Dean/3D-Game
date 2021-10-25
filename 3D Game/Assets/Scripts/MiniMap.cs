using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 newPos = player.position; //Records position of the player.
        newPos.y = transform.position.y; //Resets camera y
        transform.position = newPos; //Moves camera to new position.

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f); //Rotates camera based on players rotation.

    }
}
