using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AhmettnyFight : MonoBehaviour
{
    public GameObject earth;
    public GameObject stick;
    public GameObject dragonspine;
    public GameObject shield;
    public bool right = true;
    Animator animator;
    public bool up;
    float attackTime;

    void Start()
    {
        earth.SetActive(false);
        stick.SetActive(false);
        dragonspine.SetActive(false);
        shield.SetActive(false);
        right = true;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!GameObject.Find("step2"))
        {
            earth.SetActive(true);
            stick.SetActive(true);
            dragonspine.SetActive(true);
            shield.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (right)
            {
                Vector3 shieldPos = shield.transform.position;
                shieldPos.x -= 3.5f;
                shield.transform.position = shieldPos;
                Vector3 stickPos = stick.transform.position;
                Vector3 stickScale = stick.transform.localScale;
                stickPos.x += 5.7f;
                stickScale.x *= -1;
                stick.transform.position = stickPos;
                stick.transform.localScale = stickScale;
            }
            else
            {
                Vector3 shieldPos = shield.transform.position;
                shieldPos.x += 3.5f;
                shield.transform.position = shieldPos;
                Vector3 stickPos = stick.transform.position;
                Vector3 stickScale = stick.transform.localScale;
                stickPos.x -= 5.7f;
                stickScale.x *= -1;
                stick.transform.position = stickPos;
                stick.transform.localScale = stickScale;
            }

            right = !right;
        }

        if (Input.GetKey(KeyCode.F) && attackTime >= 0.01f)
        {
            if (up)
            {
                Vector3 stickPos = stick.transform.position;
                Vector3 stickScale = stick.transform.localScale;
                stickPos.y += 2.1f;
                stickScale.y *= -1;
                stick.transform.position = stickPos;
                stick.transform.localScale = stickScale;
            }
            else
            {
                Vector3 stickPos = stick.transform.position;
                Vector3 stickScale = stick.transform.localScale;
                stickPos.y -= 2.1f;
                stickScale.y *= -1;
                stick.transform.position = stickPos;
                stick.transform.localScale = stickScale;
            }

            up = !up;
            attackTime = 0;
        }

        attackTime += Time.deltaTime;
    }
}
