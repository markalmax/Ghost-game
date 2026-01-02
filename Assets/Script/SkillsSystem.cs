using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillsSystem : MonoBehaviour
{
    public float defaultCD = 2f;
    public int[] skills = new int[0];
    public MonoBehaviour[] skillsScripts = new MonoBehaviour[0];
    public TMP_Dropdown[] skillDropdowns = new TMP_Dropdown[0];
    private float[] skillCD = new float[0];
    void Start()
    {
        if (skillsScripts == null) skillsScripts = new MonoBehaviour[0];
        if (skillDropdowns == null) skillDropdowns = new TMP_Dropdown[0];
        if (skills == null || skills.Length != skillsScripts.Length)
            skills = new int[skillsScripts.Length];
        skillCD = new float[skillsScripts.Length];
        for (int i = 0; i < skillCD.Length; i++) skillCD[i] = 0f;
    }

    void Update()
    {
        for (int i = 0; i < skillCD.Length; i++)
            if (skillCD[i] > 0f)
                skillCD[i] -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1")) ActivateSkill(0);
        if (Input.GetButtonDown("Fire2")) ActivateSkill(1);
        if (Input.GetButtonDown("Fire3")) ActivateSkill(2);
    }

    public void DropDown(int index)
    {
        var go = EventSystem.current != null ? EventSystem.current.currentSelectedGameObject : null;
        if (go != null)
        {
            for (int i = 0; i < skillDropdowns.Length; i++)
            {
                var dd = skillDropdowns[i];
                if (dd != null && dd.gameObject == go)
                {
                    if (i < skills.Length) skills[i] = index;
                    else Debug.LogWarning("skills array too small for slot " + i);
                    return;
                }
            }
        }
        if (skills.Length > 0) skills[0] = index;
    }

    void ActivateSkill(int slot)
    {
        if (skills == null || slot < 0 || slot >= skills.Length) return;
        if (slot < skillCD.Length && skillCD[slot] > 0f)
        {
            Debug.Log("Skill slot " + slot + " is on cooldown: " + skillCD[slot].ToString("F2") + "s");
            return;
        }
        int skillId = skills[slot];
        if (skillsScripts != null && slot < skillsScripts.Length && skillsScripts[slot] != null)
        {
            float cd = defaultCD;
            var f = skillsScripts[slot].GetType().GetField("cd");
            if (f != null)
            {
                object val = f.GetValue(skillsScripts[slot]);
                cd = (float)val;
            }
            skillsScripts[slot].SendMessage("UseSkill", skillId, SendMessageOptions.DontRequireReceiver);
            if (slot < skillCD.Length)
                skillCD[slot] = cd;
        }
    }
}
