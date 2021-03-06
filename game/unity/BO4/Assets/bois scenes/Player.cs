using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float Scale1 = 4f;
    public float Scale2 = 1f;
    public bool kanLopen = true;
    public GameObject opvolger;
    public List<GameObject> gameitems;
    private bool pickup;
    public GameObject hand;
    public float deurBound1x;
    public float deurBound1y;
    public float deurBound1z;

    public float deurBound2x;
    public float deurBound2y;
    public float deurBound2z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject i in gameitems)
        {
            Vector3 distVector = i.transform.position - transform.position;
            float distance = distVector.magnitude;

            if(distance < 0.3f)
            {
                if (Input.GetKey(KeyCode.Space) && pickup == false)
                {
                    i.transform.parent = hand.transform;
                    i.transform.position = hand.transform.position;
                    pickup = true;
                }
                if (Input.GetKeyDown(KeyCode.Q) && pickup == true)
                {
                    i.transform.parent = null;
                    i.transform.position -= new Vector3(0, 1.3f);
                    pickup = false;
                }
            }
        }

        if (kanLopen == true)
        {
            if (transform.position.x >= deurBound1x && transform.position.x <= deurBound2x)
            {

            }
            if (Input.GetKey(KeyCode.W) && transform.position.y < -3)
            {
                transform.position += new Vector3(0, speed) * Time.deltaTime;
                transform.localScale -= (new Vector3(speed / Scale1, speed / Scale2) * Time.deltaTime) /3;
            }
            if (Input.GetKey(KeyCode.A) && transform.position.x > -6.5)
            {
                transform.position -= new Vector3(speed, 0) * Time.deltaTime;   
            }
            if (Input.GetKey(KeyCode.S) && transform.position.y > -5)
            {
                transform.position -= new Vector3(0, speed) * Time.deltaTime;
                transform.localScale += (new Vector3(speed / 1.4f, speed) * Time.deltaTime) /3;
            }
            if (Input.GetKey(KeyCode.D) && transform.position.x < 5)
            {
                transform.position += new Vector3(speed, 0) * Time.deltaTime;
            }      
        }
    }
}
