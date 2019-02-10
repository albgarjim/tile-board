using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mage : BoardPiece {
	GameObject proj = new GameObject();

	public Mage() : base(){
		health = 500.0f;
		damage = 70.0f;
		at_speed = 1.4f;

		typ = Glob.type.PIECE;
		model = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/mage"));
		model.name = "piece-mage_" + id.ToString();
		Glob.name_item[model.name] = this;
	}

	public override void Evolve() {
		Debug.Log("Evolving mage");
		proj = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/projectile"), model.transform.position, model.transform.rotation);

		proj.GetComponent<Projectile>().Init(damage, "piece-dummy_97");
		proj.GetComponent<Projectile>().Fire(Glob.name_item["piece-dummy_97"].pos, model.transform.position);
	}
}


public class Dummy : BoardPiece {

	public Dummy() : base(){
		health = 5000000.0f;
		damage = 0.0f;
		at_speed = 0.0f;

		typ = Glob.type.PIECE;
		model = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/dummy"));
		model.name = "piece-dummy_" + id.ToString();
		Glob.name_item[model.name] = this;
	}

	public override void Evolve(){
		Debug.Log("HEALTH: " + health);
	}	
}
