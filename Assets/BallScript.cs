using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static float Speed;
    int XVel;
    int YVel;
    Rigidbody2D TheRB;
    Transform TheT;
    [SerializeField] GameRunner GRunner;
    bool dead = false;
    [SerializeField] GameObject PSys;
    
    void Start()
    {
        Speed = 3;
        TheRB = gameObject.GetComponent<Rigidbody2D>();
        TheRB.velocity = new Vector2(1*Speed,1*Speed);
        TheT = gameObject.GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (TheRB.velocity.x >= 0)
        {
            XVel = 1;
        }
        else
        {
            XVel = -1;
        }
        if (TheRB.velocity.y >= 0)
        {
            YVel = 1;
        }
        else
        {
            YVel = -1;
        }
        TheRB.velocity = new Vector2(XVel * Speed, YVel * Speed);
        Speed = 6.5f - GRunner.BricksLeft * 0.1f + GRunner.Wins;
        if (TheT.position.y <= -1)
        {
            if (dead == false)
            {
                DeathParticle();
                GRunner.MoveUpText();
            }
            dead = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GRunner.ResetBall();
                dead = false;
                TheRB.velocity = new Vector2(1 * Speed, 1 * Speed);
                TheT.position = new Vector2(0, 3);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BrickScript>() != null)
        {
            Destroy(collision.gameObject);
            GRunner.BreakBrick();
        }
        if (collision.gameObject.GetComponent<PaddleControls>() != null)
        {
            if (GRunner.RestartPrimed == true)
            {
                GRunner.RestartPrimed = false;
                GRunner.StartGame();
            }
        }
    }
    void DeathParticle()
    {
        PSys.GetComponent<Transform>().position = new Vector2(TheT.position.x, -1);
        PSys.GetComponent<ParticleSystem>().Play();
    }
}
