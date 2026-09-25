using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

// Level9 (final): kayitli ilerlemeye gore sahne kurulumu, timeline akisi, karakter
// degisimleri ve nevoksa'nin atesi.
public partial class KarakterHareket
{
    private void Level9Start()
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

    private void Level9Update()
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

    private void Level9TriggerEnter(Collider2D collision)
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

    //public void SkipButton()
    //{
    //    if (PlayerPrefs.GetInt("level9Progress") == 1)
    //    {
    //        playableDirector2.time = 101.4f;
    //    }

    //    skipButton.SetActive(false);
    //}
}
