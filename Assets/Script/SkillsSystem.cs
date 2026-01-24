using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections.Generic;

public class SkillsSystem : MonoBehaviour
{
    [System.Serializable]
    public class SkillSlot
    {
        public Ability ability;
        public KeyCode key;
        public AbilityState state = AbilityState.ready;
        public float stateTimer = 0f;
    }

    public enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    public List<SkillSlot> skills = new List<SkillSlot>();

    void Update()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            UpdateSkill(i);
        }
    }

    void UpdateSkill(int skillIndex)
    {
        SkillSlot skill = skills[skillIndex];
        if (skill.ability == null) return;

        switch (skill.state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(skill.key))
                {
                    skill.ability.UseSkill(gameObject);
                    skill.state = AbilityState.active;
                    skill.stateTimer = skill.ability.activetime;
                }
                break;
            case AbilityState.active:
                skill.stateTimer -= Time.deltaTime;
                if (skill.stateTimer <= 0)
                {
                    if (!skill.ability.KeepActive(gameObject))
                    {
                        skill.ability.EndSkill(gameObject);
                        skill.state = AbilityState.cooldown;
                        skill.stateTimer = skill.ability.CD;
                    }
                }
                break;
            case AbilityState.cooldown:
                skill.stateTimer -= Time.deltaTime;
                if (skill.stateTimer <= 0)
                {
                    skill.state = AbilityState.ready;
                }
                break;
        }
    }

    public void AddSkill(Ability ability, KeyCode key)
    {
        skills.Add(new SkillSlot { ability = ability, key = key });
    }

    public void RemoveSkill(int skillIndex)
    {
        if (skillIndex >= 0 && skillIndex < skills.Count)
            skills.RemoveAt(skillIndex);
    }

    public SkillSlot GetSkill(int skillIndex)
    {
        return skillIndex >= 0 && skillIndex < skills.Count ? skills[skillIndex] : null;
    }
}
