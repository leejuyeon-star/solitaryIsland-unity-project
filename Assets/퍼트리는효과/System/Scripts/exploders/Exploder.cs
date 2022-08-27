using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Exploder : MonoBehaviour {
	public float explosionTime = 0;
	private float _explosionTime;
	public float randomizeExplosionTime = 0;
	private float _randomizeExplosionTime;
	public float radius = 15;
	private float _radius;
	public float power = 1;
	private float _power;
	public int probeCount = 150;
	private int _probeCount;
	public float explodeDuration = 0.5f;
	private float _explodeDuration;

	protected bool exploded = false;
	protected bool _exploded;

	private int waitingTime = 2;
	private int _waitingTime;
	private float timer = 0.0f;
	private float _timer;




	void Update()
    {
		_timer += Time.deltaTime;       
        if(_timer > _waitingTime)  //쓰레기봉투가 생성된 시점부터 waitingTime 이후 실행
        {
			//오브젝트 삭제
			ObjectPooling.Instance.DeactivatePoolItem(gameObject);
		}
	}

	
	
	public virtual IEnumerator explode() {
		ExploderComponent[] components = GetComponents<ExploderComponent>(); 
		foreach (ExploderComponent component in components) {
			if (component.enabled) {
				component.onExplosionStarted(this);
			}
		}		
		while(true){		//계속 폭파..
		// while (_explodeDuration > Time.time - _explosionTime) {
			disableCollider();
			for (int i = 0; i < _probeCount; i++) {
				shootFromCurrentPosition();
			}
			enableCollider();
			yield return new WaitForFixedUpdate();
		}
	}
	
	protected virtual void shootFromCurrentPosition() {
		Vector3 probeDir = Random.onUnitSphere;
		Ray testRay = new Ray(transform.position, probeDir);
		shootRay(testRay, _radius);
	}

	protected bool wasTrigger;
	public virtual void disableCollider() {
		if (GetComponent<Collider>()) {
			wasTrigger = GetComponent<Collider>().isTrigger;
			GetComponent<Collider>().isTrigger = true;
		}
	}

	public virtual void enableCollider() {
		if (GetComponent<Collider>()) {
			GetComponent<Collider>().isTrigger = wasTrigger;
		}
	}

	
	protected virtual void init() {
		_power *= 500000;
		
		if (_randomizeExplosionTime > 0.01f) {
			_explosionTime += Random.Range(0.0f, _randomizeExplosionTime);
		}
	}

	void OnEnable() {
		_explosionTime = explosionTime;
		_randomizeExplosionTime = randomizeExplosionTime;
		_radius = radius;
		_power = power;
		_probeCount = probeCount;
		_explodeDuration = explodeDuration;
		_exploded = exploded;
		_waitingTime = waitingTime;
		_timer = timer;
		init();
	}

	void FixedUpdate() {
		if (Time.time > _explosionTime && !_exploded) {
			_exploded = true;
			StartCoroutine("explode");
		}
	}

	private void shootRay(Ray testRay, float estimatedRadius) {
		RaycastHit hit;
		if (Physics.Raycast(testRay, out hit, estimatedRadius)) {
			if (hit.rigidbody != null) {
				hit.rigidbody.AddForceAtPosition(_power * Time.deltaTime * testRay.direction / _probeCount, hit.point);
				estimatedRadius /= 2;
			} else {
				Vector3 reflectVec = Random.onUnitSphere;
				if (Vector3.Dot(reflectVec, hit.normal) < 0) {
					reflectVec *= -1;
				}
				Ray emittedRay = new Ray(hit.point, reflectVec);
				shootRay(emittedRay, estimatedRadius - hit.distance);
			}
		}
	}
}
