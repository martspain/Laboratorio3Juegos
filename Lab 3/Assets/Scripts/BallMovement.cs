using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{

    public float force = 5;

    public float jumpForce = 10;

    private int collectible = 0;

    public GameObject prefab;

    public Text ScoreText;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Time.timeScale > 0)
            Jump();

        if (ScoreText)
            ScoreText.text = "Score: " + collectible.ToString();

    }

    private void FixedUpdate()
    {
        if (rb)
            rb.AddForce(Input.GetAxis("Horizontal") * force, 0, Input.GetAxis("Vertical") * force);
    }

    private void Jump()
    {
        if(rb)
            if(Mathf.Abs(rb.velocity.y) < 0.05f)
                rb.AddForce(0, force, 0, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Can"))
        {
            Destroy(collision.gameObject);
            collectible += 1;
        }
        else if (collision.gameObject.CompareTag("Obstacle") && collectible < 3)
        {
            Destroy(gameObject);
            //Instantiate(prefab, new Vector3(-9.28f, 1.39f, -10.63f), Quaternion.identity);
        }
    }
}
