using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    
    private float speed = 0;//0.7f;
    private Vector3 startMarker;
    private Vector3 endMarker;
    private float startTime;
    private float journeyLength;

    public void Start() {
        startMarker = transform.position;
        endMarker = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, endMarker);
    }

    public void Update() {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
    }

}
