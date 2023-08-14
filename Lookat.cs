using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    public Transform ABC, DBS;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.LookAt(ABC);
        }


        if(Input.GetKey(KeyCode.S))
        {
            transform.position = ABC.transform.position;
            transform.LookAt(DBS);
        }
    }
}
