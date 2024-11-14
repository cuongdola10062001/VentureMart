using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject Customer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IntantiateNewCustomer(0);
        IntantiateNewCustomer(1);
        IntantiateNewCustomer(2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IntantiateNewCustomer(int c_positionNumber)
    {
        GameObject currentCustomer = Instantiate(Customer, gameObject.transform.GetChild(0).gameObject.transform);
        currentCustomer.GetComponent<Customer>().CustomerPosition = c_positionNumber;
    }
}
