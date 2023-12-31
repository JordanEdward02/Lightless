using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDash :  Dash
{
    public float dashDistance = 4f;
    public float dashDuration = 0.3f;
    public float dashCooldown = 1.5f;

    private PlayerController player;
    
    private float lastDash;

    public BasicDash(PlayerController p)
    {
        this.player = p;
        lastDash = Time.time-dashCooldown;
    }

    public void dash()
    {
        if (lastDash + dashCooldown < Time.time)
        {
            player.CallableImmobolize(dashDuration);
            player.mainRigidbody.AddForce(player.playerTransform.forward * dashDistance * 300);
            lastDash = Time.time;
        }
    }
}
