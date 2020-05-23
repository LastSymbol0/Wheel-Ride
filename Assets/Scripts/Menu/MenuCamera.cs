using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    Quaternion startRot;

    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontalAxis;
        if (SlimUI.ModernMenu.MainMenuNew.inSettings)
        {
            horizontalAxis = transform.forward;
        }
        else
        {
            horizontalAxis = transform.right;
        }

        Vector3 mouseRelativePos = Input.mousePosition;

        mouseRelativePos.x /= Screen.width;
        mouseRelativePos.y /= Screen.height;

        mouseRelativePos.x -= 0.5f;
        mouseRelativePos.y -= 0.5f;

        UnityEngine.Debug.Log(mouseRelativePos);

        transform.rotation = startRot * Quaternion.Euler(transform.up * mouseRelativePos.x * -3);
        transform.rotation *= Quaternion.Euler(horizontalAxis * mouseRelativePos.y * -3);

        UnityEngine.Debug.Log(transform.rotation);
    }
}
