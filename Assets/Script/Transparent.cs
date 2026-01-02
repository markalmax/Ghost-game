using UnityEngine;
using System.Collections;
public class Transparent : MonoBehaviour
{
    public SpriteRenderer sr;
    public float transparency = 0.3f;
    public float cd = 2f;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    public void Trans()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - transparency);
        StartCoroutine(EndDash());
    }
    public IEnumerator EndDash()
    {
        yield return new WaitForSeconds(1f);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + transparency);
    }
    public void UseSkill(int skillId)
    {
        Trans();
    }
}
