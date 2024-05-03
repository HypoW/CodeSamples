using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour //Entity
{
    private Transform transform;
    int angle = 90;
    int stagewidth = 30;
    Vector2 velocity = new Vector2(0f, 80f);
    private SpriteRenderer spriteRenderer;
    private GameObject parentObject { get; }
    private Vector2 movement;

    //World variables 
    //Might want to consider referencing these from another file since they apply to all objects
    private static Vector2 gravity = new Vector2(0, -8.0f);
    private static float groundHeight = 2.0f;
    private static float speed = 0.015f; //0.003f

    public enum PROJECTILE { CARD, CARDDIAGONAL, PAPER }
    public PROJECTILE projectileType;
    private bool flip;

    public void Initialize()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Destroy()
    {
        Debug.Log(transform.gameObject.name);
        Destroy(transform.gameObject);
    }
    public bool ManualUpdate()
    {
        movement = velocity * speed;
        transform.Translate(movement);
        if(transform.position.x > stagewidth || transform.position.x < -stagewidth)
        {
            return true;
        }
        return false;
    }
    public bool Flipped()
    {
        return flip;
    }
    public void Flip()
    {
        flip = !flip;
        /*transform.localScale = new Vector3(
          transform.localScale.x * -1,
          transform.localScale.y,
          transform.localScale.z);*/
        spriteRenderer.flipX = flip;
    }
    public string GetCurrentFrame()//temporary conversion from frame and animation to string identifier.
    {
        switch (projectileType)
        {
            case PROJECTILE.CARD: return "Card";
            default: return "";
        }
    }
}
