using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float horizontalMovement;
    float verticalMovement;
    public Rigidbody2D rb;
    public float speed = 2f;
    Vector2 movement;

    public static int wool;

    public Text woolText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontalMovement, verticalMovement);

        woolText.text = "Wool Supply:" + wool.ToString();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
