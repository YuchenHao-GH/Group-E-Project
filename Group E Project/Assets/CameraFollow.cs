using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float followSpeed = 20.0f;

    public Vector2 followOffset = new Vector2(0.5f, 0.5f);

    private IEnumerator FollowTarget()
    {
        while (true)
        {
            Vector3 targetPosition = target.position + new Vector3(followOffset.x, followOffset.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.fixedDeltaTime);

            yield return new WaitForFixedUpdate();
        }
    }

    void Start()
    {
        StartCoroutine(FollowTarget());
    }

    public void Test()
    {
        target = null;
    }
}
