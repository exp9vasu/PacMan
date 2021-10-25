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
   
    public int count;
    public PacMove pacMove;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flare()
    {
        
        pacMove.Particles.SetActive(true);
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
        LosePanel.SetActive(true);

    }
    public void NextLevel()
    {
        SceneManager.LoadScene(0);}
}
