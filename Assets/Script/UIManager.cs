using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Dropdown[] dropdowns;
    public GameObject player;
    public IDManager idm;
    public SkillsSystem ss;
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        ss = player.GetComponent<SkillsSystem>();
        idm = FindFirstObjectByType<IDManager>();
        foreach (var dd in dropdowns)
        {
            dd.ClearOptions();
            foreach (var ability in idm.abilities)
            {
                dd.options.Add(new TMP_Dropdown.OptionData(ability.name, ability.icon,Color.black));
            }
            Debug.Log(dd.options);
        }
        foreach (TMP_Dropdown dd in dropdowns)
        {
            dd.onValueChanged.AddListener(delegate {
                OnDropdownValueChanged(dd);
            });
        }
    }
    void OnDropdownValueChanged(TMP_Dropdown dropdown)
    {
        int index = System.Array.IndexOf(dropdowns, dropdown);
        KeyCode key = KeyCode.Z;
        switch (index)
        {
            case 0:
                key = KeyCode.Z;
                break;
            case 1:
                key = KeyCode.X;
                break;
            case 2:
                key = KeyCode.C;
                break;
            default:
                break;
        }
        ss.ChangeSkill(index, idm.abilities[dropdown.value], key);
    }
}
