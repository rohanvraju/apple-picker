using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public GameObject KOstars;

    public float maxSpeed = 5f;
    private Vector3 input;
    private bool isHit = false;//if player is hit by enemy
    private bool isAlive = true;//if player is still alive
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        if(controller != null)
        {
            gameController = controller.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Couldn't find GameController");
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //allow player to move until hit by enemy
        if (!isHit)
        {
            if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
            {
                GetComponent<Rigidbody>().AddForce(input * moveSpeed);
            }
        }

        //LOSE CONDITION: if player falls off map
        if(this.transform.position.y < -0.25 && isAlive)
        {
            Debug.Log("Fell off map");
            knockOut();
            isAlive = false;
        }

        //print(input);

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            Debug.Log("Hit an enemy");
            knockOut();
        }
        else if(other.transform.tag == "Tree")
        {
            Debug.Log("tree");
            gameController.addScore(1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Goal")
        {
            Debug.Log("Reached goal");
            GameController.CompleteLevel();
        }
    }

    void knockOut()
    {
        Instantiate(KOstars, this.transform.position, Quaternion.identity);
        isHit = true;
    }
}
