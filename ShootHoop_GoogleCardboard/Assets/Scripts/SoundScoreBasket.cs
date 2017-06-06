using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScoreBasket : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
