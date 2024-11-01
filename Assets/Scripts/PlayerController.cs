using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    

    private float speed; //How hard the ball is pushed
    private float xDirection; //Move the ball left and right
    private float zDirection; //Move the ball forwards and backwards
    private int count; //Naming the variable count makes it easier to understand its role in context. 

    // Start is called before the first frame update
    void Start()
    {

        winTextObject.SetActive(false);
        speed = 1;
        count = 0;
 
        SetCountText();
       

    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();
        MoveBall();
        if (count >= 13) 
        {
            winTextObject.SetActive(true);
        }

    }
    //Uses Player Input to Move Ball
    private void MoveBall()
    {
        Vector3 direction = new Vector3(xDirection, 0, zDirection);
        GetComponent<Rigidbody>().AddForce(direction * speed);

        //Listens for the player clicking arrows or WASD keys
    }
    private void GetPlayerInput()
    {   
        xDirection = Input.GetAxis("Horizontal");
        zDirection = Input.GetAxis("Vertical");
    }
    private void SetCountText()
        {
            countText.text = "Count: " + count.ToString();
        }
  
    void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }
}
    
