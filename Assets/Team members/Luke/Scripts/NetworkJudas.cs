using System;
using System.Collections;
using System.Collections.Generic;
using Luke;
using Mirror;
using UnityEngine;
using ZachFrench;

public class NetworkJudas : NetworkBehaviour
{
    private JudasWitnessModel _judasWitnessModel;

    public void Start()
    {
        _judasWitnessModel = GetComponent<JudasWitnessModel>();
    }

    public void BasicNoises()
    {
        _judasWitnessModel.chorusFilter.wetMix1 = Mathf.PerlinNoise(Time.time / _judasWitnessModel.maxWetMix, 0);
        _judasWitnessModel.chorusFilter.rate = Mathf.PerlinNoise(Time.time / _judasWitnessModel.maxRate, 0);
        _judasWitnessModel.chorusFilter.depth = Mathf.PerlinNoise(Time.time / _judasWitnessModel.maxDepth, 0);

        if (!_judasWitnessModel.audioSource.isPlaying)
        {
            _judasWitnessModel.audioSource.Play();
        }
    }
    
    public void Wander()
    {
        
        if (_judasWitnessModel.patrolManager == null)
        {
            _judasWitnessModel.patrolManager = FindObjectOfType<PatrolManager>();
            if (_judasWitnessModel.patrolManager == null)
            {
                return;
            }
        }

        if (_judasWitnessModel.patrolManager.pathsWithIndoors != null)
        {
            _judasWitnessModel.navMeshAgent.speed = _judasWitnessModel.patrolSpeed;
        }
    }
    
    public void SetWaterTarget()
    {
        if (_judasWitnessModel.waterTargets.Count > 0)
        {
            foreach (PatrolPoint target in _judasWitnessModel.waterTargets)
            {
                if (target == _judasWitnessModel.gatheredWaterTargets.Contains(target))
                {
                    _judasWitnessModel.waterTargets.Remove(target);
                }
            }
        }
        else if(_judasWitnessModel.gatheredWaterTargets.Count <= 0)
        {
            _judasWitnessModel.waterTargets.AddRange(_judasWitnessModel.patrolManager.waterTargets);
        }
    }
    
    public void ResetPlanner()
    {
        _judasWitnessModel.antAIAgent.worldState.BeginUpdate(_judasWitnessModel.antAIAgent.planner);
        _judasWitnessModel.antAIAgent.worldState.Set("gotResource", false);
        _judasWitnessModel.antAIAgent.worldState.Set("playerFound", false);
        _judasWitnessModel.antAIAgent.worldState.Set("needRecharge", false);
        _judasWitnessModel.antAIAgent.worldState.Set("foundResource", false);
        _judasWitnessModel.antAIAgent.worldState.Set("deliveredResource", false);
        _judasWitnessModel.antAIAgent.worldState.Set("atAttackRange", false);
        _judasWitnessModel.antAIAgent.worldState.Set("atResourcePos", false);
        _judasWitnessModel.antAIAgent.worldState.Set("foundRecharge", false);
        _judasWitnessModel.antAIAgent.worldState.Set("atRechargePos", false);
        _judasWitnessModel.antAIAgent.worldState.EndUpdate();
    }
}
