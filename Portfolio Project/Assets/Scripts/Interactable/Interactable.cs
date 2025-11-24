using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hand"))
        {
            //Debug.Log("HandDetected");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hand"))
        {
            //Debug.Log("HandDetected");
        }
    }


    virtual public void Activate( )
    {
        Debug.Log(gameObject.name+ " Activated!");
    }
    private void Start()
    {

    }
    private void Update()
    {
        
    }
}
