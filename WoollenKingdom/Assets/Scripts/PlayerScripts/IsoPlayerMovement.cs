using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsoPlayerMovement : MonoBehaviour
{
    float horizontalMovement;
    float verticalMovement;
    public Rigidbody2D rb;
    public float speed = 2f;
    Vector2 movement;

    #region Sprites
    public SpriteRenderer sr;

    public List<Sprite> frontSprite;
    public List<Sprite> frontLeftSprite;
    public List<Sprite> leftSprite;
    public List<Sprite> backLeftSprite;
    public List<Sprite> backSprite;
    public List<Sprite> backRightSprite;
    public List<Sprite> rightSprite;
    public List<Sprite> frontRightSprite;

    public float frameRate;
    [SerializeField] bool isRight;
    float idleTime;
    #endregion

    public static int wool;

    public Text woolText;

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        movement = new Vector2(horizontalMovement, verticalMovement);

        //if facing right & player holds left, flip
        if(isRight && movement.x < 0)
        {
            isRight = false;
        }
        else if(!isRight && movement.x > 0)
        {
            isRight = true;
        }

        List<Sprite> directionSprites = GetSpriteDirection();

        if(directionSprites != null) //holding direction
        {
            float playTime = Time.time - idleTime; //time since started moving
            int totalFrames = (int)(playTime * frameRate); //total frames since started moving
            int frame = totalFrames % directionSprites.Count; //current frame

            sr.sprite = directionSprites[frame];
        }
        else
        {
            idleTime = Time.time;
        }

        woolText.text = "Wool Supply:" + wool.ToString();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;

        #region Back Sprites
        if (movement.y > 0) //if moving up
        {
            if(movement.x > 0) //if moving up & right
            {
                selectedSprites = backRightSprite;
            }
            else if (movement.x < 0) //if moving up & left
            {
                selectedSprites = backLeftSprite;
            }
            else
            {
                selectedSprites = backSprite;
            }
        }
        #endregion

        #region Front Sprites
        else if (movement.y < 0) //if moving down
        {
            if(movement.x > 0) //if moving down & rigt
            {
                selectedSprites = frontRightSprite;
            }
            else if (movement.x < 0) //if moving up & left
            {
                selectedSprites = frontLeftSprite;
            }
            else
            {
                selectedSprites = frontSprite;
            }
        }
        #endregion

        else //neutral
        {
            if(movement.x > 0) //if moving right
            {
                selectedSprites = rightSprite;
            }
            else if(movement.x < 0) //if moving left
            {
                selectedSprites = leftSprite;
            }
        }

        return selectedSprites;
    }
}
