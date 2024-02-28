using UnityEngine;

public class Player : MonoBehaviour
{
	Health health;
	public Weapon weapon;
	public LayerMask weaponLayer;
	public GameObject equipText;
	public Transform hand;

	void Start()
	{
		health = GetComponent<Health>();
	}

    void Update()
    {
		var cam = Camera.main.transform;
		var collided = Physics.Raycast(cam.position, cam.forward, out var hit, 2f, weaponLayer);
		equipText.SetActive(collided && weapon == null);

		if (Input.GetKeyDown(KeyCode.E))
		{
            if (weapon == null && collided)
            {
				weapon = hit.transform.GetComponent<Weapon>();
				Grab(weapon);
			}
            else
            {
				Drop();
            }
		}


		if (weapon == null) return;
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

	void Grab(Weapon newWeapon)
    {
		weapon = newWeapon;
		weapon.GetComponent<Rigidbody>().isKinematic = true;
		weapon.transform.position = hand.position;
		weapon.transform.rotation = hand.rotation;
		weapon.transform.parent = hand;
	}

	void Drop()
    {
		if (weapon == null) return;

		weapon.GetComponent<Rigidbody>().isKinematic = false;
		weapon.GetComponent<Rigidbody>().velocity = transform.forward * 5f;

		weapon.transform.parent = null;
		weapon = null;
	}
}