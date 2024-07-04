using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System.Collections.Generic;

public class CustomerMovement : MonoBehaviour
{
    Vector3[] points = new Vector3[]
    {
        new Vector3(-3f, -2.6f, 0f),
        
        new Vector3(-4.6f, 0.1f, 0f),
        new Vector3(-2.6f, 1.3f, 0f),
        new Vector3(-0.6f, 2.4f, 0f),

        new Vector3(-3.8f, -1f, 0f),
        new Vector3(-1.8f, 0.2f, 0f),
        new Vector3(0.2f, 1.3f, 0f),
        
        new Vector3(-0.1f, -2.6f, 0f),
        new Vector3(1.9f, -1.4f, 0f),
        new Vector3(3.9f, -0.3f, 0f),
        
        new Vector3(0.6f, -3.7f, 0f),
        new Vector3(2.6f, -2.5f, 0f),
        new Vector3(4.6f, -1.4f, 0f),
        
        new Vector3(2.6f, 0.2f, 0f)
    };

    bool executed = false;

    float timer = 0f;

    int targetIdx = 0;

    NavMeshAgent agent;

    Vector3[] realTarget;

    [SerializeField] public Mechanism setting;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        int totalShop = Random.Range(1, 5);
        Vector3[] temp = new Vector3[totalShop + 2];
        
        List<Vector3> basic = points.ToList();

        temp[temp.Length - 1] = points[0];
        temp[temp.Length - 2] = points[points.Length - 1];

        for (int i = 0; i < totalShop; i++)
        {
            int idx = Random.Range(1, basic.Count-1);
            temp[i] = basic[idx];
            
            basic.Remove(basic[idx]);
        }

        realTarget = new Vector3[temp.Length];
        realTarget = temp;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (realTarget.Length == 0) return;

        if (targetIdx < realTarget.Length)
        {
            // agent.SetDestination(realTarget[targetIdx]);
            agent.destination = realTarget[targetIdx];

            targetIdx = targetIdx + 1;
        }
        else Destroy(gameObject);
    }

    void StopAgent(float sec)
    {
        timer += Time.deltaTime;

        agent.isStopped = true;
         
        if (timer >= sec)
        {
            agent.isStopped = false;
            GotoNextPoint();

            timer = 0;
        }
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= 0.1f) StopAgent(.5f);

        if (Vector3.Distance(gameObject.transform.position, points[points.Length - 1]) <= 0.5)
        {
            if (!executed)
            {
                setting.money += realTarget.Length * 10;
                executed = true;
            }
        }
    }
}
