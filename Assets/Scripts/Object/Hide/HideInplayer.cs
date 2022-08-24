using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInplayer : MonoBehaviour
{

   public bool InPlayer = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            InPlayer = true;
        }
    }
}
