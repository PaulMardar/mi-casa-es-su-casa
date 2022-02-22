using UnityEngine;

public class MoveLeftLeg : MonoBehaviour
{
    private float v = 5.0f;
    private float min = -2.0f;
    private float max = 20.0f;
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

        transform.localRotation = Quaternion.AngleAxis(x, Vector3.right);
    }
}
