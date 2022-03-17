using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float  speed=-12;
    private float deadLine=-10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.speed*Time.deltaTime,0,0);
        if(transform.position.x<deadLine)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
     if(other.tag=="Ground")
      {
          GetComponent<AudioSource>().Play();
      }
      if(other.tag=="Block")
      {
          GetComponent<AudioSource>().Play();
      }
    }
}
