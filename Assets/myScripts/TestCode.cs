using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public float timetodothisloop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            for (var i = 0; i < 360; i++)
            {

                transform.Rotate(0, i*0.1f, 0);

            }
            print("space key was pressed");
        }
    }
    
}
