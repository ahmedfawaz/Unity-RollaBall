using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBallPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float m_moveForce;

    public Text counterText;
    public Text winText;

    public int count;

    // Use this for initialization
    void Start ()
    {
        
        rb = rb.GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float m_movehorizontal = Input.GetAxis("Horizontal");
        float m_moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(m_movehorizontal, 0.0f, m_moveVertical);

        rb.AddForce(movement * m_moveForce);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Collectable"))
        {
            col.gameObject.SetActive(false);

            count = count + 1;
            setCountText();
        }
    }

    void setCountText()
    {
        counterText.text = "SCORE: " + count.ToString();
        if (count >= 3)
        {
            winText.text = "YOU WIN!";
            Time.timeScale = 0;
        }
    }
}
