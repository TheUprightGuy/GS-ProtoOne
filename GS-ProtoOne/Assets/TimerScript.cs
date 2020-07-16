using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timer = 60;
    //private startCount;
    private TMPro.TextMeshProUGUI text;

    public HealthScript p1;
    public HealthScript p2;

    public bool called = false;

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        text.SetText(((int)timer).ToString());

        if (timer <= 0 && !called)
        {
            called = true;
            if (p1.health > p2.health)
            {
                EventHandler.instance.GameOver(1);
            }
            else if (p2.health > p1.health)
            {
                EventHandler.instance.GameOver(2);
            }
            else
            {
                EventHandler.instance.ResetScene();
            }
        }
    }
}
