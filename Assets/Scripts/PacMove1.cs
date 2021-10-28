using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMove1 : MonoBehaviour
{
    public static PacMove1 instance;
    public GameObject Particles;
    public GameObject wallPrefab, PacMan;
    public GridManager gridManager;
    public Vector3 LastPos;
    public int currentX = 1, currentY = 1;
    public int prevX, prevY;
    public Vector3 CameraPos;
    public Vector2 lastMousePosition;
    private Vector2 touchPosition;

    public GameObject InsideBox;

    public GameObject eyes1,eyes2; 

    public int Count;


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
        Count = 0;

        //prevX = currentX;
        //prevY = currentY;

        //gridManager.gridArray = new int[100,100];
        //for (int i = 0; i < gridManager.width; i++)
        //{
        //    for (int j = 0; j < gridManager.length; j++)
        //    {
        //        //Instantiate(Prefab, new Vector3(i, unitsize, j), Quaternion.identity);
        //        gridManager.gridArray[i, j] = 0;
        //    }
        //}
    }

    private void LateUpdate()
    {
        prevX = currentX;
        prevY = currentY;

        //Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
        if (transform.position.z >= 0 && transform.position.z < 32 && transform.position.x >= 0 && transform.position.x < 18 && transform.GetComponent<MeshRenderer>().enabled)
        {
            if (Input.GetKeyDown("w"))
            {
                //Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                gridManager.MoveUp();
                currentY++;
                function(prevX, prevY);
            }
            if (Input.GetKeyDown("a"))
            {
                //Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                gridManager.MoveLeft();
                currentX--;
                function(prevX, prevY);
            }
            if (Input.GetKeyDown("s"))
            {
                //Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                gridManager.MoveDown();
                currentY--;
                function(prevX, prevY);
            }
            if (Input.GetKeyDown("d"))
            {

                //Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
                gridManager.MoveRight();
                currentX++;
                function(prevX, prevY);
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
        
        // Update is called once per frame
        void Update()
    {

        //function(prevX, prevY);


        //if (transform.position.z >= 0 && transform.position.z < 32 && transform.position.x >= 0 && transform.position.x < 18)
        //{
        //    if (Input.GetKey("w"))
        //    {
        //        //Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
        //    }
        //    if (Input.GetKey("a"))
        //    {
        //        //Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
        //    }
        //    if (Input.GetKey("s"))
        //    {
        //        //Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
        //    }
        //    if (Input.GetKey("d"))
        //    {

        //        //Instantiate(wallPrefab, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity);
        //    }
        //}
    }

    bool bfs(int x, int y, bool p)
    {
        bool q = p;
        if (x >= gridManager.width - 1 || x < 1 || y >= gridManager.length - 1 || y < 1)
        {
            return true;
        }
        //Debug.Log("VasuX" + x);
        //Debug.Log("VasuY" + y);

        //Debug.Log("Vasu" + p);

        if (gridManager.gridArray[x, y] != 0)
            return false;
        gridManager.gridArray[x, y] = 1;
        q = bfs(x + 1, y, p) || bfs(x - 1, y, p) || bfs(x, y + 1, p) || bfs(x, y - 1, p);
        gridManager.gridArray[x, y] = 0;
        return q;
    }

    void fill(int x, int y)
    {
        if (x >= gridManager.width - 1 || x < 1 || y >= gridManager.length - 1 || y < 1)
        {
            return;
        }
        if (gridManager.gridArray[x, y] == -1)
        { return; }
        Instantiate(InsideBox, new Vector3(x, 2, y), Quaternion.identity);
        Count++;
        gridManager.gridArray[x, y] = -1;
        fill(x + 1, y);
        fill(x - 1, y);
        fill(x, y + 1);
        fill(x, y - 1);
        return;
    }

    void function(int x, int y)
    {
        if (gridManager.gridArray[x, y] == -1)
        { return; }

        Instantiate(wallPrefab, new Vector3(x, 2, y), Quaternion.identity);
        Count++;
        gridManager.gridArray[x, y] = -1;
        int i = 1;
        int j = 1;
        for (i = 1; i < gridManager.length - 1; i++)
        {
            for (j = 1; j < gridManager.width - 1; j++)
            {
                if (!bfs(i, j, false))
                    fill(i, j);
            }
        }

        return;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            PacDie();
        }

    }

    public void PacDie()
    {
        LastPos = transform.position;
        gridManager.Particle.transform.position = new Vector3(LastPos.x, LastPos.y, LastPos.z);
        //gridManager.Particle.SetActive(true);
        gridManager.Flare();

        transform.GetComponent<MeshRenderer>().enabled = false;
        eyes1.GetComponent<MeshRenderer>().enabled = false;
        eyes2.GetComponent<MeshRenderer>().enabled = false;

        gridManager.StartCoroutine(gridManager.ExecuteAfterTime1(2));
        gridManager.StartCoroutine(gridManager.ExecuteAfterTime2(5));
        //Destroy(transform.gameObject);
    }
}