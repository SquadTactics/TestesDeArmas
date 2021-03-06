﻿using UnityEngine;
using System.Collections;
using System;

public class BulletP38Behaviour : BulletsBehaviour {

    // Use this for initialization
    void Start()
    {
        this.origem = this.transform.position;
        this.velocidade = 15;
        this.danoPequena = 12;
        this.danoMedio = 9;
        this.danoLongo = 6;
        Physics.IgnoreLayerCollision(13, 12);
        Physics.IgnoreLayerCollision(13, 11);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision) {
        if (collision.gameObject.layer == 10) {
            float distancia = Vector3.Distance(collision.gameObject.GetComponent<PlayerBehaviour>().transform.position, this.origem);
            this.CalcularDano(distancia);
            collision.gameObject.GetComponent<PlayerBehaviour>().LevaDano(this.dano);
            Destroy(this.gameObject);
        }
    }

    protected override void CalcularDano(float distancia) {
        if (distancia >= 2 && distancia <= 4)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 4 && distancia <= 7)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 7 && distancia <= 10)
        {
            this.dano = this.danoLongo;
        }
    }
}