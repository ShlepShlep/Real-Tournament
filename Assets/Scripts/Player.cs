using UnityEngine;

public class Player : MonoBehaviour
{
	Health health;
	public Weapon weapon;

	void Start()
	{
		
	}

    void Update()
    {
		health = GetComponent<Health>();
		// manual mode
		if (!weapon.isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
		{
			weapon.Shoot();
		}

		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			weapon.onRightClick.Invoke();
		}

		// auto mode
		if (weapon.isAutoFire && Input.GetKey(KeyCode.Mouse0))
		{
			weapon.Shoot();
		}

		if (Input.GetKeyDown(KeyCode.R) && weapon.ammo < weapon.maxAmmo)
		{
			weapon.Reload();
		}

		weapon.fireCooldown -= Time.deltaTime;
	}

    void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Enemy"))
		{
			health.Damage(10);
		}
	}
}