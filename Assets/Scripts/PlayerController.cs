using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text countText;
	public Text winText;


    private int count;
    public float speed;
    private Rigidbody bod;
    void Start()
    {
        count = 0;
        setCountText();
		winText.text = "";
        bod = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        bod.AddForce(movement * speed);


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();

        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
		if(count >= 12) 
		{
			winText.text = "You Win!!";
		}
    }
}
