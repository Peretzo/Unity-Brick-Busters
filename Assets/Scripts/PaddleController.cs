using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;
    public float direction;
    public float adjustSpeed;
    public Transform leftLimit, rightLimit;
    private Rigidbody2D myRigidBody;
  


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1f)
        {
            if (Input.GetKey(KeyCode.D)) // D arrow pressed
            {
                //movement code
                transform.position = new Vector3(transform.position.x + (speed + Time.deltaTime), transform.position.y, transform.position.z);
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.A)) // A arrow pressed
            {
                //movement code
                transform.position = new Vector3(transform.position.x - (speed + Time.deltaTime), transform.position.y, transform.position.z);
                direction = -1;
            }
            else
            {
                direction = 0;
            }

            if (transform.position.x > rightLimit.position.x)
            {
                transform.position = new Vector3(rightLimit.position.x, transform.position.y, 0);
            }
            else if (transform.position.x < leftLimit.position.x)
            {
                transform.position = new Vector3(leftLimit.position.x, transform.position.y, 0);
            }
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x + (direction + adjustSpeed), other.rigidbody.velocity.y);
        Debug.Log(other.rigidbody.velocity);
    }
}
