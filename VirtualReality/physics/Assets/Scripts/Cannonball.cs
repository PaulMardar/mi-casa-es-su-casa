using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadius;
    public float despawnTime;

    private bool alreadyImpacted = false;

    private void Start()
    {
        Destroy(this.gameObject, despawnTime);
    }

    private void Explode()
    {
        Collider[] colisions = Physics.OverlapSphere(this.transform.position, this.explosionRadius);

        foreach (Collider hit in colisions)
        {
            Rigidbody hit_rb = hit.GetComponent<Rigidbody>();
            if (hit_rb)
            {
                hit_rb.AddExplosionForce(this.explosionForce, this.transform.position, this.explosionRadius, 0.0f, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!alreadyImpacted)
        {
            this.Explode();
            alreadyImpacted = true;
        }
    }
}
