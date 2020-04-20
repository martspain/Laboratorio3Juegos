using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject player;
    private Vector3 distVec;

    // Start is called before the first frame update
    void Start()
    {
        if (player)
            distVec = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
            transform.position = player.transform.position - distVec;
    }
}
