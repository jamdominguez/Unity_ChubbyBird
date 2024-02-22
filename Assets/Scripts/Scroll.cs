using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    private Rigidbody2D rigid;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {
        rigid.velocity = Vector2.left * GameController.instance.scrollSpeed;
    }

    // Update is called once per frame
    void Update() {
        if (GameController.instance.isGameOver) rigid.velocity = Vector2.zero;
    }

    private void FixedUpdate() {
        //rigid.MovePosition(new Vector2(transform.position.x - GameController.instance.scrollSpeed, transform.position.y));
    }
}
