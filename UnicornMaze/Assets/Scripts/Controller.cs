using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text pickUpCountDown;
    public float setTime;
    public float sampleTime;
   // public Text timeisoutText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
       // timeisoutText.text = "";
    }

    void Update()
    {
    	setTime -= Time.deltaTime;
    	print(setTime);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            setTime = sampleTime;
            Update();
        }
    }

    void SetCountText()
    {
        countText.text = "Your score: " + count.ToString();
       // if (count >= 12)
       // {
       //     timeisoutText.text = "You Win!";
       // }
    }

    void SetCountDownText()
    {
    	
    }
}