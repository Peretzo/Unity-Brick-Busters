using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxHorizontalSpeed;
    public float verSpeed;
    public bool ballActive;
    public Transform startPoint;
    private GameManager theGM;
    private Rigidbody2D theRB;
    public AudioSource ballBounce, ballDead, brickHit;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        //  theRB.velocity = new Vector2(verSpeed, verSpeed);
        theGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!ballActive)
        {
           theRB.velocity = Vector2.zero;
            transform.position = startPoint.position;
        }
        if (theRB.velocity.x > maxHorizontalSpeed)
        {
            theRB.velocity = new Vector2(maxHorizontalSpeed, theRB.velocity.y);
        }
        else if (theRB.velocity.x < -maxHorizontalSpeed) 
        {
            theRB.velocity = new Vector2(-maxHorizontalSpeed, theRB.velocity.y);
        }

    }
    void OnCollisionExit2D(Collision2D other)
    {

        if (ballBounce.isPlaying)
        {
            ballBounce.Stop();
            ballBounce.Play();
        }
        else{
            ballBounce.Play();
        }

        if (other.gameObject.tag == "Brick")
        {
            //    Destroy(other.gameObject);
            other.gameObject.GetComponent<BrickController>().DestroyBrick();
            if (brickHit.isPlaying)
            {
                brickHit.Stop();
                brickHit.Play();
            }
            else
            {
                brickHit.Play();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Respawn")
        {
            ballActive = false;
            theGM.RespawnBall();

            ballDead.Play();
        }
    }
    public void ActivateBall()
    {
        ballActive = true;
        theRB.velocity = new Vector2(Random.Range(-verSpeed,verSpeed), verSpeed);
    }
}
