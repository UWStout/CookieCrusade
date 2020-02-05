﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;
    [SerializeField]
    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.position.x, player.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, playerPos, .7f);
    }
}