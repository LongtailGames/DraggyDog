using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnImpace : MonoBehaviour
{
    private IPlayer player;
    [SerializeField] private float fallSpeedThreshold;

    private void Awake()
    {
        player = GetComponent<IPlayer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude>fallSpeedThreshold)
        {
            player.Undead();
        }
    }
}
