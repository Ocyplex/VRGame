using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LvlCreator : MonoBehaviour
{
    public GameObject[] grasGround = new GameObject[2];
    public GameObject[] stoneGround = new GameObject[2];
    public GameObject[] clayGround = new GameObject[2];
    public List<WallSocket> wallSocketList = new List<WallSocket>();

    public GameObject myWallSocket;
    public GameObject myRoofSocket;
    public GameObject stone;
    public GameObject stone1;
    public GameObject tree;
    public GameObject tree1;
    public int treeChance = 5;
    private float treePosY = 3.51f;
    public GameObject apple;


    private int sizeX = 10;
    private int sizeZ = 10;
    private int rand;
    private float stoneDirection;
    private float treeDirection;
    private int sizeMap = 40;


    void Start()
    {
        CreateMap();
    }


    void CreateMap()
    {
        int x = 0;;
        for (int i = 0; i < sizeMap; i += 10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, i);
            for (int j = 0; j < sizeMap; j += 10)
            {
                transform.position = new Vector3(j, transform.position.y, transform.position.z);

                rand = Random.Range(0, 10);
                if (rand == 0)
                {
                    CreateStoneTerrain();
                }
                else if (rand > 0 && rand < 8)
                {
                    CreateForestTerrain();
                }
                else if (rand >= 8)
                {
                    CreateClayField();
                }
                x = x + 10;
            }
        }
        CreateWallSockets();
        //CreateRoofSockets();
    }

    public void CreateStoneTerrain()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeZ; j++)
            {

                rand = Random.Range(0, 100); 
                if(rand < 90)
                {
                    rand = Random.Range(0, 2);
                    Instantiate(stoneGround[rand], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                    rand = Random.Range(0, 5);
                if (rand < 1)
                {
                    CreateStone(i, j);
                }
                }
                else
                {
                    rand = Random.Range(0, 2);
                    Instantiate(grasGround[rand], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                }
            }
        }
    }



    private void CreateStone(int i_, int j_)
    {
        stoneDirection = Random.Range(0f, 180f);
        rand = Random.Range(0, 3);
        if (rand < 2)
        {
            Instantiate(stone, new Vector3(transform.position.x + i_, transform.position.y + 0.5f, transform.position.z + j_), (Quaternion.Euler(0f, stoneDirection, 0f)));
        }
        else
        {
            Instantiate(stone1, new Vector3(transform.position.x + i_, transform.position.y + 0.5f, transform.position.z + j_), (Quaternion.Euler(0f, stoneDirection, 0f)));
        }
    }

    private void CreateTree(int i_, int j_)
    {
        treeDirection = Random.Range(0f, 180f);
        rand = Random.Range(0, 100);
        if (rand < 45)
        {
            Instantiate(tree, new Vector3(transform.position.x + i_, treePosY, transform.position.z + j_), (Quaternion.Euler(0f, treeDirection, 0f)));
        }
        else if(rand >= 45 && 90 >= rand)
        {
            Instantiate(tree1, new Vector3(transform.position.x + i_, treePosY, transform.position.z + j_), (Quaternion.Euler(0f, treeDirection, 0f)));
        }
        else if(rand > 90)
        {
            CreateStone(i_, j_);
        }
    }


    public void CreateForestTerrain()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeZ; j++)
            {
                rand = Random.Range(0, 2);
                Instantiate(grasGround[rand], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                rand = Random.Range(0, 100);
                if (rand < treeChance)
                {
                    CreateTree(i, j);
                }
            }
        }
    }
    public void CreateClayField()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeZ; j++)
            {
                rand = Random.Range(0, 10);
                if (rand < 3)
                {
                    Instantiate(clayGround[0], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                }
                else
                {
                    rand = Random.Range(0, 2);
                    Instantiate(grasGround[rand], new Vector3(transform.position.x + i, 0f, transform.position.z + j), Quaternion.identity);
                    rand = Random.Range(0, 100);
                    if (rand < (treeChance/2))
                    {
                        CreateTree(i, j);
                    }
                }
            }
        }
    }

    private void CreateWallSockets()
    {
        
        transform.position = new Vector3(-0.5f,0.5f,0f);
        for (float i = 0.5f; i < sizeMap; i++)
        {
            for (float j = 0.5f; j < sizeMap -1; j++)
            {
                Instantiate(myWallSocket, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + j), (Quaternion.Euler(0f, 90f, 0f)));
            }
        }
              
        //Creating Sockets along z-axis
        transform.position = new Vector3(0, 0.5f, -0.5f);
        for (float i = 0.5f; i < sizeMap -1; i++)
        {
            for (float j = 0.5f; j < sizeMap; j++)
            {
                Instantiate(myWallSocket, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + j), Quaternion.identity);
            }
        }
    }

    private void CreateRoofSockets()
    {
        transform.position = new Vector3(0.5f, 2.5f, 0.5f);
        for (float i = 0.5f; i < sizeMap - 2; i++)
        {
            for (float j = 0.5f; j < sizeMap - 2; j++)
            {
                Instantiate(myRoofSocket, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + j), Quaternion.identity);
            }
        }
    }
}
