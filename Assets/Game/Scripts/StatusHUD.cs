using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusHUD : MonoBehaviour
{
    public PlayerController player;
    public StatusBar experienceBar;
    public StatusBar manaBar;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        experienceBar.ChangeMAxValue(PlayerController.MaxExperience);
        healthBar.ChangeMAxValue(player.health.maxValue);
        manaBar.ChangeMAxValue(player.mana.maxValue);

    }

    // Update is called once per frame
    void Update()
    {
       

        experienceBar.UpdateInfo(player.experience);
        healthBar.UpdateInfo(player.health.currentValor);
        manaBar.UpdateInfo(player.mana.currentValor);
    }

    public void ChangeHealth(int value)
    {
        player.ChangeHealth(Random.Range(1, value));
    }
    public void ChangeMana(int value)
    {
        player.ChangeMana(value);
    }

}
