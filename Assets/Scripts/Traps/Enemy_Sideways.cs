using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField] private float movementDistance;//fasele koli saw
    [SerializeField] private float speed;//sorat
    [SerializeField] private float damage;//damage
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;//fasele chap
        rightEdge = transform.position.x + movementDistance;//fasele rast
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)//be edge nareside bashe
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);//update position
            }
            else
                movingLeft = false;//bere rast
        }
        else
        {
            if (transform.position.x < rightEdge)//be rast nareside bashe
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);//bere rast
            }
            else
                movingLeft = true;//bere chap
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")//age player barkhord
        {
            collision.GetComponent<Health>().TakeDamage(damage);//damage
        }
    }
}