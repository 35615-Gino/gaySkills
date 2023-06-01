using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Les1 : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    public Vector3 v;
    public GameObject p;
    public float t = 0f;
    public float tmax = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(A.transform.position);
        //Debug.Log(A.transform.position.magnitude);
        //Debug.Log(B.transform.position);
        v = B.transform.position - A.transform.position;
        p.transform.position = A.transform.position;
        Debug.Log(v.magnitude );
        v.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        p.transform.position += v * 1f * Time.deltaTime;
        if((B.transform.position - p.transform.position).magnitude < 0.1f)
        {
            tmax = t;
            p.transform.position = A.transform.position;
            t = 0;
        }
    }
}
