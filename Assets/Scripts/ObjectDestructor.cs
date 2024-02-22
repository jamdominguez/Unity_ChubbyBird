using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestructor : MonoBehaviour
{

    public string objectTag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(objectTag)) Destroy(other.gameObject);
    }
}
