using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBird : Bird
{
    [SerializeField]
    public float _bombRadius = 10;
    public float _force;
    public bool _hasBomb = false;

    public LayerMask LayertoHit;
    public GameObject ExplosionEffect;

    public override void onBom()
    {
        if (State == BirdState.HitSomething && !_hasBomb)
        {
            StartCoroutine(BoomAfter(2f));
        }

    }

    private IEnumerator BoomAfter(float second)
    {
        yield return new WaitForSeconds(second);
        Boom();
    }
    public void Boom()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _bombRadius, LayertoHit);
        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * _force);
        }
        //summon effek ledakan
        GameObject ExplosionEffectInst = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectInst, 10);
        _hasBomb = true;
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _bombRadius);
    }


}
