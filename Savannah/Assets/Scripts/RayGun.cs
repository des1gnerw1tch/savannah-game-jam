using UnityEngine;
using System.Collections;
using TMPro;


public class RayGun : MonoBehaviour
{
    [Header("References")]
    public Transform gun_end;
    public Camera playerCamera;
    public ParticleSystem muzzleFlash;
    public TMP_Text ammoText;
    public GameObject burnMarkPrefab;

    [Header("Gun Settings")]
    [SerializeField] private int dmg = 1;
    public float laserRange = 100f;
    public float fireRate = 0.2f; // seconds between shots
    public float reloadTime = 2f; // seconds to reload
    public int maxAmmo = 10;

    private int currentAmmo;
    private float fireTimer = 0f;
    private bool isReloading = false;

    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoText();
    }

    void Update()
    {
        if (isReloading) return;

        fireTimer += Time.deltaTime;

        // Reload when out of ammo
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        // Fire when button pressed and cooldown elapsed
        if (Input.GetMouseButtonDown(0) && fireTimer >= fireRate)
        {
            ShootRay();
            fireTimer = 0f;
        }
    }

    private void ShootRay()
    {
        currentAmmo--;
        UpdateAmmoText();
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, laserRange))
        {
            Debug.Log("Hit: " + hit.transform.name);

            if (burnMarkPrefab != null)
            {
                Vector3 spawnPos = hit.point + hit.normal * 0.002f;

                // Create burn mark and align it with the surface
                Quaternion rotation = Quaternion.LookRotation(hit.normal);
                GameObject burn = Instantiate(burnMarkPrefab, spawnPos, rotation);
                burn.transform.localScale = Vector3.one * 0.1f;
                // Optionally, make it a child of the hit object so it moves with it
                burn.transform.SetParent(hit.transform);

                // Optionally destroy after a few seconds
                Debug.Log("Burn mark spawned at: " + spawnPos);
                //Destroy(burn, 10f);
            }

            ShootableTarget target = hit.transform.GetComponent<ShootableTarget>();
            if (hit.transform.CompareTag("target") && target != null)
            {
                target.TakeDamage(dmg);
            }
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        ammoText.text = "Reloading...";
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Reload complete!");
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        ammoText.text = $"Ammo: {currentAmmo}/{maxAmmo}";
    }
}
