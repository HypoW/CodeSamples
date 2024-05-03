using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class FrameData
{
    private Hurtbox[] hurtboxes;
    private Hitbox[] hitboxes;
    int duration;
    public FrameData(Hurtbox[] _hurtboxes, Hitbox[] _hitboxes)
    {
        hurtboxes = _hurtboxes;
        hitboxes = _hitboxes;
    }
    public Hurtbox[] GetHurtboxes(Vector2 _position, bool _flipped)
    {
        foreach (Hurtbox i in hurtboxes)
        {
            i.SetParentPosition(_position);
            i.SetFlipped(_flipped);
        }
        return hurtboxes;
    }
    public Hitbox[] GetHitboxes(Vector2 _position, bool _flipped)
    {
        foreach (Hitbox i in hitboxes)
        {
            i.SetParentPosition(_position);
            i.SetFlipped(_flipped);
        }
        return hitboxes;
    }
    public void ResetHits()
    {
        foreach (Hitbox i in hitboxes)
        {
            i.GetHit().Reset();
        }
    }
    public bool HasConnected()
    {
        foreach (Hitbox i in hitboxes)
        {
            if (i.GetHit().Connected())
                return true;
        }
        return false;
    }
}
