using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    //public GameObject bullet;
    public Transform camera1;// fpc camera
    public Transform metalHit;// texture of holes from bullets
    public Transform MetalSparks;// sparks from bullet
    public Transform MuzzleFlash;// fire shoot
    public Light Light;// light when shoot
    private RaycastHit Hit;// raycast ray
    public float RateOfSpeed = 0.5f;// rate of shoot
    private float _rateofSpeed;
    public int curAmmo = 0;// curent ammo
    public int maxAmmo = 12;// max ammo
    public int inventoryAmmo = 24;// ammo in inventory
    private float timeout = 0.2f;// timer
    public AudioClip Shoot;   // audio
    public AudioClip Reloaded;//
    public AudioClip emptyMagSound;//
    public float Accuracy = 0.01f;//accuracy of bullets
    public Text bulletGUI;// text which shows the current ammo
    public int svumode;//animation mode
    private float svureload;
    public int damage;// robots damage
    public AnimationClip _Idle;    //
    public AnimationClip _Reload;  //
    public AnimationClip _Shoot;   // Animations
    public AnimationClip _AimOn;   //
    public AnimationClip _AimOff;  //
    public AnimationClip _AimShoot;//
    public AnimationClip _AimIdle; //
    
    string _idle_;
    string _reload_;
    string _shoot_;
    string _aimon_;
    string _aimoff_;
    string _aimshoot_;
    string _aimidle_;
    public bool aim;// can aim

    void Start() {
        inventoryAmmo = LevelManager.GetInventoryAmmo();
        curAmmo = LevelManager.GetMagazineAmmo();
    }

    void Update() {
        _idle_ = _Idle.name;
        _reload_ = _Reload.name;
        _shoot_ = _Shoot.name;
        _aimon_ = _AimOn.name;
        _aimidle_ = _AimIdle.name;
        _aimoff_ = _AimOff.name;
        _aimshoot_ = _AimShoot.name;

        if (svumode == 0) {
            GetComponent<Animation>().CrossFade(_idle_);
        }

        if (svumode == 1) {
            GetComponent<Animation>().Play(_aimon_);
            svumode = 3;
        }

        if (svumode == 2) {
            GetComponent<Animation>().Play(_aimoff_);
            svumode = 0;
        }

        if (svumode == 3) {
            GetComponent<Animation>().CrossFade(_aimidle_);
        }

        if (svumode == 4) {

            GetComponent<Animation>().CrossFade(_reload_);// reload animation
            svureload += Time.deltaTime;
        }
        if (svureload >= GetComponent<Animation>()[_reload_].length)// if end animation
        {
            Reload();
            svumode = 0;// animation mode
            svureload = 0;
        }

        if (_rateofSpeed <= RateOfSpeed)//rate of shoot
        {
            _rateofSpeed += Time.deltaTime;
        }
        if (timeout < 0.1f)// light timer
        {
            timeout += Time.deltaTime;
            Light.range = 15;
        }
        else
        {
            Light.range = 0;
        }

        if (Input.GetButtonDown("Aim") && aim == false & svumode == 0)// if aim on
        {
            svumode = 1;// animation mode
            camera1.GetComponent<Camera>().fieldOfView = 30;// camera depth = 30
            aim = true;
        }
        else
			if (Input.GetButtonDown("Aim") && aim == true)
        {
            svumode = 2;// animation mode
            camera1.GetComponent<Camera>().fieldOfView = 60;// camera depth = 60
          	aim = false;
			}
        

        if (Input.GetButtonDown("Attack") & _rateofSpeed > RateOfSpeed & (svumode == 0 || svumode == 3) & curAmmo > 0)// if shoot
        {
            //Instantiate(bullet, transform);
            timeout = 0;
            GetComponent<AudioSource>().PlayOneShot(Shoot);// play audio
            if (aim == true)
            {
                GetComponent<Animation>().Play(_aimshoot_);// aim shoot animation
            }
            else
            {
                GetComponent<Animation>().Play(_shoot_);// shoot animation
            }

            Vector3 Direction = camera1.TransformDirection(Vector3.forward + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy), 0));//accuracy of bullet
            curAmmo -= 1;//ammo consumption
            _rateofSpeed = 0;
            MuzzleFlash.GetComponent<ParticleEmitter>().emit = true;

            if (Physics.Raycast(camera1.position, Direction, out Hit, 10000f))
            {
                if (Hit.collider.CompareTag("Zombie"))
                {
                    Hit.collider.gameObject.GetComponent<Zombie>().ReduceHealth();
                    //Hit.transform.GetComponent<Rigidbody>().AddForce(Direction * 400);// object push
                }
            }
        }
        else
        {
            MuzzleFlash.GetComponent<ParticleEmitter>().emit = false;
        }
        if(Input.GetButtonDown("Attack")  && curAmmo == 0) {
            GetComponent<AudioSource>().PlayOneShot(emptyMagSound, 0.7f);
        }
		if (Input.GetButtonDown("Reload") & inventoryAmmo > 0 & curAmmo != maxAmmo & svureload == 0)// if reload
        {
            camera1.GetComponent<Camera>().fieldOfView = 60;//
            aim = false;// aim off                      
            GetComponent<AudioSource>().PlayOneShot(Reloaded, 0.7f);// play audio
            svumode = 4;// animation mode
        }
    }

    public void Reload()//ammo calculation
    {

        if (inventoryAmmo < maxAmmo - curAmmo)
        {

            curAmmo += inventoryAmmo;
            inventoryAmmo = 0;
        }
        else
        {
            inventoryAmmo -= maxAmmo - curAmmo;
            curAmmo += maxAmmo - curAmmo;
        }
    }
    void OnGUI()//draw current ammo
    {

        bulletGUI.text = "" + curAmmo + "/" + inventoryAmmo;
    }

    public int GetMagazineAmmo() {
        return curAmmo;
    }

    public int GetInventoryAmmo() {
        return inventoryAmmo;
    }
}