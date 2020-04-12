using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public Spell spell;
    private float force;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (spell.castType == Spell.CastType.Shoot)
        {
            transform.parent = null;
            force = spell.force;
            rb.AddForce(transform.forward * force);
        } else if (spell.castType == Spell.CastType.Wand)
        {
            transform.localPosition = Vector3.zero;
            rb.isKinematic = true;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }
        Destroy(this.gameObject, spell.time);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (spell.castType == Spell.CastType.Shoot)
        {
            if (collision.transform.tag != "Player")
            {
                Debug.Log(collision.transform.name);
                rb.isKinematic = true;
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
                if (spell.dieOnCollision)
                {
                    var destroy = Instantiate(spell.destroyPrefab, null);
                    destroy.transform.position = this.transform.position;
                    Destroy(this.gameObject, 0.1f);
                }
            }
        }
    }
}
