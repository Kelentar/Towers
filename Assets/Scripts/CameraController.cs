using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Vector2 maxPos;
    public Vector2 minPos;

    private void FixedUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector2(minPos.x, maxPos.y), new Vector2(maxPos.x, maxPos.y));
        Gizmos.DrawLine(new Vector2(minPos.x, minPos.y), new Vector2(maxPos.x, minPos.y));
        Gizmos.DrawLine(new Vector2(minPos.x, maxPos.y), new Vector2(minPos.x, minPos.y));
        Gizmos.DrawLine(new Vector2(maxPos.x, maxPos.y), new Vector2(maxPos.x, minPos.y));
    }

}