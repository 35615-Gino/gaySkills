using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    public Smilers smilers;
    private Vector2 minView;
    private Vector2 maxView;

    // Start is called before the first frame update
    void Start()
    {
        minView = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxView = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float x = Random.Range(minView.x, maxView.x);
        float y = 0;

        Smilers newSmiler = Instantiate(smilers, new Vector3(x,y,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 1000) < 10)
        {
            float x = Random.Range(minView.x, maxView.x);
            float y = maxView.y + smilers.transform.localScale.y;

            Smilers newSmiler = Instantiate(smilers, new Vector3(x, y, 0), Quaternion.identity);
            newSmiler.yMin = minView.y - smilers.transform.localScale.y;
        }
    }
}
