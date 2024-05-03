using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : MonoBehaviour //Dummy Behavior. Reacts to some limited info fed in from playerController
{
    private playerAction player;
    private enum BlockAction { NEVER, AFTERHIT, ALWAYS };
    BlockAction blockAction = BlockAction.AFTERHIT;
    bool wasHit = false;
    private float hitTimer = 0f;
    bool jump = false;

    void Start()
    {
        player = GetComponent<playerAction>();
    }
    void Update()
    {
        if (hitTimer > 0)
        {
            hitTimer--;
        }
        else
        {
            ResetHitStatus();
        }
        if(jump)
        {
            player.SetStick(playerAction.StickPosition.UP);
        }
    }
    public bool HandleBlock(Hit _connect)//returns true if the dummy wants to block
    {
        if (blockAction == BlockAction.ALWAYS || (blockAction == BlockAction.AFTERHIT && WasHit()))//(currentAnimation == AnimationState.WALKBACK)//Blocked //might want to read player input instead (and compare against hittype)
        {
            return true;
            Hit(_connect.GetBlockstun());
        }
        else
        {
            return false;
            Hit(_connect.GetHitstun());
        }
    }
    private bool WasHit()
    {
        return wasHit;
    }
    private void Hit(int stun)
    {
        wasHit = true;
        hitTimer = stun*25;       
    }
    private void ResetHitStatus()
    {
        wasHit = false;
    }
}
