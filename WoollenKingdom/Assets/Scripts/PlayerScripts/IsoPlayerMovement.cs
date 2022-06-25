using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IsoPlayerMovement : MonoBehaviour
{
    #region General Movement
    float horizontalMovement;
    float verticalMovement;
    public Rigidbody2D rb;
    public float speed = 2f;
    Vector2 movement;
    public bool canMove = true;
    #endregion

    public GameObject textBox;

    #region Animations
    public Animator anim;                  //0,                    1,                      2,                  3,                  4,                  5,                  6,                  7
    public string[] idleAnims = { "Kid_Idle_Front", "Kid_Idle_Front_Right", "Kid_Idle_Right", "Kid_Idle_Back_Right", "Kid_Idle_Back", "Kid_Idle_Back_Left", "Kid_Idle_Left", "Kid_Idle_Front_Left" };
    int lastDirection; //using number as index for which animation was last played
    #endregion

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

    #region Wool
    public static int wool;
    //public Text woolText;
    public TMP_Text woolTextPro;
    #endregion

    void Awake()
    {
        anim = GetComponent<Animator>();
        canMove = true;
    }
    void Update()
    {   
        if(textBox.activeInHierarchy)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if(canMove)
        {
            horizontalMovement = Input.GetAxis("Horizontal");
            verticalMovement = Input.GetAxis("Vertical");

            movement = new Vector2(horizontalMovement, verticalMovement);
        }

        //if facing right & player holds left, flip
        if(isRight && movement.x < 0)
        {
            isRight = false;
        }
        else if(!isRight && movement.x > 0)
        {
            isRight = true;
        }

        #region Sprite Behaviour
        List<Sprite> directionSprites = GetSpriteDirection();
        string[] directionArray = null;

        if(directionSprites != null && textBox.activeInHierarchy) //if input is being detected && text box is active 
        {
            idleTime = Time.time;
            directionArray = idleAnims; //if no movement detected use idle anims
            anim.enabled = true;
            anim.Play(directionArray[lastDirection]);
            
        }
        else if(directionSprites != null) //holding direction
        {
            float playTime = Time.time - idleTime; //time since started moving
            int totalFrames = (int)(playTime * frameRate); //total frames since started moving
            int frame = totalFrames % directionSprites.Count; //current frame

            anim.enabled = false;
            sr.sprite = directionSprites[frame];
        }
        else
        {
            idleTime = Time.time;
            directionArray = idleAnims; //if no movement detected use idle anims
            anim.enabled = true;
            anim.Play(directionArray[lastDirection]);
        }
        #endregion

        woolTextPro.text = "Wool Supply: " + wool.ToString();
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
        }
    }

    //the lastDirection number is taken & when the player is no longer pressing down, thar idle animation plays; THAT'S why there is a delay in animation play
    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;

        #region Back Sprites
        if (movement.y > 0) //if moving up
        {
            if(movement.x > 0) //if moving up & right
            {
                selectedSprites = backRightSprite;
                lastDirection = 3;
            }
            else if (movement.x < 0) //if moving up & left
            {
                selectedSprites = backLeftSprite;
                lastDirection = 5;
            }
            else
            {
                selectedSprites = backSprite;
                lastDirection = 4;
            }
        }
        #endregion

        #region Front Sprites
        else if (movement.y < 0) //if moving down
        {
            if(movement.x > 0) //if moving down & rigt
            {
                selectedSprites = frontRightSprite;
                lastDirection = 1;
            }
            else if (movement.x < 0) //if moving up & left
            {
                selectedSprites = frontLeftSprite;
                lastDirection = 7;
            }
            else
            {
                selectedSprites = frontSprite;
                lastDirection = 0;
            }
        }
        #endregion

        else //neutral
        {
            if(movement.x > 0) //if moving right
            {
                selectedSprites = rightSprite;
                lastDirection = 2;
            }
            else if(movement.x < 0) //if moving left
            {
                selectedSprites = leftSprite;
                lastDirection = 6;
            }
        }

        return selectedSprites;
    }
}
