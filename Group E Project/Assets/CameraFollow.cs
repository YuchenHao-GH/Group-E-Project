using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float speed = 2.0f;
    public Vector2 offset = new Vector2(0.5f, 0.5f);

    void FixedUpdate () {
        Vector3 targetPosition = target.position + new Vector3(offset.x, offset.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
