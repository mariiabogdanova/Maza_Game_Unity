using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour
{
    public GameObject GameOverPanel, winPanel;

    public float speed;
    public Text countText;
    public Text pickUpCountDown;
    public float setTime;
    public float sampleTime;
    public float pickUpRemain;
    public AudioClip collect_sound;
    // public Text timeisoutText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        if (Application.loadedLevelName == "Level 1")
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }

            rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
            // timeisoutText.text = "";
        
    }

    void Update()
    {
    	setTime -= Time.deltaTime;
    	if (setTime <= 0){
			Time.timeScale = 0;
            GameOverPanel.SetActive(true);
    	}
		pickUpCountDown.text=setTime.ToString("f0");

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
            this.gameObject.AddComponent<AudioSource>();
            this.GetComponent<AudioSource>().clip = collect_sound;
            this.GetComponent<AudioSource>().Play();

            other.gameObject.SetActive(false);
            count = count + 1;
            pickUpRemain = pickUpRemain - 1;
            SetCountText();
            setTime = sampleTime;
            Update();
        }
    }

    void SetCountText()
    {
        countText.text = "Your score: " + count.ToString();
        if (pickUpRemain == 0){
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
       
    }

}