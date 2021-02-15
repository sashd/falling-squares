using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Platform platform;

    [Tooltip("Направление при старте")]
    [Range(-1, 1)]
    public int direction = 1;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            direction *= -1;
        }

        if (Input.GetMouseButton(0))
        {

            platform.Move(direction);
        }
    }
}
