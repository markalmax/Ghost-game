using UnityEngine;
using System.Collections;
[CreateAssetMenu(menuName ="Ability/Transparent")]
public class Transparent : Ability
{
    public SpriteRenderer sr;
    public float transparency = 0.3f;
    public override void UseSkill(GameObject player)
    {
        sr = player.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - transparency);
    }
    public override void EndSkill(GameObject player)
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + transparency);
    }
    
}
