using UnityEngine;

[CreateAssetMenu(menuName ="Ability/67")]
public class _67 : Ability
{
    public AudioClip sound;
    public override void UseSkill(GameObject player)
    {
        player.GetComponent<AudioSource>().PlayOneShot(sound);
    }
    public override void EndSkill(GameObject player)
    {
        
    }
    public override bool KeepActive(GameObject player){return false;}
}
