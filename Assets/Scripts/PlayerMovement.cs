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

        //if player collides with enemy, stop player movement
        if (!isHit)
        {
            if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
            {
                GetComponent<Rigidbody>().AddForce(input * moveSpeed);
            }
        }

        //print(input);

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            Debug.Log("Hit an enemy");
            Instantiate(KOstars, this.transform.position, Quaternion.identity);
            isHit = true;
        }
        else if(other.transform.tag == "Tree")
        {
            Debug.Log("tree");
            gameController.addScore(1);
        }
    }
}
