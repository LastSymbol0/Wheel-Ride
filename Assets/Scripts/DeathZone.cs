using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScoreCounter.Score = -1;
        UnityEngine.Debug.Log("Death");
    }
}
