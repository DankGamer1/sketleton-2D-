using UnityEngine;

public class CAMERA_CONTROLLER : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform player;

    private void Update()
    {
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z),
        // ref velocity,speed);
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            }
    public void MoveToNewRoom(Transform _NewRoom)
    {
        currentPosX = _NewRoom.position.x;

    } 
}
