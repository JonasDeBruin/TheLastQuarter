using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Settings")]
    public float staminaDecrease; 
    public float staminaIncrease;
    public float stamina,maxStamina,maxWidth;

    public RawImage staminaBar;
    PlayerMovement player;
    public bool isRed = false;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
        stamina = 100;
        maxStamina = stamina;
        maxWidth = staminaBar.rectTransform.sizeDelta.x;
    }

    void Update()
    {
        staminaBar.rectTransform.sizeDelta = new Vector2(maxWidth * (stamina / maxStamina), staminaBar.rectTransform.sizeDelta.y);

        if (player.isRunning && stamina > 0 && player.canRun)
        {
            stamina -= staminaDecrease * Time.deltaTime;
        }
        else if(!player.isRunning && stamina < 100 || !player.canRun)
        {
            stamina += staminaIncrease * Time.deltaTime;
        }

        if (player.canRun)
        {
            if (stamina <= 0.05f)
            {
                player.canRun = false;
                StartCoroutine(ChangeColor(new Color(0, 0, 0), 0.05f));
            }
            if(stamina <= 25 && !isRed)
            {
                StartCoroutine(ChangeColor(new Color(1, 0, 0), 0.5f));
                isRed = true;
            }
            else if(stamina >= 25 && isRed)
            {
                StartCoroutine(ChangeColor(new Color(1, 1, 1), 0.5f));
                isRed = false;
            }
        }
        else
        {
            if(stamina >= 20)
            {
                player.canRun = true;
                StartCoroutine(ChangeColor(new Color(1, 1, 1), 0.5f));
            }
        }

    }

    IEnumerator ChangeColor(Color newColor, float time)
    {
        int ammount = 15;

        Vector3 difference = new Vector3(staminaBar.color.r - newColor.r, staminaBar.color.g - newColor.g, staminaBar.color.b - newColor.b);
        difference = -difference;

        for (int i = 0; i < ammount; i++)
        {
            yield return new WaitForSeconds(time / ammount);
            staminaBar.color += new Color(difference.x / ammount, difference.y / ammount, difference.z / ammount, 0);
        }
        staminaBar.color = newColor;
    }
}
