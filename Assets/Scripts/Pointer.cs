using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

    public int points;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            GameController.instance.AddPoints(points);
            GetComponent<AudioSource>().Play();
        }
    }
}
