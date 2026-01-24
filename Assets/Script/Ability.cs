using UnityEngine;


public class Ability : ScriptableObject
{
    public new string name;
    public float CD;
    public float activetime;
    public virtual void UseSkill(GameObject player){}
    public virtual void EndSkill(GameObject player){}
    public virtual bool KeepActive(GameObject player){return false;}
}
