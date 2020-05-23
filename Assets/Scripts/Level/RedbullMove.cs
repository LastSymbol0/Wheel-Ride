using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RedbullMove : MonoBehaviour
{
    private bool isCollected = false;

    void Update()
    {
        if (!isCollected)
        {
            transform.Rotate(0, 1, 0, Space.Self);
            if (transform.rotation.eulerAngles.y > 180)
            {
                transform.Translate(transform.up * 0.005f);
            }
            else
            {
                transform.Translate(-transform.up * 0.005f);
            }
        }
        else
        {
            transform.Translate(transform.up * 0.05f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected)
            LevelController.Score++;
        GetComponent<Rigidbody>().AddForce(transform.up, ForceMode.Acceleration);
        isCollected = true;
        UnityEngine.Debug.Log(LevelController.Score);
    }
}
