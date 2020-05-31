using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RedbullMove : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public static uint cansCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            ScoreCounter.Score++;
        GetComponent<Rigidbody>().AddForce(transform.up, ForceMode.Acceleration);
        isCollected = true;
        UnityEngine.Debug.Log(cansCollected);
    }

    private bool isCollected = false;
}
