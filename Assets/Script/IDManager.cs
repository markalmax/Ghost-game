using System.Collections.Generic;
using UnityEngine;

public class IDManager : MonoBehaviour
{
    public Ability[] abilities;
    public void onChange(int index, int ID , KeyCode key)
    {
        Ability newAbility=abilities[ID];
        SkillsSystem skillsSystem=gameObject.GetComponent<SkillsSystem>();
        skillsSystem.ChangeSkill(index,newAbility,key);
    }
}
