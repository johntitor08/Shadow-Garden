using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;

public class MemoryScene : MonoBehaviour
{
    PlayableDirector playableDirector;
    PlayableDirector playableDirector2;
    PlayableDirector playableDirector3;
    PlayableDirector playableDirector4;
    PlayableDirector playableDirector5;
    PlayableDirector playableDirector6;
    PlayableDirector playableDirector7;
    PlayableDirector playableDirector8;
    PlayableDirector playableDirector9;
    PlayableDirector playableDirector10;
    PlayableDirector playableDirector10v2;
    PlayableDirector playableDirector11;
    PlayableDirector playableDirector12;
    PlayableDirector playableDirector13;
    PlayableDirector playableDirector14;
    PlayableDirector playableDirector15;
    Animator animatorG;
    Animator animatorM;
    void Start()
    {
        playableDirector = GameObject.Find("Timeline1").GetComponent<PlayableDirector>();
        playableDirector2 = GameObject.Find("Timeline2").GetComponent<PlayableDirector>();
        playableDirector3 = GameObject.Find("Timeline3").GetComponent<PlayableDirector>();
        playableDirector4 = GameObject.Find("Timeline4").GetComponent<PlayableDirector>();
        playableDirector5 = GameObject.Find("Timeline5").GetComponent<PlayableDirector>();
        playableDirector6 = GameObject.Find("Timeline6").GetComponent<PlayableDirector>();
        playableDirector7 = GameObject.Find("Timeline7").GetComponent<PlayableDirector>();
        playableDirector8 = GameObject.Find("Timeline8").GetComponent<PlayableDirector>();
        playableDirector9 = GameObject.Find("Timeline9").GetComponent<PlayableDirector>();
        playableDirector10 = GameObject.Find("Timeline10").GetComponent<PlayableDirector>();
        playableDirector10v2 = GameObject.Find("Timeline10.2").GetComponent<PlayableDirector>();
        playableDirector11 = GameObject.Find("Timeline11").GetComponent<PlayableDirector>();
        playableDirector12 = GameObject.Find("Timeline12").GetComponent<PlayableDirector>();
        playableDirector13 = GameObject.Find("Timeline13").GetComponent<PlayableDirector>();
        playableDirector14 = GameObject.Find("Timeline14").GetComponent<PlayableDirector>();
        playableDirector15 = GameObject.Find("Timeline15").GetComponent<PlayableDirector>();
        animatorG = GameObject.Find("Garou").GetComponent<Animator>();
        animatorM = GameObject.Find("Maltoroz").GetComponent<Animator>();
        ScoreGenerator.yildizpuani_int = 0;
    }

    void Update()
    {

        if (playableDirector.time >= 8.9f)
        {
            playableDirector.time = 10f;
            playableDirector2.Play();
        }

        if (playableDirector2.time >= 26.9f)
        {
            playableDirector2.time = 28f;
            playableDirector3.Play();

        }

        if (playableDirector3.time >= 6.4f)
        {
            playableDirector3.time = 7f;
            playableDirector4.Play();
        }

        if (playableDirector4.time >= 18.9f)
        {
            playableDirector4.time = 20f;
            playableDirector5.Play();
        }

        if (playableDirector5.time >= 19.4)
        {
            playableDirector5.time = 20f;
            playableDirector6.Play();
        }

        if (playableDirector6.time >= 44.9f)
        {
            playableDirector6.time = 46f;
            playableDirector7.Play();
        }

        if(playableDirector7.time >= 9.9f)
        {
            playableDirector7.time = 11f;
            playableDirector8.Play();
        }

        if (playableDirector8.time >= 88.4f)
        {
            playableDirector8.time = 89f;
            playableDirector9.Play();
        }

        if(playableDirector9.time >= 27.9f)
        {
            playableDirector9.time = 29f;
            playableDirector10.Play();
        }

        if(playableDirector10.time >= 30.1f && playableDirector10.time <= 40.8f)
        {
            animatorG.SetBool("attack", true);
            animatorM.SetBool("defence", true);
        }

        if(playableDirector10.time >= 72.9f)
        {
            playableDirector10.time = 74f;
            playableDirector11.Play();
        }

        if (playableDirector11.time >= 19.9f)
        {
            playableDirector11.time = 21f;
            playableDirector10v2.Play();
        }

        if (playableDirector10v2.time >= 14.9f)
        {
            playableDirector10v2.time = 16f;
            playableDirector12.Play();
        }

        if (playableDirector12.time >= 51.9f)
        {
            playableDirector12.time = 53f;
            playableDirector13.Play();
        }

        if (playableDirector13.time >= 51.9f)
        {
            playableDirector13.time = 53f;
            playableDirector14.Play();
        }

        if (playableDirector14.time >= 44.9f)
        {
            playableDirector14.time = 46f;
            playableDirector15.Play();
        }


    }

    public async void WaitForFrames(int time)
    {
        await Task.Delay(time);
    }
}
