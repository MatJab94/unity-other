using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] KeyCode shootKey = KeyCode.Mouse0;

	void Awake()
	{
		if (bulletPrefab == null)
		{
			Debug.LogError("Bullet Prefab not found.", this);
			gameObject.SetActive(false);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(shootKey)) Shoot();
	}

	void Shoot()
	{
		Instantiate(bulletPrefab, transform.position, transform.rotation);
	}
}
