using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text scoreText;
    public Text winText;
    private Rigidbody rb;
    private int scoreCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreCount = 0;
        SetScoreText();
        winText.text = "";
    }

    // Use this for initialization
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            scoreCount++;
            SetScoreText();
        }
    }

    void SetScoreText ()
    {
        scoreText.text = "Score: " + scoreCount.ToString ();

        if (scoreCount >=20)
        {
            winText.text = "You Win!";
        }
    }
}
