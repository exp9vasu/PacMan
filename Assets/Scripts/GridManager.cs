using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    public int width, length;
    public float unitsize;
    public int[,] gridArray;
    public GameObject Prefab, wallPrefab;
    public GameObject Pac;
    public GameObject Apple, Particle, LosePanel;
    public int nDied;

    public Vector3 LastPos;
   
    public int count;
    public PacMove1 pacMove1;

    // Start is called before the first frame update
    void Start()
    {
        gridArray = new int[100,100];
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                //Instantiate(Prefab, new Vector3(i, unitsize, j), Quaternion.identity);
                gridArray[i, j] = 0;
            }
    }
        StartCoroutine(ExecuteAfterTime(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flare()
    {
        
        pacMove1.Particles.SetActive(true);
    }

    public void MoveUp()
    {
        {
            Pac.transform.position = new Vector3(Pac.transform.position.x, Pac.transform.position.y, Pac.transform.position.z + 1);
            
        }
    }
    public void MoveLeft()
    {
      
        {
            Pac.transform.position = new Vector3(Pac.transform.position.x - 1, Pac.transform.position.y, Pac.transform.position.z);
            
        }
    }
    public void MoveRight()
    {
        
        {
            Pac.transform.position = new Vector3(Pac.transform.position.x + 1, Pac.transform.position.y, Pac.transform.position.z);
           
        }
    }
    public void MoveDown()
    {
       
        {
            Pac.transform.position = new Vector3(Pac.transform.position.x, Pac.transform.position.y, Pac.transform.position.z - 1);
            
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy((Instantiate(Apple, new Vector3(Random.Range(1,15), 2, Random.Range(1,30)), Quaternion.identity)).gameObject, 8);
        StartCoroutine(ExecuteAfterTime(5));
    }

    public IEnumerator ExecuteAfterTime1(float time)
    {
        yield return new WaitForSeconds(time);
        //LosePanel.SetActive(true);

    }
    public void NextLevel()
    {
        SceneManager.LoadScene(0);}
    
    public IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);

       Pac.GetComponent<MeshRenderer>().enabled = true;
       pacMove1.eyes1.GetComponent<MeshRenderer>().enabled = true;
        pacMove1.eyes2.GetComponent<MeshRenderer>().enabled = true;
        Particle.SetActive(false);
    }

}
