using System.Collections.Generic;
using UnityEngine;

public class IDManager : MonoBehaviour
{

    public Ability[] abilities;
    public GameObject player;
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    } 
    public void onChange(int index, int ID , KeyCode key)
    {
        Ability newAbility=abilities[ID];
        SkillsSystem skillsSystem=player.GetComponent<SkillsSystem>();
        skillsSystem.ChangeSkill(index,newAbility,key);
    }
}
