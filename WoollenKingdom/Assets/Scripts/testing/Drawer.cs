using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour
{
    private LineRenderer RenL;
    private Vector2 Mpos;
    private Vector2 endPos;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        RenL = GetComponent<LineRenderer>();
        RenL.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RenL.SetPosition(0, new Vector3(startPos.x, startPos.y, 0f));
            RenL.SetPosition(1, new Vector3(endPos.x, endPos.y, 0f));
        }
    }
}
