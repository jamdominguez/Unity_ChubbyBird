using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float force;

    private Rigidbody2D rigid;
    private Animator animator;
    private bool isDead;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (!isDead && Input.GetMouseButtonDown(0)) {
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.up * force);
            animator.SetTrigger("Flap");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isDead = true;
        animator.SetTrigger("Die");
        rigid.velocity = Vector2.zero;
        GameController.instance.ShowGameOver();
    }

}
