using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;


public class Projectile : MonoBehaviour {

	[HideInInspector]
	public bool collided = false;
	public float damage;
	public string objective;
	protected Rigidbody rb;

	void OnTriggerEnter(Collider other) {
		Debug.Log(other.transform.gameObject.name);
		if(other.transform.gameObject.name == objective){
			collided = true;
			Debug.Log("collision, damage: " + damage + "---" + objective);
			Glob.name_item[objective].health -= damage;
			Destroy(gameObject);
		}
	}

	public void Init(float _damage, string _objective){
		rb = gameObject.GetComponent<Rigidbody>();
		damage = _damage;
		objective = _objective;
	}

	public void Fire(Vector3 _target, Vector3 _origin){
		rb.AddForce(rb.velocity = (_target - _origin).normalized * 10);
	}

}