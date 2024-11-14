using UnityEngine;
using UnityEngine.AI;

public class Chef : MonoBehaviour
{
    public int MachineNumber;
    public int CustomerPositionNumber;
    public bool isGetOrder;
    GameObject MachinePositions;
    Transform ChefMachinePosition;
    GameObject DeliveryPosition;

    NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MachinePositions = GameObject.FindGameObjectWithTag("MachinePositions");
        ChefMachinePosition = MachinePositions.transform.GetChild(MachineNumber).transform;

        DeliveryPosition = GameObject.FindGameObjectWithTag("DeliveryPosition");
        agent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGetOrder)
        {
            agent.SetDestination(DeliveryPosition.transform.GetChild(CustomerPositionNumber).transform.position);

            float distance = Vector3.Distance(transform.position, DeliveryPosition.transform.GetChild(CustomerPositionNumber).transform.position);

            if (distance <= 0.5f)
            {
                isGetOrder = true;
            }
        }
        else
        {
            agent.SetDestination(ChefMachinePosition.position);

            float distance = Vector3.Distance(transform.position, ChefMachinePosition.position);
        }
    }

    public void GetCustomerPosition()
    {
        GameObject customers = GameObject.FindGameObjectWithTag("Customers");
        for (int i = 0; i < customers.transform.childCount; i++)
        {
            Customer currentCustomer = customers.transform.GetChild (i).GetComponent<Customer>();
            if (currentCustomer.isFinishOrder)
            {
                CustomerPositionNumber = currentCustomer.CustomerPosition;

                break;
            }
        }
    }
}
