using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;//room ghabl
    [SerializeField] private Transform nextRoom;//room bad
    [SerializeField] private CameraController cam;//camera

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();//etesal main camera
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")//chizi ke barkhord karde playere?
        {
            if (collision.transform.position.x < transform.position.x)//left to right
            {
                cam.MoveToNewRoom(nextRoom);//bere be room badi
                nextRoom.GetComponent<Room>().ActivateRoom(true);//room faal she
                previousRoom.GetComponent<Room>().ActivateRoom(false);//room ghbli deactive
            }
            else
            {
                cam.MoveToNewRoom(previousRoom);//room ghabli
                previousRoom.GetComponent<Room>().ActivateRoom(true);//ghbli faal
                nextRoom.GetComponent<Room>().ActivateRoom(false);//baadi deactive
            }
        }
    }
}