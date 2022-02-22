using UnityEngine;

public class Move : MonoBehaviour
{
    private float v = 90.0f;
    private float min = 0.0f;
    private float max = 90.0f;
    private float x = 0.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var deltaTime = Time.deltaTime;
        var x1 = x + v * deltaTime;

        if (x1 > max || x1 < min)
        {
            v = v * -1;
        }
        x = x + v * deltaTime;

        transform.localRotation = Quaternion.AngleAxis(x, Vector3.up);
    }
}
