using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    public int delayTime;
    public int repeatTime;

    public GameObject obstacle;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("GenerateObstacle", delayTime, repeatTime);
    }

    void GenerateObstacle() {
        if (!GameController.instance.isGameOver) {
            float posY = Random.Range(-3f, 1.35f);
            Vector2 position = new Vector2(transform.position.x, posY);
            Instantiate(obstacle, position, Quaternion.identity);
        }
    }
}
