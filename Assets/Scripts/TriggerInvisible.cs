using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInvisible : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            int count = PlayerPrefs.GetInt("count");
            
            PlayerPrefs.SetInt("count",count++);

            Debug.Log("coliided");
        }
    }
}
