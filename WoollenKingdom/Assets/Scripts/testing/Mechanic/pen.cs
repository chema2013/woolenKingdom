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


    // Start is called before the first frame update
    private void Start()
    {
        penCanvas.OnPenCanvasLeftClickEvent += AddDot;
    }

    private void AddDot() {
        if (currentLine == null)
            {
                currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineController>();

            }

            GameObject dot = Instantiate(dotPrefab, GetMousePosition(), Quaternion.identity, dotParent);
            currentLine.AddPoint(dot.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            
            if (currentLine == null)
            {
                currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, lineParent).GetComponent<LineController>();

            }

            GameObject dot = Instantiate(dotPrefab, GetMousePosition(), Quaternion.identity, dotParent);
            currentLine.AddPoint(dot.transform);
        }
    }

    private Vector3 GetMousePosition(){
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
}
