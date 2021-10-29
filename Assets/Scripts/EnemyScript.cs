using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Destroy(gameObject, 3f);
            
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
