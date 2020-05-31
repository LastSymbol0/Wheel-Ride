using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraCntrl : MonoBehaviour
{
    Animator animator;
    //bool isInLevels = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.Log("Fatal error");
        }

        //isInLevels = animator.GetBool("InLevelsMenu");
    }

    void Update()
    {
        if (Input.GetKey("left"))
        {
            animator.SetBool("InLevelsMenu", false);
        }

        if (Input.GetKey("right"))
        {
            animator.SetBool("InLevelsMenu", true);
        }
    }
}
