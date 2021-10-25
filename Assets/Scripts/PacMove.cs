using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMove : MonoBehaviour
{
    public GameObject wallPrefab, PacMan;
    public GridManager gridManager;
    public Vector3 LastPos;
    public GameObject Particles; public Vector3 CameraPos;
    public Vector2 lastMousePosition;
    private Vector2 touchPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {



        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {

            Vector2 deltaSwipe = touchPosition - (Vector2)Input.mousePosition;

            if ((Vector2)Input.mousePosition != lastMousePosition)
            {
                lastMousePosition = (Vector2)Input.mousePosition;

                if (deltaSwipe.x < 0)
                {
                    Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    gridManager.MoveRight();
                }

                if (deltaSwipe.x > 0)
                {

                    Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    gridManager.MoveLeft();
                }
                if (deltaSwipe.y < 0)
                {
                    Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    gridManager.MoveDown();

                }

                if (deltaSwipe.y > 0)
                {
                    Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                    gridManager.MoveUp();

                }


            }
        }
    }

    private void LateUpdate()
    { 
        //Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
        if (transform.position.z >= 0 && transform.position.z < 32 && transform.position.x >= 0 && transform.position.x < 18)
        {
            if (Input.GetKey("w"))
            {
                Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                gridManager.MoveUp();
                
            }
            if (Input.GetKey("a"))
            {
                Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                gridManager.MoveLeft();
                
            }
            if (Input.GetKey("s"))
            {
                Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                gridManager.MoveDown();
                
            }
            if (Input.GetKey("d"))
            {

                Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                gridManager.MoveRight();
                
            }
        }
        if (transform.position.x >= 17)
        {
            transform.position = new Vector3(17, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= 0)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if (transform.position.z >= 31)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 31);
        }
        if (transform.position.z <= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            LastPos = transform.position;
            gridManager.Particle.transform.position = new Vector3 (LastPos.x, LastPos.y, LastPos.z);
            gridManager.Particle.SetActive(true);

            Destroy(transform.gameObject);
            gridManager.StartCoroutine(gridManager.ExecuteAfterTime1(2));
        }
        
    }

    

}
