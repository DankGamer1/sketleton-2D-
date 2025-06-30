using UnityEngine;

public class RoomChange : MonoBehaviour
{
    [SerializeField] private Transform PreviousRoom;
    [SerializeField] private Transform NewRoom;
    [SerializeField] private CAMERA_CONTROLLER cam;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(NewRoom);
                
            }
            else
            {
                cam.MoveToNewRoom(PreviousRoom);

            }
        }
    }
}
