using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHeadScript : MonoBehaviour
{
    public int id;
    private Image image;
    [HideInInspector] public Part part;
    public Image cooldown;

    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        EventHandler.instance.setIcon += SwapIcon;
        EventHandler.instance.GetIcon();
    }

    private void Update()
    {
        if (part)
        {
            cooldown.fillAmount = part.cooldownTimer / part.cooldown;
        }
    }

    private void OnDestroy()
    {
        EventHandler.instance.setIcon -= SwapIcon;
    }

    public void SwapIcon(int _id, Part _part)
    {
        if (id == _id)
        {
            image.sprite = _part.sprite;
            part = _part;
        }
    }
}
