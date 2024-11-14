using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    public int CustomerPosition;
    public bool isFinishOrder;

    NavMeshAgent agent;
    GameObject AvilabelPosition;
    Vector3 EndPosition;

    int Timer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        AvilabelPosition = GameObject.FindGameObjectWithTag("CustomerPositions");
        EndPosition = GameObject.FindGameObjectWithTag("EndPosition").transform.position;
    }

    private void Update()
    {
        if (!isFinishOrder)
        {
            Transform agentPosition = AvilabelPosition.transform.GetChild(CustomerPosition).transform;
            agent.SetDestination(agentPosition.position);

            float distance = Vector3.Distance(transform.position, agentPosition.position);
            if (distance <= 0.5f)
            {
                transform.rotation = agentPosition.rotation;
            }
        }
        else
        {
            agent.SetDestination(EndPosition);
            float distance = Vector3.Distance(transform.position, EndPosition);
            if (distance <= 0.5f)
            {
                Debug.Log("Destroy");
                Destroy(this.gameObject);
            }

            if (Timer == 0)
            {
                GameObject.FindAnyObjectByType<CustomerManager>().IntantiateNewCustomer(CustomerPosition);
                Timer = 1;
            }
        }
    }
}
