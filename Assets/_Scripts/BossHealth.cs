using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

    public float health = 100f;
    public float repeatDamagePeriod = 2f;
    public AudioClip[] ouchClips;
    public float hurtForce = 10f;
    private float damageTaken = 9f;

    private SpriteRenderer healthbar;
    private float lastHit;
    private Vector3 healthScale;
    private Animator anim;


    void Awake()
    {
        healthbar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        healthScale = healthbar.transform.localScale;
    }

        void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (Time.time > lastHit + repeatDamagePeriod)
            {
                if (health > 0f)
                {
                    damage(col.transform);
                    lastHit = Time.time;
                }
                else
                {
                    Collider2D[] cols = GetComponents<Collider2D>();
                    foreach (Collider2D c in cols)
                    {
                        c.isTrigger = true;
                    }

                    SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
                    foreach (SpriteRenderer s in spr)
                    {
                        s.sortingLayerName = "UI";
                    }

                    //GetComponent<PlayerControl>().enabled = false;

                    //GetComponentInChildren<Gun>().enabled = false;

                    anim.SetTrigger("Die");
                }
            }
        }
    }


    void damage(Transform enemy)
    {
        //playerControl.jump = false;

        Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;

        //GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);

        health -= damageTaken;
        Debug.Log("health: " + health);
        updateHealthBar();

        int i = Random.Range(0, ouchClips.Length);
        //AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
    }


    public void updateHealthBar()
    {
        healthbar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

        //healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
        float resizeX = healthScale.x * health * 0.01f;
        Debug.Log("resize: " + resizeX);
        healthbar.transform.localScale = new Vector3(resizeX, healthScale.y, healthScale.z);
    }
}
