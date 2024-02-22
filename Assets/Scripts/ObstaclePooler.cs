using UnityEngine;

public class ObstaclePooler : MonoBehaviour {

    public GameObject obstacle;
    public float poolXPos;
    public float spawnXPos;
    public float spawnYPosMin;
    public float spawnYPosMax;
    public float spawnRateTime;
    public int poolSize;


    private GameObject[] obstaclesPool;
    private float lastSpawnTime;
    private int currentObstaclePos = 0;

    // Start is called before the first frame update
    void Start() {
        obstaclesPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++) {
            obstaclesPool[i] = Instantiate(obstacle, new Vector2(poolXPos, 0), Quaternion.identity);
        }
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update() {
        lastSpawnTime += Time.deltaTime;
        if (!GameController.instance.isGameOver && lastSpawnTime >= spawnRateTime) {
            lastSpawnTime = 0;
            SpawnObstacle();
        }
    }

    void SpawnObstacle() {
        float spawnYPos = Random.Range(spawnYPosMin, spawnYPosMax);
        if (currentObstaclePos == poolSize) currentObstaclePos = 0; //reset index
        obstaclesPool[currentObstaclePos++].transform.position = new Vector2(spawnXPos, spawnYPos);
    }
}
