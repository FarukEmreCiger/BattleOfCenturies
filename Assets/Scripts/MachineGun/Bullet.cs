using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform targetTransform;
    private GameObject target;

    private float speed;
    private float damage;
    public GameObject impactEffect;

    public void Seek(GameObject _target,float attackDamage,float bulletSpeed)
    {
        target=_target;
        targetTransform = _target.transform;
        damage=attackDamage;
        speed=bulletSpeed;
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(targetTransform==null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir =new Vector3(targetTransform.position.x,transform.position.y,targetTransform.position.z)  - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude<=distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        target.GetComponent<Character>().TakeDamage(damage);
        Destroy(effectIns, 1f);
        Destroy(gameObject);
    }
}
