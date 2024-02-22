using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour {

    private float initialPosition;

    private float colliderLength;

    private void Awake() {
    }

    // Start is called before the first frame update
    void Start() {
        colliderLength = GetComponent<BoxCollider2D>().size.x;
        initialPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update() {
        bool isNecessaryMove = transform.position.x <= initialPosition - colliderLength;
        if (isNecessaryMove) Move();
    }

    private void Move() {
        transform.Translate(Vector2.right * colliderLength);
        initialPosition = transform.position.x;
    }
}
