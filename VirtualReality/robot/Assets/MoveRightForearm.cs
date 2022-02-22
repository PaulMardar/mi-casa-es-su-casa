using UnityEngine;

public class MoveRightForearm : MonoBehaviour
{
    private float v = 15.0f;
    private float min = 0.0f;
    private float max = 35.0f;
    private float x = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        var deltaTime = Time.deltaTime;
        var x1 = x + v * deltaTime;

        if (x1 > max || x1 < min)
        {
            v = v * -1;
        }
        x = x + v * deltaTime;

        transform.localRotation = Quaternion.AngleAxis(x, Vector3.right);
    }
}
