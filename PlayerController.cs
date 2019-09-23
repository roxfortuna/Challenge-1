﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody2D rb2d;
    private int count;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        countText.text = "Count: " + count.ToString();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        float moveHorzontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorzontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Count: " + count.ToString();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            countText.text = "Count: " + count.ToString();
        }
        if (count == 12)
{
    transform.position = new Vector2(50.0f, 50.0f); 
}
        if (count >= 20)
        {
            winText.text = winText.text = "You win! " +
                  "Game created by Rox Follett!";
        }
    }
}




