using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class pen : MonoBehaviour
{
    [Header("Pen Canvas")]
    [SerializeField] private PenCanvas penCanvas;


    [Header("Dots")]
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] Transform dotParent;

    [Header("Lines")]
    [SerializeField] private GameObject linePrefab;
    [SerializeField] Transform lineParent;
    private LineController currentLine;

    public GameObject poly;

    private Vector2[] vects;

    private Vector2 point1;

    private Vector2 point2;

    private Vector2 point3;

    private Vector2 point4;

    private Vector2 point5;

    private Vector2 point6;

    int i=1;

    public GameObject[] obstacle;



    // Start is called before the first frame update
    private void Start()
    {
        //adds different events the player will be able to activate depending on the button they press
        penCanvas.OnPenCanvasLeftClickEvent += AddDot;
        penCanvas.OnPenCanvasRightClickEvent += EndCurrentLine;

        //disables polugoncollider2d
        this.GetComponent<PolygonCollider2D>().enabled = false;
    }

    
    //This event is activated once the right click is pressed
    private void EndCurrentLine(){
        if(currentLine != null){

            //completes the shape the player is drawing
            currentLine.ToggleLoop();

            //they can no longer add more lines to the shape they created
            currentLine = null;

            this.GetComponent<PolygonCollider2D>().enabled = true;

            this.GetComponent<PolygonCollider2D>().points = new[]{point1,point2,point3,point4,point5,point6};

            i = 1;
        }
    }
    

    private void AddDot() {
        if (currentLine == null)
            {
                currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineController>();

            }

            DotController dot = Instantiate(dotPrefab, GetMousePosition(), Quaternion.identity, dotParent).GetComponent<DotController>();
            dot.OnDragEvent += MoveDot;
            dot.OnRightClickEvent += RemoveDot;

                if (i == 1)
                {
                    point1 = GetMousePosition() * 1f;

                    Debug.Log(point1);

                }
                if (i == 2)
                {
                    point2 = GetMousePosition() * 1f;

                    Debug.Log(point2);
                }
                if (i == 3)
                {
                    point3 = GetMousePosition() * 1f;

                    Debug.Log(point3);
                }
                if (i == 4)
                {
                    point4 = GetMousePosition() * 1f;

                    Debug.Log(point4);
                }
                if (i == 5)
                {
                    point4 = GetMousePosition() * 1f;

                    Debug.Log(point5);
                }
                if (i == 6)
                {
                    point4 = GetMousePosition() * 1f;

                    Debug.Log(point6);
                }

            i++;

            currentLine.AddPoint(dot);

            IsoPlayerMovement.wool -= 1;
    }

   
    private void RemoveDot(DotController dot) {
        LineController line=dot.line;
        line.SplitPointAtIndex(dot.index, out List<DotController> before, out List<DotController>after);

        Destroy(line.gameObject);
        Destroy(dot.gameObject);

        IsoPlayerMovement.wool += 1;

        LineController beforeLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineController>();
        for(int i = 0; i < before.Count; i++) {
            beforeLine.AddPoint(before[i]);
        }

        LineController afterLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineController>();
        for(int i = 0; i < after.Count; i++) {
            afterLine.AddPoint(after[i]);
        }
    }

    private void MoveDot(DotController dot) {
        dot.transform.position = GetMousePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            
            obstacle[1].GetComponent<TilemapCollider2D>().enabled = false;

            Debug.Log("crossing bridge");
        }
    }

    public void OnTriggerExit2D (Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            obstacle[1].GetComponent<TilemapCollider2D>().enabled = true;

            Debug.Log("closed");
        }
    }

    private Vector3 GetMousePosition(){
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
}
