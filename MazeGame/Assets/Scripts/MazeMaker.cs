using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMaker : MonoBehaviour
{
    private int numRows;
    private int numColumns;
    private int totalSpaces;
    private int[,] maze;
    private GameObject[] mazeBlocks;

    //Floor PreFabs to be used to make the maze//
    private GameObject zeroWayFloor;
    private GameObject oneWayFloor;
    private GameObject twoStraightWayFloor;
    private GameObject twoElbowWayFloor;
    private GameObject threeWayFloor;
    private GameObject fourWayFloor;
    /////////////////////////////////////////////

    void Awake()
    {
        numRows = 10;
        numColumns = 10;
        totalSpaces = numRows * numColumns;
        maze = new int[totalSpaces, 4];
        mazeBlocks = new GameObject[totalSpaces];

        //instantiate floor prefabs
        zeroWayFloor = Resources.Load("PreFabs/Floors/0-Way Floor") as GameObject;
        oneWayFloor = Resources.Load("PreFabs/Floors/1-Way Floor") as GameObject;
        twoStraightWayFloor = Resources.Load("PreFabs/Floors/2-Way Straight Floor") as GameObject;
        twoElbowWayFloor = Resources.Load("PreFabs/Floors/2-Way Elbow Floor") as GameObject;
        threeWayFloor = Resources.Load("PreFabs/Floors/3-Way Floor") as GameObject;
        fourWayFloor = Resources.Load("PreFabs/Floors/4-Way Floor") as GameObject;
        do
        {
            MakeGraph();
        } while (!ableToFinish(0, totalSpaces - 1));
        //print("Maze is made!");
        //PrintMaze();
        MakeMaze();
    }

    private void PrintMaze()
    {
        print("Space\t0\t1\t2\t3");
        for(int space = 0; space < totalSpaces; space++)
        {
            print(space + "\t" + maze[space, 0] + "\t" + maze[space, 1] + "\t" + maze[space, 2] + "\t" + maze[space, 3]);
        }
    }

    private void MakeGraph()
    {
        for (int space = 0; space < totalSpaces; space++)
        {
            for (int i = 0; i < 4; i++)
            {
                if (maze[space, i] != 1)
                {
                    /*
                     * need to check 9 cases:
                     * 4 corners
                     * top row
                     * bottom row
                     * left row
                     * right row
                     * middle of maze
                     * 
                     * each case has unique constraints to what can be connected to them
                     */
                    if(space == 0) //top left corner
                    {
                        if (i != 0 && i != 3)
                        {
                            maze[space, i] = Random.Range(0, 2);//Will either be 0 or 1
                            if (maze[space, i] == 1)
                            {
                                switch (i)
                                {
                                    case 0:
                                        maze[space - numColumns, 2] = 1;
                                        break;
                                    case 1:
                                        maze[space + 1, 3] = 1;
                                        break;
                                    case 2:
                                        maze[space + numColumns, 0] = 1;
                                        break;
                                    case 3:
                                        maze[space - 1, 1] = 1;
                                        break;
                                    default:
                                        print("MIDDLE SWITCH DEFAULT MAZEMAKER");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            maze[space, i] = 0;
                        }
                    }//space == 0
                    else if (space == (numColumns - 1))//top right corner
                    {
                        if (i != 0 && i != 1)
                        {
                            maze[space, i] = Random.Range(0, 2);//Will either be 0 or 1
                            if (maze[space, i] == 1)
                            {
                                switch (i)
                                {
                                    case 0:
                                        maze[space - numColumns, 2] = 1;
                                        break;
                                    case 1:
                                        maze[space + 1, 3] = 1;
                                        break;
                                    case 2:
                                        maze[space + numColumns, 0] = 1;
                                        break;
                                    case 3:
                                        maze[space - 1, 1] = 1;
                                        break;
                                    default:
                                        print("MIDDLE SWITCH DEFAULT MAZEMAKER");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            maze[space, i] = 0;
                        }
                    }//top right corner
                    else if (space == (totalSpaces - numColumns))//bottom left corner
                    {
                        if (i != 2 && i != 3)
                        {
                            maze[space, i] = Random.Range(0, 2);//Will either be 0 or 1
                            if (maze[space, i] == 1)
                            {
                                switch (i)
                                {
                                    case 0:
                                        maze[space - numColumns, 2] = 1;
                                        break;
                                    case 1:
                                        maze[space + 1, 3] = 1;
                                        break;
                                    case 2:
                                        maze[space + numColumns, 0] = 1;
                                        break;
                                    case 3:
                                        maze[space - 1, 1] = 1;
                                        break;
                                    default:
                                        print("MIDDLE SWITCH DEFAULT MAZEMAKER");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            maze[space, i] = 0;
                        }
                    }//bottom left corner
                    else if (space == (totalSpaces - 1))//bottom right corner
                    {
                        if (i != 2 && i != 1)
                        {
                            maze[space, i] = Random.Range(0, 2);//Will either be 0 or 1
                            if (maze[space, i] == 1)
                            {
                                switch (i)
                                {
                                    case 0:
                                        maze[space - numColumns, 2] = 1;
                                        break;
                                    case 1:
                                        maze[space + 1, 3] = 1;
                                        break;
                                    case 2:
                                        maze[space + numColumns, 0] = 1;
                                        break;
                                    case 3:
                                        maze[space - 1, 1] = 1;
                                        break;
                                    default:
                                        print("MIDDLE SWITCH DEFAULT MAZEMAKER");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            maze[space, i] = 0;
                        }
                    }//bottom rigth corner
                    else if (space < numColumns)// Top row
                    {
                        if (i != 0)
                        {
                            maze[space, i] = Random.Range(0, 2);//Will either be 0 or 1
                            if (maze[space, i] == 1)
                            {
                                switch (i)
                                {
                                    case 0:
                                        maze[space - numColumns, 2] = 1;
                                        break;
                                    case 1:
                                        maze[space + 1, 3] = 1;
                                        break;
                                    case 2:
                                        maze[space + numColumns, 0] = 1;
                                        break;
                                    case 3:
                                        maze[space - 1, 1] = 1;
                                        break;
                                    default:
                                        print("MIDDLE SWITCH DEFAULT MAZEMAKER");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            maze[space, i] = 0;
                        }
                    }
                    else if ((space % numColumns) == 0)//side wall
                    {
                        if (i != 3)
                        {
                            maze[space, i] = Random.Range(0, 2);//Will either be 0 or 1
                            if (maze[space, i] == 1)
                            {
                                switch (i)
                                {
                                    case 0:
                                        maze[space - numColumns, 2] = 1;
                                        break;
                                    case 1:
                                        maze[space + 1, 3] = 1;
                                        break;
                                    case 2:
                                        maze[space + numColumns, 0] = 1;
                                        break;
                                    case 3:
                                        maze[space - 1, 1] = 1;
                                        break;
                                    default:
                                        print("MIDDLE SWITCH DEFAULT MAZEMAKER");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            maze[space, i] = 0;
                        }
                    }
                    else if ((space % numColumns) == (numColumns - 1))//other side wall
                    {
                        if (i != 1)
                        {
                            maze[space, i] = Random.Range(0, 2);//Will either be 0 or 1
                            if (maze[space, i] == 1)
                            {
                                switch (i)
                                {
                                    case 0:
                                        maze[space - numColumns, 2] = 1;
                                        break;
                                    case 1:
                                        maze[space + 1, 3] = 1;
                                        break;
                                    case 2:
                                        maze[space + numColumns, 0] = 1;
                                        break;
                                    case 3:
                                        maze[space - 1, 1] = 1;
                                        break;
                                    default:
                                        print("MIDDLE SWITCH DEFAULT MAZEMAKER");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            maze[space, i] = 0;
                        }
                    }
                    else if (space > (totalSpaces - numColumns - 1))//bottom row
                    {
                        if (i != 2)
                        {
                            maze[space, i] = Random.Range(0, 2);//Will either be 0 or 1
                            if (maze[space, i] == 1)
                            {
                                switch (i)
                                {
                                    case 0:
                                        maze[space - numColumns, 2] = 1;
                                        break;
                                    case 1:
                                        maze[space + 1, 3] = 1;
                                        break;
                                    case 2:
                                        maze[space + numColumns, 0] = 1;
                                        break;
                                    case 3:
                                        maze[space - 1, 1] = 1;
                                        break;
                                    default:
                                        print("MIDDLE SWITCH DEFAULT MAZEMAKER");
                                        break;
                                }
                            }
                        }
                        else
                        {
                            maze[space, i] = 0;
                        }
                    }
                    else // in the middle
                    {
                        maze[space, i] = Random.Range(0, 2);//Will either be 0 or 1
                        if (maze[space, i] == 1)
                        {
                            switch (i)
                            {
                                case 0:
                                    maze[space - numColumns, 2] = 1;
                                    break;
                                case 1:
                                    maze[space + 1, 3] = 1;
                                    break;
                                case 2:
                                    maze[space + numColumns, 0] = 1;
                                    break;
                                case 3:
                                    maze[space - 1, 1] = 1;
                                    break;
                                default:
                                    print("MIDDLE SWITCH DEFAULT MAZEMAKER");
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }

    //implements a Breadth First Search to see if a path exists from start to end
    private bool ableToFinish(int start, int end)
    {
        int[] distance = new int[totalSpaces];
        int[] parents = new int[totalSpaces];
        for(int i = 0; i < totalSpaces; i++)
        {
            distance[i] = -1;
            parents[i] = i;
        }
        distance[start] = 0;
        Queue<int> aq = new Queue<int>();
        aq.Enqueue(start);
        while(aq.Count > 0)
        {
            int u = aq.Dequeue();
            for(int i = 0; i < 4; i++)
            {
                if (maze[u, i] == 1)
                {
                    int v;
                    if (i == 0)
                    {
                        v = u - numColumns;
                    }
                    else if (i == 1)
                    {
                        v = u + 1;
                    }
                    else if (i == 2)
                    {
                        v = u + numColumns;
                    }
                    else//i == 3
                    {
                        v = u - 1;
                    }
                    if (distance[v] == -1)
                    {
                        aq.Enqueue(v);
                        distance[v] = distance[u] + 1;
                        parents[v] = u;
                    }
                }
            }
        }
        if(distance[end] == -1)
        {
            return false;
        }
        return true;
    }

    private void MakeMaze()
    {
        //go through Graph and construct maze out of prefabs
        for(int space = 0; space < totalSpaces; space++)
        {
            int connections = maze[space, 0] + maze[space, 1] + maze[space, 2] + maze[space, 3];
            float newX;
            float newZ;
            switch (connections)
            {
                case 0:
                    //instanciate 0-way floor
                    mazeBlocks[space] = Instantiate(zeroWayFloor) as GameObject;
                    mazeBlocks[space].transform.name = ("Floor Piece " + space);
                    //set x and z of block
                    newX = -1 * (int)(space / numRows) * 10;
                    newZ = -1 * (int)(space % numColumns) * 10;
                    mazeBlocks[space].transform.position = new Vector3(newX, 0, newZ);
                    //set rotation of block
                    //no rotation needded for a 0-way floor
                    break;
                case 1:
                    //instanciate 1-way floor
                    mazeBlocks[space] = Instantiate(oneWayFloor) as GameObject;
                    mazeBlocks[space].transform.name = ("Floor Piece " + space);
                    //set x and z of block
                    newX = -1 * (int)(space / numRows) * 10;
                    newZ = -1 * (int)(space % numColumns) * 10;
                    mazeBlocks[space].transform.position = new Vector3(newX, 0, newZ);
                    //set rotation of block
                    for(int i = 0; i < 4; i++)//finds what coordinate floor is attatched to
                    {
                        if (maze[space, i] == 1)
                        {
                            //print("Space " + space + " Rotating 1-way, i = " + i + ", Rotation = " + i*90f);
                            mazeBlocks[space].transform.eulerAngles = new Vector3(0f, i * 90f, 0f);
                            break;
                        }
                    }
                    break;
                case 2://can either be a straight or elbow
                    bool straight = false;
                    for(int i = 0; i < 4; i++)
                    {
                        if(maze[space, i] == 1 && maze[space, (i + 2) % 4] == 1)
                        {
                            straight = true;
                            break;
                        }
                    }
                    if (straight)
                    {
                        //instanciate 2-way straight
                        mazeBlocks[space] = Instantiate(twoStraightWayFloor) as GameObject;
                        mazeBlocks[space].transform.name = ("Floor Piece " + space);
                        //set x and z of block
                        newX = -1 * (int)(space / numRows) * 10;
                        newZ = -1 * (int)(space % numColumns) * 10;
                        mazeBlocks[space].transform.position = new Vector3(newX, 0, newZ);
                        //set rotation of block
                        for (int i = 0; i < 4; i++)//finds what coordinate floor is attatched to
                        {
                            if (maze[space, i] == 1)
                            {
                                mazeBlocks[space].transform.eulerAngles = new Vector3(0f, i * 90f, 0f);
                                break;
                            }
                        }
                    }
                    else
                    {
                        //instanciate 2-way straight
                        mazeBlocks[space] = Instantiate(twoElbowWayFloor) as GameObject;
                        mazeBlocks[space].transform.name = ("Floor Piece " + space);
                        //set x and z of block
                        newX = -1 * (int)(space / numRows) * 10;
                        newZ = -1 * (int)(space % numColumns) * 10;
                        mazeBlocks[space].transform.position = new Vector3(newX, 0, newZ);
                        //set rotation of block
                        for (int i = 0; i < 4; i++)//finds what coordinate floor is attatched to
                        {
                            if (maze[space, i % 4] == 1 && maze[space, (i + 1) % 4] == 1)
                            {
                                mazeBlocks[space].transform.eulerAngles = new Vector3(0f, i * 90f, 0f);
                                break;
                            }
                        }
                    }
                    break;
                case 3:
                    //instanciate 3-way floor
                    mazeBlocks[space] = Instantiate(threeWayFloor) as GameObject;
                    mazeBlocks[space].transform.name = ("Floor Piece " + space);
                    //set x and z of block
                    newX = -1 * (int)(space / numRows) * 10;
                    newZ = -1 * (int)(space % numColumns) * 10;
                    mazeBlocks[space].transform.position = new Vector3(newX, 0, newZ);
                    //set rotation of block
                    for (int i = 0; i < 4; i++)//finds what coordinate floor is attatched to
                    {
                        if (maze[space, i % 4] == 1 && maze[space, (i + 1) % 4] == 1 && maze[space, (i + 2) % 4] == 1)
                        {
                            mazeBlocks[space].transform.eulerAngles = new Vector3(0f, i * 90f, 0f);
                            break;
                        }
                    }
                    break;
                case 4:
                    //instanciate 4-way floor
                    mazeBlocks[space] = Instantiate(fourWayFloor) as GameObject;
                    mazeBlocks[space].transform.name = ("Floor Piece " + space);
                    //set x and z of block
                    newX = -1 * (int)(space / numRows) * 10;
                    newZ = -1 * (int)(space % numColumns) * 10;
                    mazeBlocks[space].transform.position = new Vector3(newX, 0, newZ);
                    //set rotation of block
                    //no rotation needded for a 4-way floor
                    break;
            }
        }
    }
}