using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerScript : MonoBehaviour
{
    public Transform FollowTarget;
    public float followSpeed = 5;
    private Vector3 offset;
    void Start()
    {
        offset = FollowTarget.position - transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (FollowTarget)
        {
            transform.position = FollowTarget.position - offset;
        }
    }
}
