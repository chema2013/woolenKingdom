using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private List<DotController> dots;

    private void Awake() {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 0;

        dots = new List<DotController>();
    }

    public void AddPoint(DotController dot) {
        dot.index = dots.Count;
        dot.SetLine(this);

        lr.positionCount++;
        dots.Add(dot);
    }

    public void SplitPointAtIndex(int index, out List<DotController> beforeDots, out List<DotController> afterDots){
        List<DotController> before = new List<DotController>();
        List<DotController> after = new List<DotController>();

        int i = 0;
        for (; i < index; i++) {
            before.Add(dots[i]);
        }
        i++;
        for(;i < dots.Count; i++){
            after.Add(dots[i]);
        }

        beforeDots = before;
        afterDots = after;
    }

    public void ToggleLoop() {
        lr.loop = !lr.loop;
    }

    public bool islooped(){
        return lr.loop;
    }

    private void LateUpdate(){
        if (dots.Count >= 2) {
            for (int i = 0; i < dots.Count; i++){
                lr.SetPosition(i,dots[i].transform.position);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
