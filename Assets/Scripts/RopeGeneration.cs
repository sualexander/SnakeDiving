using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGeneration : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject prefabRopeSegs;
    public int numLinks = 8;

    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody2D prevBod = hook;
        for(int i = 0; i < numLinks; ++i)
        {
            GameObject newSeg = Instantiate(prefabRopeSegs);
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;

            prevBod = newSeg.GetComponent<Rigidbody2D>();
        }
    }
}
