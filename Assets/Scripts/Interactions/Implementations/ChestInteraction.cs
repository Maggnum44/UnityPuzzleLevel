using UnityEngine;

namespace Gameplay.Interactions{
    public class ChestInteraction : MonoBehaviour
    {
        private Interactable _interactable;
        private Animator _animator;

        private bool isOpen = false;

        public GameObject rewardPrefab;
        public int rewardCount = 1;

        private bool hasSpawnedReward = false;

        void Awake()
        {
            _interactable = GetComponent<Interactable>();
            _interactable.OnInteract += Interact;

            _animator = GetComponent<Animator>();
        }

        private void Interact(CharacterInteractor interactor)
        {
                  isOpen = !isOpen;
            _animator.SetBool("isOpen", isOpen);
            //_interactable.InteractionEnabled = false;

      
            
            
        }





        public void SpawnReward()
        {
            if (!hasSpawnedReward)
            {
                 for (int i = 0; i < rewardCount; i++)
            {
                GameObject reward = Instantiate(rewardPrefab, transform.position + Vector3.up * 0.2f, Quaternion.identity);
                LaunchableReward launchableReward = reward.GetComponent<LaunchableReward>();
                if (launchableReward != null)
                {
                    launchableReward.LaunchReward();
                }
            }
            hasSpawnedReward = true;
            }
           
        }
    }
}
