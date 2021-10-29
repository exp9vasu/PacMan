using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public static EnemyScript instance;

    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = 1;
        GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (PacMove1.instance.Geteasy)
        {
            GetComponent<Animator>().speed = 0.5f;
        }
        else
        {
            GetComponent<Animator>().speed = 1;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            //Debug.Log("wall");
            PacMove1.instance.PacDie();
        }

        if (other.CompareTag("Invibox"))
        {

            GetComponent<ParticleSystem>().Play();
            GetComponent<Animator>().enabled = false;
            Destroy(gameObject, 2f);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("wall"))
        //{
        //    PacMove1.instance.PacDie();
        //}
    }

    
}
