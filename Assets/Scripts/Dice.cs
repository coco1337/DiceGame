using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    [SerializeField] private List<PlayerInfo> playerList;

    private int turn;
    private float playerHeightOffset = 1f;

    [HideInInspector]
    public bool isRolling;

    public Text sum;

    public int value = 0;

    public float minRollForce;

    public float maxRollForce;

    Rigidbody rb;

    public UnityEvent RollEvent;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRolling == true)
        {
            if (rb.IsSleeping())
            {
                isRolling = false;
                calculateValue();
                Debug.Log("첫번째 유니티이벤트");
                RollEvent.Invoke();
            }
        }
    }

    void calculateValue()
    {
        float upPosDot = Vector3.Dot(Vector3.up, transform.up);
        float rightPosDot = Vector3.Dot(Vector3.up, transform.right);
        float forwardPosDot = Vector3.Dot(Vector3.up, transform.forward);

        if (System.Math.Abs(upPosDot - 1) < 0.1f)
        {
            value = 2;
            Debug.Log(value);

        }
        if (System.Math.Abs(upPosDot - -1) < 0.1f)
        {
            value = 4;
            Debug.Log(value);

        }
        if (System.Math.Abs(rightPosDot - 1) < 0.1f)
        {
            value = 3;
            Debug.Log(value);

        }
        if (System.Math.Abs(rightPosDot - -1) < 0.1f)
        {
            value = 1;
            Debug.Log(value);

        }
        if (System.Math.Abs(forwardPosDot - 1) < 0.1f)
        {
            value = 5;
            Debug.Log(value);

        }
        if (System.Math.Abs(forwardPosDot - -1) < 0.1f)
        {
            value = 6;
            Debug.Log(value);

        }

    }


    public void AddForceToDice()
    {
        if (!isRolling)
        {
            isRolling = true;
            Vector3 RandomPosition = new Vector3(Random.Range(-0.2f, 0.2f), -1, Random.Range(-0.2f, 0.2f));
            rb.AddExplosionForce(Random.Range(minRollForce, maxRollForce), RandomPosition, -0.5f, 2f);
        }
    }
}
