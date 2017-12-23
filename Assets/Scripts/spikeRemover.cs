using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeRemover : MonoBehaviour {



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }

    }
}
