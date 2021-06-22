using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMove : MonoBehaviour
{
    public bool turn = false;

    List<Terrain> selectableTerrains = new List<Terrain>();
    GameObject[] terrains;

    Stack<Terrain> path = new Stack<Terrain>();
    Terrain currentTerrain;

    public bool moving = false;
    public int move = 5;
    public float jumpHeight = 2;
    public float moveSpeed = 2;
    public float jumpVelocity = 4.5f;

    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();

    float halfHeight = 0;

    bool fallingDown = false;
    bool jumpingUp = false;
    bool movingEdge = false;
    Vector3 jumpTarget;

    public Terrain actualTargetTerrain;

    protected void Init()
    {
        terrains = GameObject.FindGameObjectsWithTag("Terrain");

        halfHeight = GetComponent<Collider>().bounds.extents.y;

       // TurnManager.AddUnit(this);
    }

    public void GetCurrentTerrain()
    {
        currentTerrain = GetTargetTerrain(gameObject);
        currentTerrain.current = true;
    }

    public Terrain GetTargetTerrain(GameObject target)
    {
        RaycastHit hit;
        Terrain terrain = null;

        if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1))
        {
            terrain = hit.collider.GetComponent<Terrain>();
        }

        return terrain;
    }

    public void ComputeAdjacencyLists(float jumpHeight, Terrain target)
    {
       // terrains = GameObject.FindGameObjectsWithTag("Terrain");

        foreach (GameObject terrain in terrains)
        {
            Terrain t = terrain.GetComponent<Terrain>();
            t.FindNeighbors(jumpHeight, target);
        }
    }

    public void FindSelectableTerrains()
    {
        ComputeAdjacencyLists(jumpHeight, null);
        GetCurrentTerrain();

        Queue<Terrain> process = new Queue<Terrain>();

        process.Enqueue(currentTerrain);
        currentTerrain.visited = true;
        //currentTerrain.parent = ??  leave as null 

        while (process.Count > 0)
        {
            Terrain t = process.Dequeue();

            selectableTerrains.Add(t);
            t.selectable = true;

            if (t.distance < move)
            {
                foreach (Terrain terrain in t.adjacencyList)
                {
                    if (!terrain.visited)
                    {
                        terrain.parent = t;
                        terrain.visited = true;
                        terrain.distance = 1 + t.distance;
                        process.Enqueue(terrain);
                    }
                }
            }
        }
    }

    public void MoveToTerrain(Terrain terrain)
    {
        path.Clear();
        terrain.target = true;
        moving = true;

        Terrain next = terrain;
        while (next != null)
        {
            path.Push(next);
            next = next.parent;
        }
    }

    public void Move()
    {
        if (path.Count > 0)
        {
            Terrain t = path.Peek();
            Vector3 target = t.transform.position;

            //Calculate the unit's position on top of the target terrain
            target.y += halfHeight + t.GetComponent<Collider>().bounds.extents.y;

            if (Vector3.Distance(transform.position, target) >= 0.05f)
            {
                bool jump = transform.position.y != target.y;

                if (jump)
                {
                    Jump(target);
                }
                else
                {
                    CalculateHeading(target);
                    SetHorizotalVelocity();
                }

                //Locomotion
                transform.forward = heading;
                transform.position += velocity * Time.deltaTime;
            }
            else
            {
                //Terrain center reached
                transform.position = target;
                path.Pop();
            }
        }
        else
        {
            RemoveSelectableTerrains();
            moving = false;

           // TurnManager.EndTurn();
        }
    }

    protected void RemoveSelectableTerrains()
    {
        if (currentTerrain != null)
        {
            currentTerrain.current = false;
            currentTerrain = null;
        }

        foreach (Terrain terrain in selectableTerrains)
        {
            terrain.Reset();
        }

        selectableTerrains.Clear();
    }

    void CalculateHeading(Vector3 target)
    {
        heading = target - transform.position;
        heading.Normalize();
    }

    void SetHorizotalVelocity()
    {
        velocity = heading * moveSpeed;
    }

    void Jump(Vector3 target)
    {
        if (fallingDown)
        {
            FallDownward(target);
        }
        else if (jumpingUp)
        {
            JumpUpward(target);
        }
        else if (movingEdge)
        {
            MoveToEdge();
        }
        else
        {
            PrepareJump(target);
        }
    }

    void PrepareJump(Vector3 target)
    {
        float targetY = target.y;
        target.y = transform.position.y;

        CalculateHeading(target);

        if (transform.position.y > targetY)
        {
            fallingDown = false;
            jumpingUp = false;
            movingEdge = true;

            jumpTarget = transform.position + (target - transform.position) / 2.0f;
        }
        else
        {
            fallingDown = false;
            jumpingUp = true;
            movingEdge = false;

            velocity = heading * moveSpeed / 3.0f;

            float difference = targetY - transform.position.y;

            velocity.y = jumpVelocity * (0.5f + difference / 2.0f);
        }
    }

    void FallDownward(Vector3 target)
    {
        velocity += Physics.gravity * Time.deltaTime;

        if (transform.position.y <= target.y)
        {
            fallingDown = false;
            jumpingUp = false;
            movingEdge = false;

            Vector3 p = transform.position;
            p.y = target.y;
            transform.position = p;

            velocity = new Vector3();
        }
    }

    void JumpUpward(Vector3 target)
    {
        velocity += Physics.gravity * Time.deltaTime;

        if (transform.position.y > target.y)
        {
            jumpingUp = false;
            fallingDown = true;
        }
    }

    void MoveToEdge()
    {
        if (Vector3.Distance(transform.position, jumpTarget) >= 0.05f)
        {
            SetHorizotalVelocity();
        }
        else
        {
            movingEdge = false;
            fallingDown = true;

            velocity /= 5.0f;
            velocity.y = 1.5f;
        }
    }

    protected Terrain FindLowestF(List<Terrain> list)
    {
        Terrain lowest = list[0];

        foreach (Terrain t in list)
        {
            if (t.f < lowest.f)
            {
                lowest = t;
            }
        }

        list.Remove(lowest);

        return lowest;
    }

    protected Terrain FindEndTerrain(Terrain t)
    {
        Stack<Terrain> tempPath = new Stack<Terrain>();

        Terrain next = t.parent;
        while (next != null)
        {
            tempPath.Push(next);
            next = next.parent;
        }

        if (tempPath.Count <= move)
        {
            return t.parent;
        }

        Terrain endTerrain = null;
        for (int i = 0; i <= move; i++)
        {
            endTerrain = tempPath.Pop();
        }

        return endTerrain;
    }

    protected void FindPath(Terrain target)
    {
        ComputeAdjacencyLists(jumpHeight, target);
        GetCurrentTerrain();

        List<Terrain> openList = new List<Terrain>();
        List<Terrain> closedList = new List<Terrain>();

        openList.Add(currentTerrain);
        //currentTerrain.parent = ??
        currentTerrain.h = Vector3.Distance(currentTerrain.transform.position, target.transform.position);
        currentTerrain.f = currentTerrain.h;

        while (openList.Count > 0)
        {
            Terrain t = FindLowestF(openList);

            closedList.Add(t);

            if (t == target)
            {
                actualTargetTerrain = FindEndTerrain(t);
                MoveToTerrain(actualTargetTerrain);
                return;
            }

            foreach (Terrain terrain in t.adjacencyList)
            {
                if (closedList.Contains(terrain))
                {
                    //Do nothing, already processed
                }
                else if (openList.Contains(terrain))
                {
                    float tempG = t.g + Vector3.Distance(terrain.transform.position, t.transform.position);

                    if (tempG < terrain.g)
                    {
                        terrain.parent = t;

                        terrain.g = tempG;
                        terrain.f = terrain.g + terrain.h;
                    }
                }
                else
                {
                    terrain.parent = t;

                    terrain.g = t.g + Vector3.Distance(terrain.transform.position, t.transform.position);
                    terrain.h = Vector3.Distance(terrain.transform.position, target.transform.position);
                    terrain.f = terrain.g + terrain.h;

                    openList.Add(terrain);
                }
            }
        }

        //todo - what do you do if there is no path to the target terrain?
        Debug.Log("Path not found");
    }

    public void BeginTurn()
    {
        turn = true;
    }

    public void EndTurn()
    {
        turn = false;
    }
}
