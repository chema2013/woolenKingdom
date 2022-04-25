using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour
{
    private LineRenderer RenL;
    private Vector2 endPos;
    private Vector2 startPos;
    public float distance;

    //defines static variable for distance
    public static float hyp;

    public GameObject prefab;

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
            distance = (endPos - startPos).magnitude;
            //distance equals to static variable
            hyp = distance;  
        }

        if(Input.GetMouseButtonDown(1))
        {
            //calculates rotation
            float angle = Mathf.Atan2(startPos.y, endPos.x) * Mathf.Rad2Deg - 90;
            
            Quaternion angAxis = Quaternion.AngleAxis(angle, Vector3.forward);
            Debug.Log("Angle:" + angle);
            prefab.transform.rotation = Quaternion.Slerp(transform.rotation, angAxis, Time.deltaTime * 360);
            //creates a new object (in the middle of enfPos and startPos)
            Vector2 pos1 = startPos;
            Vector2 pos2 = endPos;

           Vector2 posx = Vector2.Lerp(pos1, pos2, 0.5f);

           Instantiate(prefab,posx,angAxis);
        }
    }
}
