using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator2 : MonoBehaviour {

    public Transform wallPrefab;
    public Transform pickupPrefab;
    
    public Queue<Transform> players = new Queue<Transform>();
    
    private int minPlatformSize = 2;
    private int maxPlatformSize = 6;
    
    private int minGapSize = 4;
    private int maxGapSize = 8;
    
    private float blockHeight = 0.32f;
    private float blockWidth = 0.32f;
    
    private float currentY;
    
    void Start() {
        currentY = 0;
    }
    
    void CreateRow (float y) {
        float maxX = 8;
        float x = -8;
        int gap = 0;
        int platform = 0;
        while (x < maxX) {
            if (platform > 0) {
                Instantiate(wallPrefab, new Vector3(x, currentY, 0), Quaternion.identity);
                platform--;
            } else if (Random.value < 0.2f) {
                gap = Random.Range(minGapSize, maxGapSize);
            } else if (gap > 0) {
                gap--;
            } else {
                Instantiate(wallPrefab, new Vector3(x, currentY, 0), Quaternion.identity);
                platform = Random.Range(minPlatformSize, maxPlatformSize);
                if (x > -6 && x < 6 && Random.value < 0.1f) {
                    Instantiate(pickupPrefab, new Vector3(x, currentY + blockHeight, 0), Quaternion.identity);
                } else if (x > -6 && x < 6 && Random.value < 0.1f) {
                    foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
                        if (player.transform.position.y > 100000) {
                            player.transform.position = new Vector3(x, currentY + (blockHeight * 2), 0);
                            break;
                        }
                    }
                }
            }
            x += blockWidth;
        }
    }
    
    
    public void Update() {
        if (currentY < Camera.main.transform.position.y + 7) {
            CreateRow(currentY);
            currentY += blockHeight * 5;
        }
    }
    
}