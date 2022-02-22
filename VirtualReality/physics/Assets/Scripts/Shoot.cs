using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float power;
    public float shootDelay;
    public GameObject projectile;
    public Transform shootingPoint;
    public AudioSource cannonShotAudioSource;

    private float lastShotTime = 0;

    private void Start()
    {
        this.lastShotTime = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(Time.time - this.lastShotTime) >= this.shootDelay)
        {
            this.ShootProjectile();
            this.lastShotTime = Time.time;
        }
    }

    private void ShootProjectile()
    {
        GameObject cannonball = Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        Rigidbody cannonball_rb = cannonball.GetComponent<Rigidbody>();
        var rand = new System.Random();
        float powerShoot = (float)rand.NextDouble();
        powerShoot = 1.2F;
        cannonball_rb.AddForce(Vector3.left * power * powerShoot);

        var particle_systems = this.GetComponentsInChildren<ParticleSystem>();
        foreach (var particle_system in particle_systems)
        {
            particle_system.Play();
        }
        this.cannonShotAudioSource.Play();
    }
}
