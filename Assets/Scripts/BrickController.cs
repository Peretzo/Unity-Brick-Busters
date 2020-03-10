using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public int brickValue;
    private GameManager theGM;
    public GameObject scoreEffect;
    // Start is called before the first frame update
    void Start()
    {
        theGM = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyBrick()
    {
        theGM.AddScore(brickValue);
        GameObject scoreObject = (GameObject)Instantiate(scoreEffect, transform.position + new Vector3(5, 1, 0), transform.rotation);
        scoreObject.GetComponent<ScoreEffect>().scoreText.text = "" +brickValue;
        Destroy(gameObject);
    }
}
