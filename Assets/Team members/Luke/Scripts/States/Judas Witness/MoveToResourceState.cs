using Anthill.AI;
using UnityEngine;

namespace Luke
{
    public class MoveToResourceState : AntAIState
    {
        public GameObject owner;
        public JudasWitnessModel judasWitnessModel;
        public AntAIAgent antAIAgent;
        public float minDistance = 3f;

        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);

            owner = aGameObject;
            antAIAgent = owner.GetComponent<AntAIAgent>();
            judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
            minDistance = 3f;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Move to resource state");

            if (judasWitnessModel.waterTargets.Count <= 0)
            {
                Debug.Log("waterTarget Null");
                Finish();
            }
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);

            if (judasWitnessModel.waterTargets.Count > 0)
            {
                if (judasWitnessModel.currentWaterTarget != null)
                {
                    Vector3 position = judasWitnessModel.currentWaterTarget.transform.position;
                    
                    float betweenPosAndResource =
                        Vector3.Distance(judasWitnessModel.transform.position, position);
                    
                    Debug.DrawLine(judasWitnessModel.transform.position, position, Color.blue);
                    
                    judasWitnessModel.navMeshAgent.SetDestination(position);
                    
                    if (betweenPosAndResource < minDistance)
                    {
                        Debug.Log("At resource position");

                        //added here as well to check for player interrupting
                        judasWitnessModel.waterTargets.Remove(judasWitnessModel.currentWaterTarget);

                        antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
                        antAIAgent.worldState.Set("atResourcePos", true);
                        antAIAgent.worldState.EndUpdate();

                        Finish();
                    }
                }
            }

            if (judasWitnessModel.currentWaterTarget == null)
            {
                Finish();
            }
        }
    }
}