using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public partial class KarakterHareket : MonoBehaviour
{
    public float yatayhareket;
    public int harekethizi;
    public float ziplamahizi;
    public int ziplamahakki;
    public bool karakteryerde;
    public bool faceright = true;
    private Rigidbody2D rb;
    public int canSayisi;
    private float time = 0f;
    public GameObject[] can;
    public int maxCan;
    public GameObject mermi;
    public Transform atesNoktasi;
    private float atisHizi;
    private float atesSayac;
    private Animator anim;
    public float animTime;
    public AudioSource audioSourceHurt;
    public AudioClip audioClipHurt;
    private bool ziplamaReset;
    public bool ziplayabilir;
    // Zıplatan zemin / upperFloor teması Update'te doğrudan fizikten sorgulanıyor:
    // OnCollisionStay2D, Rigidbody2D uyuduğunda (karakter zeminde beklerken) çalışmayı
    // bırakıyor, GetContacts ise uyuyan gövdede de temasları döndürüyor.
    private readonly ContactPoint2D[] temasNoktalari = new ContactPoint2D[16];
    // Level6 maze bolgesi: shadowFloor zeminlerinden hesaplaniyor, boylece arka planin
    // siyah kalmasi mazeEnter tetigine bagli olmuyor.
    private Bounds mazeBolgesi;
    private bool mazeBolgesiVar;
    private Color mazeDisiArkaPlan = Color.black;
    public GameObject globalLight;
    public GameObject pointLight;
    public GameObject shootInfo;
    public GameObject floorInfo;
    private PlayableDirector playableDirector;
    public bool atesEt;
    private float timeline;
    public bool noSwitch;
    public AudioSource audioSourceShoot;
    public AudioClip audioClipShoot;
    public AudioSource audioSourceHeal;
    public AudioClip audioClipHeal;
    private AudioSource audioSourceLevel1;
    private bool canJump;
    public GameObject trainingTextShoot;
    public GameObject trainingTextClimb;
    public Camera cam;
    private AudioSource mazeMusic;
    public AudioClip mazeMusicClip;
    public Animator cinemachine;
    public GameObject warningText;
    public Text stage1;
    public Text stage2;
    public Text stage3;
    public Text stage4;
    public Text stage5;
    public Text downInfo;
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public GameObject background4;
    public GameObject speechCanvas;
    public int changeSpeed = 0;
    private PlayableDirector cruelSunTimeline;
    private int hit = 0;
    public GameObject authoryDialogue;
    public GameObject laviniaDialogue;
    private CinemachineVirtualCamera movingCam;
    public bool rotateFloor = false;
    public GameObject characterCanvas;
    public GameObject nevoksa;
    public GameObject ahmettny;
    public GameObject ahmettnyFake;
    public GameObject authory;
    public GameObject garou;
    public GameObject darkGarou;
    private PlayableDirector playableDirector1;
    private PlayableDirector playableDirector2;
    private PlayableDirector playableDirector3;
    private PlayableDirector playableDirector4a;
    private PlayableDirector playableDirector4b;
    private PlayableDirector playableDirector5;
    public GameObject earth;
    public GameObject escanor;
    public GameObject erina;
    public GameObject erinaFake;
    public GameObject ahmettnyHealthCanvas;
    public GameObject erinaHealthCanvas;
    public GameObject garouHealthCanvas;
    public GameObject darkGarouHealthCanvas;
    public GameObject authoryHealthCanvas;
    public GameObject nevoksaHealthCanvas;
    public GameObject lavinia;
    public GameObject finalFloor;
    public GameObject finishFloor;
    public GameObject level9Part2;
    public GameObject karakter;
    public GameObject fireball;
    public bool karakterTurn = false;
    public GameObject star;
    public GameObject starText;
    public GameObject canlar;
    public AudioSource music1;
    public AudioSource music2;
    public AudioSource music3;
    private bool firstTime = true;
    private bool rightHand;
    public GameObject baton;
    public GameObject level9Sensor1;
    public GameObject level9Sensor2;
    public GameObject textFight1;
    public GameObject textFight2;
    private GameObject borderRight;
    public GameObject border1;
    public GameObject border2;
    public GameObject skipButton;
    private AudioSource fart;
    private AudioSource secretMusic;
    // Aktif sahnenin adi; her karede SceneManager'a sormak yerine bir kez okunur.
    // Karakter sahneyle birlikte yuklenip yok edildigi icin omru boyunca degismez.
    private string sahneAdi;

    void Awake()
    {
        sahneAdi = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        hit = 0;
        changeSpeed = 0;
        noSwitch = false;
        atesEt = true;
        firstTime = true;
        rb = GetComponent<Rigidbody2D>();
        ziplamahakki = 2;
        anim = GetComponent<Animator>();
        ziplamaReset = false;
        canJump = true;
        ziplayabilir = true;
        atisHizi = 2.4f;
        ziplamahakki = 8;
        Time.timeScale = 1;
        harekethizi = 10;

        if (gameObject.name != "Karakter")
        {
            karakterTurn = false;
        }
        else
        {
            karakterTurn = true;
        }

        if (sahneAdi != "Level5")
        {
            maxCan = 3;
            canSayisi = 3;
        }

        if (sahneAdi == "Level4")
        {
            playableDirector = GameObject.Find("Timeline").GetComponent<PlayableDirector>();
        }
        else if (sahneAdi == "Level6Pre")
        {
            playableDirector = GameObject.Find("nextSceneFiller").GetComponent<PlayableDirector>();
            audioSourceLevel1 = GameObject.Find("MusicAudio").GetComponent<AudioSource>();
        }
        else if (sahneAdi == "Level6")
        {
            Level6Start();
        }
        else if (sahneAdi == "Level8")
        {
            Level8Start();
        }
        else if (sahneAdi == "Level9")
        {
            Level9Start();
        }
    }

    void Update()
    {
        yatayhareket = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(yatayhareket * harekethizi, rb.linearVelocity.y);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && (karakteryerde == true || ziplamahakki > 0) && canJump)
        {
            //rb.AddForce(Vector2.up * ziplamahizi * 100);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, ziplamahizi);

            if (ZeminTemasVar("ziplatanzemin"))
            {
                rb.AddForce(150 * ziplamahizi * Vector2.up);
            }

            if (ZeminTemasVar("upperFloor"))
            {
                rb.AddForce(80 * ziplamahizi * Vector2.up);
            }

            karakteryerde = false;
            ziplamahakki--;
        }

        if (transform.localScale.x > 0)
        {
            faceright = true;
        }
        else if (transform.localScale.x < 0)
        {
            faceright = false;
        }

        if ((yatayhareket < 0 && faceright == false || yatayhareket > 0 && faceright == true) && gameObject.name != "erina" && gameObject.name != "ahmettny" && !karakterTurn)
        {
            Turn();
        }
        else if ((yatayhareket > 0 && faceright == false || yatayhareket < 0 && faceright == true) && (gameObject.name == "erina" || gameObject.name == "ahmettny" || karakterTurn))
        {
            Turn();
        }

        if (canSayisi <= 0)
        {
            Die();
            ScoreGenerator.yildizpuani_int = 0;
        }

        time -= Time.deltaTime;
        timeline -= Time.deltaTime;
        atesSayac -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && atesEt && (sahneAdi == "Level2" || sahneAdi == "Level3" || sahneAdi == "Level4" || sahneAdi == "Level5" || sahneAdi == "Training" || sahneAdi == "Level7" || sahneAdi == "Level9"))
        {
            if (atesSayac <= 0f && sahneAdi != "Level3" && sahneAdi != "Level5Pre")
            {
                AtesEt();
                atesSayac = 0.5f;
            }
        }

        animTime -= Time.deltaTime;

        if (ziplamaReset == true && animTime < 0)
        {
            ziplamahakki = 0;
            ziplamaReset = false;
        }

        if (sahneAdi == "Level6")
        {
            Level6Update();
        }
        else if (sahneAdi == "Level4")
        {
            if (timeline <= 0f)
            {
                harekethizi = 10;
                atesEt = true;
            }
            else
            {
                harekethizi = 0;
                atesEt = false;
            }
        }
        else if (sahneAdi == "Level5Pre")
        {
            harekethizi = 0;
            atesEt = false;
            noSwitch = true;
        }
        else if (sahneAdi == "Level7")
        {
            harekethizi = 12;
        }
        else if (sahneAdi == "Level8")
        {
            Level8Update();
        }
        else if (sahneAdi == "Level9")
        {
            Level9Update();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == null)
        {
            return;
        }

        if (collision.gameObject.CompareTag("ziplatanzemin"))
        {
            ziplamahakki = 1;
        }

        if (collision.gameObject.CompareTag("renklizemin"))
        {
            if (ziplayabilir)
            {
                ziplamahakki = 1;
            }
            else
            {
                ziplamahakki = 0;
            }

            ziplayabilir = false;
        }

        if (collision.gameObject.CompareTag("shadowFloor"))
        {
            pointLight.SetActive(true);
            // On shadow floors the world goes dark (only the character's flash lights the area).
            if (globalLight != null)
            {
                globalLight.SetActive(false);
            }
            //pointLight.intensity = 20;
            //pointLight.pointLightOuterRadius = 5;
            //pointLight.pointLightInnerRadius = 2;

            if (collision.gameObject.name == "lastFloor")
            {
                anim.SetTrigger("isLight");
            }
        }

        if (collision.gameObject.CompareTag("portal"))
        {
            if (collision.gameObject.name == "portal1")
            {
                transform.position = new Vector2(191, 15.5f);
            }

            if (collision.gameObject.name == "portal(Clone)" && ScoreGenerator.yildizpuani_int == 20)
            {
                transform.position = new Vector2(310, 16.2f);
                playableDirector.Play();
            }

            if (collision.gameObject.name == "beginningPortal" && ScoreGenerator.yildizpuani_int == 3)
            {
                GameObject.FindGameObjectWithTag("karakter").transform.position = new Vector3(408.5f, -5f, 0);
            }

            if (collision.gameObject.name == "lavaPortal" && ScoreGenerator.yildizpuani_int == 12)
            {
                GameObject.FindGameObjectWithTag("karakter").transform.position = new Vector3(906f, -11f, 0);
                changeSpeed = 2;
            }
        }

        if (collision.gameObject.CompareTag("zemin") && sahneAdi != "Level9")
        {
            pointLight.SetActive(false);
            // Back on normal ground: world lighting returns to normal.
            if (globalLight != null)
            {
                globalLight.SetActive(true);
            }
        }

        if (collision.gameObject.CompareTag("zemin") || collision.gameObject.CompareTag("fallenFloor") || collision.gameObject.CompareTag("upperFloor") || collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("shadowFloor") || collision.gameObject.CompareTag("bigEnemy") || collision.gameObject.CompareTag("rotatingFloor"))
        {
            karakteryerde = true;
            ziplayabilir = true;

            if (animTime < 0)
            {
                ziplamahakki = 2;
            }
        }

        if (collision.gameObject.CompareTag("rotatingFloor"))
        {
            rotateFloor = !rotateFloor;

            if (rotateFloor)
            {
                cinemachine.SetBool("rotate", true);
            }
            else
            {
                cinemachine.SetBool("rotate", true);
            }
        }

        if (collision.gameObject.CompareTag("elma"))
        {
            animTime = 15f;

            if (animTime >= 0)
            {
                anim.SetTrigger("godMode");
                ziplamahakki = 100;
                ziplamaReset = true;
            }
        }

        if (collision.gameObject.CompareTag("enemyBullet") || (collision.gameObject.tag == "characterBullet" && Shield.reverse))
        {
            if (time <= 0f)
            {
                CanAzalt();
                time = 1f;
            }
        }

        if (collision.gameObject.name == "mazeBorder")
        {
            if (ScoreGenerator.yildizpuani_int == 19)
            {
                Destroy(collision.gameObject);
                ScoreGenerator.yildizpuani_int = 0;
            }
            else if (warningText != null)
            {
                warningText.SetActive(true);
            }
        }

        Level8CollisionEnter(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == null)
        {
            return;
        }

        if (collision.gameObject.CompareTag("ates"))
        {
            if (time <= 0)
            {
                CanAzalt();
                time = 2f;
            }
        }

        if (collision.gameObject.CompareTag("upperFloor"))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
            else
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }

        if (collision.gameObject.CompareTag("lava"))
        {
            if (time <= 0)
            {
                CanAzalt();
                time = 1f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == null)
        {
            return;
        }

        if (collision.gameObject.name == "allowShoot")
        {
            shootInfo.SetActive(false);
        }

        if (collision.gameObject.name == "floorSensor")
        {
            floorInfo.SetActive(false);
        }

        if (collision.gameObject.name == "sensor1" && sahneAdi == "Training")
        {
            trainingTextShoot.SetActive(false);
        }

        if (collision.gameObject.name == "sensor2" && sahneAdi == "Training")
        {
            trainingTextClimb.SetActive(false);
        }

        Level7TriggerExit(collision);


        if (collision.gameObject.CompareTag("fallenFloor"))
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }

        Level8TriggerExit(collision);
    }

    public static void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CanAzalt()
    {
        canSayisi--;
        anim.SetTrigger("isDamaged");
        audioSourceHurt.PlayOneShot(audioClipHurt);

        if (canSayisi >= 0 && canSayisi < can.Length)
        {
            can[canSayisi].SetActive(false);
        }
    }

    void Turn()
    {
        if (!noSwitch)
        {
            faceright = !faceright;
            Vector2 yeniscale = transform.localScale;
            yeniscale.x *= -1;
            transform.localScale = yeniscale;
            atisHizi *= -1;

            if (sahneAdi == "Level4")
            {
                Vector2 canvas = speechCanvas.transform.localScale;
                canvas.x *= -1;
                speechCanvas.transform.localScale = canvas;
            }

            if (sahneAdi == "Level9")
            {
                Vector2 karakterTextScale = characterCanvas.transform.localScale;
                karakterTextScale.x *= -1;
                characterCanvas.transform.localScale = karakterTextScale;
            }

            if (gameObject.name == "erina")
            {
                if (faceright)
                {
                    Vector3 batonPos = baton.transform.position;
                    batonPos.x -= 3.5f;
                    baton.transform.position = batonPos;
                }
                else
                {
                    Vector3 batonPos = baton.transform.position;
                    batonPos.x += 3.5f;
                    baton.transform.position = batonPos;
                }
            }
        }
    }

    public void AtesEt()
    {
        GameObject mermiPrefab = Instantiate(mermi, atesNoktasi.position, atesNoktasi.rotation);
        mermiPrefab.GetComponent<MermiHareket>().vec = new Vector2(atisHizi, 0);
        audioSourceShoot.PlayOneShot(audioClipShoot);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == null)
        {
            return;
        }

        if (collision.gameObject.CompareTag("kalp"))
        {
            if (maxCan > canSayisi)
            {
                Destroy(collision.gameObject);
                canSayisi++;
                anim.SetTrigger("getHealth");

                for (int i = 0; i < canSayisi; i++)
                {
                    can[i].SetActive(true);
                }

                audioSourceHeal.PlayOneShot(audioClipHeal);
            }
        }

        if (collision.gameObject.name == "friendSensor")
        {
            if (sahneAdi == "Level4" && timeline <= 0f)
            {
                timeline = 10f;
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.name == "allowShoot")
        {
            shootInfo.SetActive(true);
        }

        if (collision.gameObject.name == "floorSensor")
        {
            floorInfo.SetActive(true);
        }

        if (collision.gameObject.CompareTag("water") || collision.gameObject.CompareTag("lava"))
        {
            karakteryerde = true;
            ziplayabilir = true;

            if (animTime < 0)
            {
                ziplamahakki = 2;
            }
        }

        if (collision.gameObject.name == "areaUp")
        {
            ziplamahizi = 20;
        }

        if (collision.gameObject.name == "nextSceneFiller")
        {
            playableDirector.Play();
            audioSourceLevel1.Stop();
            harekethizi = 0;
        }

        if (collision.gameObject.name == "sensor1" && sahneAdi == "Training")
        {
            trainingTextShoot.SetActive(true);
        }

        if (collision.gameObject.name == "sensor2" && sahneAdi == "Training")
        {
            trainingTextClimb.SetActive(true);
        }

        if (collision.gameObject.name == "nextSceneFiller" && sahneAdi == "Level6Pre")
        {
            harekethizi = 0;
        }

        if (collision.gameObject.name == "sensor8")
        {
            ziplamahizi = 15;
            harekethizi = 15;
        }

        Level6TriggerEnter(collision);

        Level7TriggerEnter(collision);


        if (sahneAdi == "Level8")
        {
            Level8TriggerEnter(collision);
        }
        else if (sahneAdi == "Level9")
        {
            Level9TriggerEnter(collision);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == null)
        {
            return;
        }

        if (collision.gameObject.CompareTag("ates"))
        {
            if (time <= 0)
            {
                CanAzalt();
                time = 2f;
            }
        }

        if (collision.gameObject.CompareTag("ziplatanzemin"))
        {
            ziplamahakki = 1;
        }

        if (collision.gameObject.CompareTag("upperFloor"))
        {
            ziplamahakki = 1;
        }


        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.tag == "bigEnemy" || collision.gameObject.CompareTag("superEnemy") || collision.gameObject.CompareTag("jumperEnemy") || collision.gameObject.CompareTag("heraclus"))
        {
            if (time <= 0f)
            {
                CanAzalt();
                time = 1f;
            }
        }

        if (collision.gameObject.CompareTag("fallenFloor"))
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == null)
        {
            return;
        }

        if (collision.gameObject.name == "mazeBorder" && warningText != null)
        {
            warningText.SetActive(false);
        }

        // Leaving a shadow floor closes the "flash": the point light turns off and the
        // global light returns, so shadow-floor grounds go back to normal even if the
        // player jumps off into the air instead of onto a normal floor.
        if (collision.gameObject.CompareTag("shadowFloor"))
        {
            pointLight.SetActive(false);
            if (globalLight != null)
            {
                globalLight.SetActive(true);
            }
        }
    }

    // Karakterin şu an verilen etikete sahip bir zemine değip değmediğini fizikten sorgular.

    private bool ZeminTemasVar(string etiket)
    {
        int temasSayisi = rb.GetContacts(temasNoktalari);

        for (int i = 0; i < temasSayisi; i++)
        {
            Collider2D temasCollider = temasNoktalari[i].collider;

            if (temasCollider != null && temasCollider.CompareTag(etiket))
            {
                return true;
            }
        }

        return false;
    }


}
