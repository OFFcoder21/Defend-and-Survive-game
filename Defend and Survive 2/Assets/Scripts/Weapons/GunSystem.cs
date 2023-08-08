using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    //public CamShake camShake;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;

    //Sound
    public AudioClip fireSound;
    private AudioSource audioSource;

    Enemy_1 Enemy_1;
    Enemy_2 Enemy_2;
    Enemy_3 Enemy_3;
    //[SerializeField] LineRenderer lineRend;

    //private PlayerInput _playerInput;

    private bool m_Pressed;
    private bool m_Released;

    //UI
    public TextMeshProUGUI bulletleftText;

    //variables for shop system
    public int weaponID;


    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Start()
    {
        // _playerInput = GetComponent<PlayerInput>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        MyInput();

        //SetText
        //text.SetText(bulletsLeft + " / " + magazineSize);
        

    }


    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Mouse.current.leftButton.isPressed;
        }
        else shooting = Mouse.current.leftButton.wasPressedThisFrame;
     
        if (Keyboard.current.rKey.wasPressedThisFrame && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;
        Debug.Log("fire");
        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            /*lineRend.enabled = true;
            lineRend.SetPosition(0, direction);*/
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy_2"))
            {
                rayHit.collider.GetComponent<Enemy_2>().TakeDamage(damage);
                Debug.Log("Shot");
            }
            else if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<Enemy_1>().TakeDamage(damage);
            }
            else if (rayHit.collider.CompareTag("Enemy_3"))
            {
                rayHit.collider.GetComponent<Enemy_3>().TakeDamage(damage);
            }
            else if (rayHit.collider.CompareTag("E3_child"))
            {
                rayHit.collider.GetComponent<E3_child>().TakeDamage(damage);
            }
        }

        //ShakeCamera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        audioSource.PlayOneShot(fireSound);
        bulletsLeft--;
        bulletleftText.text = bulletsLeft.ToString();//GLITCH: the number doesnt reset on reload immediately FIXED
        bulletsShot--;
        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        bulletleftText.text = magazineSize.ToString();
        reloading = false;
    }
}
