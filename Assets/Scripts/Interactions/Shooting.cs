using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform camara;
    public GameObject bullet;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            GameObject go = Instantiate(bullet);
            go.transform.position = camara.position;
            go.transform.rotation = camara.rotation;

            go.GetComponent<Rigidbody>().velocity = camara.forward * speed;

        }
    }
}
