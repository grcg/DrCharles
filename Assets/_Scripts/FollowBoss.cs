using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoss : MonoBehaviour {
    public Vector3 offset;          // The offset at which the Health Bar follows the player.

    private Transform boss;       // Reference to the boss.


    void Awake()
    {
        // Setting up the reference.
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
    }

    void Update()
    {
        // Set the position to the player's position with the offset.
        transform.position = boss.position + offset;
    }
}

