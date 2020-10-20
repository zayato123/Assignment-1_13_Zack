using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //declare and Intitialise variables
    float speed = 10.0f;
    float vLimit = 4.8f;

    Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Declare and Init variables to reference to User Interaction inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        //Move Player (GameObject) according to user interactions
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if(transform.position.z<-vLimit)
        {
            transform.position=new Vector3(transform.position.x,transform.position.y,-vLimit)
        }else if(transform.position.z>vLimit)
                {
            transform.position = new Vector3(transform.position.x, transform.position.y, vLimit)
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}
