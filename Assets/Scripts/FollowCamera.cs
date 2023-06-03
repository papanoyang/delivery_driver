using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject thingToFollow;
    [SerializeField]
    float distance = 15.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = thingToFollow.transform.position + (new Vector3(0, 0, distance));
    }
}
