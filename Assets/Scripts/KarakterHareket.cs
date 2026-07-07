using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class KarakterHareket : MonoBehaviour
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

        if (SceneManager.GetActiveScene().name != "Level5")
        {
            maxCan = 3;
            canSayisi = 3;
        }

        if (SceneManager.GetActiveScene().name == "Level4")
        {
            playableDirector = GameObject.Find("Timeline").GetComponent<PlayableDirector>();
        }
        else if (SceneManager.GetActiveScene().name == "Level6Pre")
        {
            playableDirector = GameObject.Find("nextSceneFiller").GetComponent<PlayableDirector>();
            audioSourceLevel1 = GameObject.Find("MusicAudio").GetComponent<AudioSource>();
        }
        else if (SceneManager.GetActiveScene().name == "Level6")
        {
            harekethizi = 14;
            ziplamahizi = 16;
            gameObject.transform.position = new Vector3(513.5f, 36, 0);
            mazeMusic = GameObject.Find("Music").GetComponent<AudioSource>();
        }
        else if (SceneManager.GetActiveScene().name == "Level8")
        {
            InvokeRepeating(nameof(Shake), 5f, 5f);
            gameObject.transform.position = new Vector3(-11.5f, -1.1f, 0f);
            cruelSunTimeline = GameObject.Find("TimelineCruelSun").GetComponent<PlayableDirector>();
            movingCam = GameObject.FindGameObjectWithTag("moveCamera").GetComponent<CinemachineVirtualCamera>();
            fart = GameObject.Find("Fart").GetComponent<AudioSource>();
            secretMusic = GameObject.Find("SecretMusic").GetComponent<AudioSource>();
        }
        else if (SceneManager.GetActiveScene().name == "Level9")
        {
            borderRight = GameObject.Find("borderRight");
            movingCam = GameObject.FindGameObjectWithTag("moveCamera").GetComponent<CinemachineVirtualCamera>();

            if (PlayerPrefs.HasKey("level9Progress"))
            {
                PlayerPrefs.GetInt("level9Progress");

                if (PlayerPrefs.GetInt("level9Progress") == 0 && gameObject.name == "nevoksa")
                {
                    nevoksa.transform.position = new Vector3(0, 0, 0);
                    music1.Play();
                }
                else if (PlayerPrefs.GetInt("level9Progress") == 1 && gameObject.name == "nevoksa")
                {
                    Destroy(GameObject.Find("step1"));
                    Destroy(GameObject.Find("step2"));
                    authoryHealthCanvas.SetActive(false);
                    ahmettnyHealthCanvas.SetActive(false);
                    transform.position = new Vector3(105, 6.3f, 0);
                    movingCam.Follow = nevoksa.transform;
                    movingCam.LookAt = nevoksa.transform;
                    Destroy(borderRight);
                    Destroy(authory);
                    ahmettny.SetActive(false);
                    earth.SetActive(false);
                    music1.Play();
                }
                else if (PlayerPrefs.GetInt("level9Progress") == 2)
                {
                    karakter.SetActive(true);
                    ahmettnyFake.SetActive(true);
                    Destroy(GameObject.Find("step1"));
                    Destroy(GameObject.Find("step2"));
                    Destroy(GameObject.Find("step3"));
                    Destroy(GameObject.Find("step4"));
                    Destroy(GameObject.Find("lastStep"));
                    authoryHealthCanvas.SetActive(false);
                    ahmettnyHealthCanvas.SetActive(false);
                    garouHealthCanvas.SetActive(false);
                    erinaHealthCanvas.SetActive(false);
                    Destroy(borderRight);
                    movingCam.Follow = karakter.transform;
                    movingCam.LookAt = karakter.transform;
                    karakter.transform.position = new Vector3(0, 0, 0);
                    nevoksa.SetActive(false);
                    Destroy(authory);
                    erina.SetActive(false);
                    ahmettny.SetActive(false);
                    music3.Play();
                    finishFloor.SetActive(true);
                    finalFloor.SetActive(false);
                    level9Part2.SetActive(true);
                    star.SetActive(true);
                    Destroy(border1);
                    Destroy(border2);
                    starText.SetActive(true);
                    canlar.SetActive(true);
                    Sword.erinavsgarou = 6;
                }
            }
            else if (!PlayerPrefs.HasKey("level9Progress"))
            {
                if (gameObject.name == "nevoksa")
                {
                    nevoksa.transform.position = new Vector3(0, 0, 0);
                    music1.Play();
                }
            }

            if (gameObject.name == "nevoksa")
            {
                erina.SetActive(false);
            }

            if (gameObject.name == "ahmettny")
            {
                nevoksa.SetActive(false);
                erina.SetActive(false);
            }

            if (gameObject.name == "erina")
            {
                nevoksa.SetActive(false);
                ahmettny.SetActive(false);
            }

            erinaFake.SetActive(true);
            garou.SetActive(true);

            if (gameObject.name != "Karakter")
            {
                darkGarou.SetActive(false);
                atesEt = false;
            }
            else
            {
                atesEt = true;
                nevoksa.SetActive(false);
                ahmettny.SetActive(false);
                erina.SetActive(false);
            }

            escanor.SetActive(true);
            background1.SetActive(true);
            cam.gameObject.SetActive(true);
            movingCam.gameObject.SetActive(true);
            playableDirector1 = GameObject.Find("Timeline1").GetComponent<PlayableDirector>();
            playableDirector2 = GameObject.Find("Timeline2").GetComponent<PlayableDirector>();
            playableDirector3 = GameObject.Find("Timeline3").GetComponent<PlayableDirector>();
            playableDirector4a = GameObject.Find("Timeline4a").GetComponent<PlayableDirector>();
            playableDirector4b = GameObject.Find("Timeline4b").GetComponent<PlayableDirector>();
            playableDirector5 = GameObject.Find("Timeline5").GetComponent<PlayableDirector>();
            //fireball.SetActive(false);
            rightHand = true;
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

        if (Input.GetKeyDown(KeyCode.F) && atesEt && (SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3" || SceneManager.GetActiveScene().name == "Level4" || SceneManager.GetActiveScene().name == "Level5" || SceneManager.GetActiveScene().name == "Training" || SceneManager.GetActiveScene().name == "Level7" || SceneManager.GetActiveScene().name == "Level9"))
        {
            if (atesSayac <= 0f && SceneManager.GetActiveScene().name != "Level3" && SceneManager.GetActiveScene().name != "Level5Pre")
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

        if (SceneManager.GetActiveScene().name == "Level4")
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
        else if (SceneManager.GetActiveScene().name == "Level5Pre")
        {
            harekethizi = 0;
            atesEt = false;
            noSwitch = true;
        }
        else if (SceneManager.GetActiveScene().name == "Level7")
        {
            harekethizi = 12;
        }
        else if (SceneManager.GetActiveScene().name == "Level8")
        {
            harekethizi = 12;

            if (changeSpeed == 0)
            {
                ziplamahizi = 10;
            }

            else if (changeSpeed == 1)
            {
                ziplamahizi = 12;
            }

            else if (changeSpeed == 2)
            {
                ziplamahizi = 15;
            }

            if (cruelSunTimeline.time >= 14.9f)
            {
                cinemachine.SetBool("cruelSun", false);
                GameObject.Find("lavaPass").GetComponent<BoxCollider2D>().isTrigger = true;
            }

        }
        else if (SceneManager.GetActiveScene().name == "Level9")
        {
            if (playableDirector1.time >= 4.9f && GameObject.Find("step2"))
            {
                background1.SetActive(false);
                background3.SetActive(true);

                if (PlayerPrefs.GetInt("level9Progress") == 0)
                {
                    skipButton.SetActive(true);
                }
            }

            if (playableDirector1.time >= 41.9f && GameObject.Find("step2"))
            {
                background3.SetActive(false);
                background2.SetActive(true);
                skipButton.SetActive(false);
            }

            if (!GameObject.Find("authory") && GameObject.Find("step3"))
            {
                nevoksa.SetActive(true);
                movingCam.Follow = nevoksa.transform;
                movingCam.LookAt = nevoksa.transform;
                background3.SetActive(false);
                background1.SetActive(true);
                authoryHealthCanvas.SetActive(false);
                ahmettnyHealthCanvas.SetActive(false);
                Destroy(borderRight);
                PlayerPrefs.SetInt("level9Progress", 1);
            }

            if (Sword.erinavsgarou == 1 && !GameObject.Find("step4"))
            {
                nevoksa.SetActive(true);
                erina.SetActive(false);
                escanor.SetActive(true);
                lavinia.SetActive(true);
                erinaFake.SetActive(true);
                garouHealthCanvas.SetActive(false);
                erinaHealthCanvas.SetActive(false);

                if (gameObject.name == "nevoksa")
                {
                    ziplamahizi = 8;
                    harekethizi = 10;
                    noSwitch = false;
                }

                if (Sword.garouHealth <= 0)
                {
                    movingCam.Follow = erinaFake.transform;
                    movingCam.LookAt = erinaFake.transform;
                    playableDirector4a.Play();
                }

                else if (Sword.erinaHealth <= 0)
                {
                    movingCam.Follow = nevoksa.transform;
                    movingCam.LookAt = nevoksa.transform;
                    playableDirector4b.Play();
                }

                cinemachine.SetBool("level9tl3", true);
                Sword.erinavsgarou = 2;
            }

            if (playableDirector2.time >= 4.9f && GameObject.Find("step4") && PlayerPrefs.GetInt("level9Progress") == 1)
            {
                skipButton.SetActive(true);
            }

            if (playableDirector2.time >= 101.4f && GameObject.Find("step4"))
            {
                escanor.SetActive(false);
                erinaFake.SetActive(false);
                background1.SetActive(false);
                background2.SetActive(true);
                skipButton.SetActive(false);
            }

            if (playableDirector3.time >= 29.9f && Sword.erinavsgarou == 0)
            {
                erina.SetActive(true);
                garou.SetActive(true);
                nevoksa.SetActive(false);
                escanor.SetActive(false);
                lavinia.SetActive(false);
                erinaFake.SetActive(false);
                erinaHealthCanvas.SetActive(true);
                garouHealthCanvas.SetActive(true);
                movingCam.Follow = erina.transform;
                movingCam.LookAt = erina.transform;
                textFight2.SetActive(true);
                Destroy(textFight2, 3);
                Destroy(level9Sensor2, 1);
            }

            if (playableDirector4a.time >= 24.9f)
            {
                nevoksa.SetActive(true);
                movingCam.Follow = nevoksa.transform;
                movingCam.LookAt = nevoksa.transform;
                cinemachine.SetBool("level9tl3", false);
                Sword.erinavsgarou = 4;
            }
            else if (playableDirector4b.time >= 11.9f)
            {
                nevoksa.SetActive(true);
                garou.SetActive(false);
                darkGarou.SetActive(true);
                escanor.SetActive(false);
                erina.SetActive(false);
                erinaFake.SetActive(false);
                lavinia.SetActive(false);
                darkGarouHealthCanvas.SetActive(true);
                nevoksaHealthCanvas.SetActive(true);
                fireball.SetActive(true);
                cinemachine.SetBool("level9tl3", false);
                harekethizi = 10;
                ziplamahizi = 8;
                ziplamahakki = 2;
                noSwitch = false;
                Sword.erinavsgarou = 3;
            }

            if (Sword.erinavsgarou == 4)
            {
                nevoksa.SetActive(true);
                erina.SetActive(false);
                erinaFake.SetActive(false);
                garou.SetActive(false);
                escanor.SetActive(false);
                lavinia.SetActive(false);
                //fireball.SetActive(false);
                harekethizi = 10;
                ziplamahizi = 8;
                ziplamahakki = 2;
                noSwitch = false;
                Sword.erinavsgarou = 5;
            }

            if (MermiHareket.fire && gameObject.name == "nevoksa")
            {
                if (rightHand)
                {
                    Vector3 canvas = characterCanvas.transform.position;
                    Vector3 fire = new(1.5f, -1.9f, 0);
                    fireball.transform.position = canvas + fire;
                    MermiHareket.fire = false;
                }
                else
                {
                    Vector3 canvas = characterCanvas.transform.position;
                    Vector3 fire = new(-1.5f, -1.9f, 0);
                    fireball.transform.position = canvas + fire;
                    MermiHareket.fire = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.G) && gameObject.name == "nevoksa")
            {
                rightHand = !rightHand;
                MermiHareket.cMermiHiz *= -1;
            }

            if (Input.GetKeyUp(KeyCode.F) && gameObject.name == "nevoksa" && firstTime)
            {
                fireball.SetActive(true);
                firstTime = false;
            }

            if (playableDirector5.time >= 19.9f && Sword.erinavsgarou == 5)
            {
                karakter.SetActive(true);
                nevoksa.SetActive(false);
                background1.SetActive(true);
                finishFloor.SetActive(true);
                finalFloor.SetActive(false);
                level9Part2.SetActive(true);
                star.SetActive(true);
                starText.SetActive(true);
                canlar.SetActive(true);
                escanor.SetActive(true);
                erinaFake.SetActive(true);
                ahmettnyFake.SetActive(true);
                movingCam.LookAt = karakter.transform;
                movingCam.Follow = karakter.transform;
                harekethizi = 10;
                ziplamahizi = 8;
                ziplamahakki = 2;
                noSwitch = false;
                karakterTurn = true;
                atesEt = true;
                PlayerPrefs.SetInt("level9Progress", 2);
                Sword.erinavsgarou = 6;
            }

            if (GameObject.Find("Karakter"))
            {
                nevoksa.SetActive(false);
                erina.SetActive(false);
                ahmettny.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == null)
        {
            return;
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

        if (collision.gameObject.CompareTag("zemin") && SceneManager.GetActiveScene().name != "Level9")
        {
            pointLight.SetActive(false);
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
            else
            {
                warningText.SetActive(true);
            }
        }

        if (collision.gameObject.name == "Hit100times1")
        {
            hit++;

            if (hit >= 100)
            {
                Destroy(collision.gameObject);
                secretMusic.Play();
                GameObject.Find("Music").GetComponent<AudioSource>().Stop();
            }
        }

        if (collision.gameObject.name == "Hit100times2")
        {
            hit++;

            if (hit >= 200)
            {
                Destroy(collision.gameObject);
                fart.Play();
            }
        }
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

        if (collision.gameObject.name == "sensor1" && SceneManager.GetActiveScene().name == "Training")
        {
            trainingTextShoot.SetActive(false);
        }

        if (collision.gameObject.name == "sensor2" && SceneManager.GetActiveScene().name == "Training")
        {
            trainingTextClimb.SetActive(false);
        }

        if (collision.gameObject.name == "stage1")
        {
            stage1.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "stage2")
        {
            stage2.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "stage3")
        {
            stage3.gameObject.SetActive(false);
            downInfo.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "stage4")
        {
            stage4.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "stage5")
        {
            stage5.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("fallenFloor"))
        {
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }

        if (collision.gameObject.name == "sensorAuthory")
        {
            authoryDialogue.SetActive(false);
        }

        if (collision.gameObject.name == "sensorLavinia")
        {
            laviniaDialogue.SetActive(false);
        }
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

            if (SceneManager.GetActiveScene().name == "Level4")
            {
                Vector2 canvas = speechCanvas.transform.localScale;
                canvas.x *= -1;
                speechCanvas.transform.localScale = canvas;
            }

            if (SceneManager.GetActiveScene().name == "Level9")
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
            if (SceneManager.GetActiveScene().name == "Level4" && timeline <= 0f)
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

        if (collision.gameObject.name == "sensor1" && SceneManager.GetActiveScene().name == "Training")
        {
            trainingTextShoot.SetActive(true);
        }

        if (collision.gameObject.name == "sensor2" && SceneManager.GetActiveScene().name == "Training")
        {
            trainingTextClimb.SetActive(true);
        }

        if (collision.gameObject.name == "nextSceneFiller" && SceneManager.GetActiveScene().name == "Level6Pre")
        {
            harekethizi = 0;
        }

        if (collision.gameObject.name == "sensor8")
        {
            ziplamahizi = 15;
            harekethizi = 15;
        }

        if (collision.gameObject.name == "mazeEnter")
        {
            cam.backgroundColor = Color.black;
            mazeMusic.clip = mazeMusicClip;
            mazeMusic.Play();
            Destroy(collision.gameObject);
            cinemachine.SetBool("enlarge", false);
            cinemachine.SetBool("shrink", true);
        }

        if (collision.gameObject.name == "stage1")
        {
            stage1.gameObject.SetActive(true);
            ScoreGenerator.stageNumber_int = 1;
            PlayerPrefs.SetInt("stage", 1);
        }

        if (collision.gameObject.name == "stage2")
        {
            stage2.gameObject.SetActive(true);
            GameObject.Find("stage2StartBorder").GetComponent<BoxCollider2D>().isTrigger = false;
            ScoreGenerator.stageNumber_int = 2;
            PlayerPrefs.SetInt("stage", 2);
        }

        if (collision.gameObject.name == "stage3")
        {
            stage3.gameObject.SetActive(true);
            downInfo.gameObject.SetActive(true);
            GameObject.Find("stage3StartBorder").GetComponent<BoxCollider2D>().isTrigger = false;
            ScoreGenerator.stageNumber_int = 3;
            PlayerPrefs.SetInt("stage", 3);
        }

        if (collision.gameObject.name == "stage4")
        {
            stage4.gameObject.SetActive(true);
            GameObject.Find("stage4StartBorder").GetComponent<BoxCollider2D>().isTrigger = false;
            ScoreGenerator.stageNumber_int = 4;
            PlayerPrefs.SetInt("stage", 4);
        }

        if (collision.gameObject.name == "stage5")
        {
            stage5.gameObject.SetActive(true);
            GameObject.Find("stage5StartBorder").GetComponent<BoxCollider2D>().isTrigger = false;
            ScoreGenerator.stageNumber_int = 5;
            PlayerPrefs.SetInt("stage", 5);
        }

        if (collision.gameObject.name == "scoreDetector")
        {
            canSayisi = 3;
            ScoreGenerator.scorePoint_int = 0;

            for (int i = 0; i < canSayisi; i++)
            {
                can[i].SetActive(true);
            }

            if (collision.transform.parent.gameObject.name == "stage1")
            {
                ScoreGenerator.yildizpuani_int = 0;
            }
            else if (collision.transform.parent.gameObject.name == "stage2")
            {
                ScoreGenerator.yildizpuani_int = 7;
            }
            else if (collision.transform.parent.gameObject.name == "stage3")
            {
                ScoreGenerator.yildizpuani_int = 12;
            }
            else if (collision.transform.parent.gameObject.name == "stage4")
            {
                ScoreGenerator.yildizpuani_int = 20;
            }
            else if (collision.transform.parent.gameObject.name == "stage5")
            {
                ScoreGenerator.yildizpuani_int = 26;
            }

            Destroy(collision.gameObject);
        }

        if (SceneManager.GetActiveScene().name == "Level8")
        {
            if (collision.gameObject.name == "lavaSensor")
            {
                changeSpeed = 1;
                cruelSunTimeline.Play();
                cinemachine.SetBool("cruelSun", true);
            }
            else if (collision.gameObject.name == "sensorLava2")
            {
                changeSpeed = 0;
            }

            if (collision.gameObject.name == "sensorAuthory")
            {
                authoryDialogue.SetActive(true);
            }

            if (collision.gameObject.name == "sensorLavinia")
            {
                laviniaDialogue.SetActive(true);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level9")
        {
            if (collision.gameObject.name == "step1")
            {
                playableDirector1.Play();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "step2" && PlayerPrefs.GetInt("level9Progress") != 1)
            {
                if (gameObject.name == "nevoksa")
                {
                    ahmettny.SetActive(true);
                    gameObject.SetActive(false);
                }

                ahmettnyFake.SetActive(false);
                textFight1.SetActive(true);
                movingCam.Follow = ahmettny.transform;
                movingCam.LookAt = ahmettny.transform;
                earth.SetActive(true);
                background2.SetActive(false);
                background3.SetActive(true);
                Destroy(level9Sensor1, 1);
                Destroy(textFight1, 3);
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "step3")
            {
                erinaFake.SetActive(true);
                escanor.SetActive(true);
                playableDirector2.Play();
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "step4")
            {
                escanor.SetActive(true);
                erinaFake.SetActive(true);
                erina.SetActive(false);
                background2.SetActive(false);
                background4.SetActive(true);
                cinemachine.SetBool("level9tl3", true);
                music1.Stop();
                music2.Play();
                playableDirector3.Play();

                if (gameObject.name == "nevoksa")
                {
                    harekethizi = 0;
                    noSwitch = true;
                    ziplamahizi = 0;
                    gameObject.transform.position = new Vector3(326.5f, 29, 0);
                }

                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "lastStep")
            {
                music2.Stop();
                music3.Play();
                playableDirector5.Play();
                gameObject.transform.position = new Vector3(445, 74, 0);
                background4.SetActive(false);
                Destroy(collision.gameObject);
            }
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
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(150 * ziplamahizi * Vector2.up);
            }

            ziplamahakki = 1;
        }

        if (collision.gameObject.CompareTag("upperFloor"))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(80 * ziplamahizi * Vector2.up);
            }

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

        if (collision.gameObject.name == "mazeBorder")
        {
            warningText.SetActive(false);
        }

        // Leaving a shadow floor closes the "flash" light, so shadow-floor grounds return
        // to normal even if the player jumps off into the air instead of onto a normal floor.
        if (collision.gameObject.CompareTag("shadowFloor"))
        {
            pointLight.SetActive(false);
        }
    }

    public void Shake()
    {
        cinemachine.SetTrigger("shake");
    }

    //public void SkipButton()
    //{
    //    if (PlayerPrefs.GetInt("level9Progress") == 1)
    //    {
    //        playableDirector2.time = 101.4f;
    //    }

    //    skipButton.SetActive(false);
    //}

}
