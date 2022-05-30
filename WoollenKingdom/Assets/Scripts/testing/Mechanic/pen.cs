using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Component col;



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

    private Vector3 GetMousePosition(){
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
}
