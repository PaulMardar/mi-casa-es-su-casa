using UnityEngine;

public class MoveHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);

        float middle = (transform.position - Camera.main.transform.position).magnitude * 0.5f;

        transform.LookAt(mouse.origin + mouse.direction * middle);
    }
}
