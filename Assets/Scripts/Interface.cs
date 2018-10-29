using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Backtracking;
using GenMatrix;

public class Interface : MonoBehaviour {
    //Max 8
    public Text lvl,console; 
    public Button play;
    float speed = 0.5f;
    int level = 0;
    int[,] Matrix;
    int[,] Path;
    List<Vector3> positions = new List<Vector3>();
    Backtracking.Backtracking bt = new Backtracking.Backtracking();
    public GameObject prefab;
	// Use this for initialization
	void Start () {
        play.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (positions.Count > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = positions[0];
            positions.RemoveAt(0);
        }
    }
    void TaskOnClick()
    {
        
        lvl.text = "Level:" + (level + 1);
        DestroyObstacles();
        Matrix = GenMatrix.GenMatrix.Matrix(level);
        CreateObstacles(Matrix);
        Path = bt.solveMaze(Matrix);
        console.text = bt.console;
        MatrixToVector3(Path);
        level++;
        bt.ClearConsole();
    }
    void MatrixToVector3(int[,] M)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (M[i, j] == 1)
                {
                    positions.Add(new Vector3(i * 4, 0, j * 4));
                    positions.Add(new Vector3(i * 4, 0, j * 4));
                    positions.Add(new Vector3(i * 4, 0, j * 4));
                    positions.Add(new Vector3(i * 4, 0, j * 4));
                    positions.Add(new Vector3(i * 4, 0, j * 4));

                }
            }
        }
    }
    private void DestroyObstacles()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Obstacles");

        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
    }
    void CreateObstacles(int[,] M)
     {
        GameObject obstacle;
        obstacle = Instantiate(prefab, new Vector3(-4, 0,-4), transform.rotation);
        obstacle = Instantiate(prefab, new Vector3(-4, 0, 8*4), transform.rotation);
        obstacle = Instantiate(prefab, new Vector3(8*4, 0, 8 * 4), transform.rotation);
        obstacle = Instantiate(prefab, new Vector3(8*4, 0, -4), transform.rotation);
        for (int i=0; i < 8; i++)
        {
            for (int j=0; j < 8; j++)
            {
                if(M[i,j] == 1)
                {
                    obstacle = Instantiate(prefab, new Vector3(i*4, 0, j*4), transform.rotation);
                }
                if (i == 0)
                {
                    obstacle = Instantiate(prefab, new Vector3(-4, 0, j*4), transform.rotation);
                }
                if (i == 7)
                {
                    obstacle = Instantiate(prefab, new Vector3( i*4+4 , 0, j*4), transform.rotation);
                }
                if (j == 0)
                {
                    obstacle = Instantiate(prefab, new Vector3(i * 4, 0, -4), transform.rotation);
                }
                if (j == 7)
                {
                    obstacle = Instantiate(prefab, new Vector3(i * 4, 0, j * 4 +4), transform.rotation);
                }
            }
        }
     }
}
