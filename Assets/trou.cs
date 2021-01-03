using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trou : MonoBehaviour
{
    public Animator EndGameAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EndGameAnimator.SetTrigger("END");
            
        }
    }
}
