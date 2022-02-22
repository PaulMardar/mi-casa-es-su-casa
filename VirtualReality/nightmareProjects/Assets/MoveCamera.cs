using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private int numberRooms = 4;
    private int currentRoom = 1;
    // Update is called once per frame
    void Update()
    {
        if (currentRoom <= numberRooms)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var position = this.transform.position;
                this.transform.position = new Vector3(position.x + 10, position.y, position.z);
                currentRoom++;
            }

    }
}
