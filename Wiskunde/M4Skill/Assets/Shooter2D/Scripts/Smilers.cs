using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smilers : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0, -1, 0);
    public float speed = 1;
    public float yMin = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * speed * Time.deltaTime;
        if(transform.position.y < yMin)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
