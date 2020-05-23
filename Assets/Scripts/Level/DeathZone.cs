using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LevelController.Score = -1;
        UnityEngine.Debug.Log("Death");
    }
}
