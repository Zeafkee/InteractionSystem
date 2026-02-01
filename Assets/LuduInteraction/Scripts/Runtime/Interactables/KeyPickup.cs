using LuduInteraction.Runtime.Core;
using LuduInteraction.Runtime.Player;
using UnityEngine;

namespace LuduInteraction.Runtime.Interactables
{
    /// <summary>
    /// An interactable item that can be picked up and added to the player's inventory.
    /// </summary>
    public class KeyPickup : InstantInteractable
    {
        #region Fields

        [Header("Key Settings")]
        [Tooltip("The item data to add to inventory.")]
        [SerializeField] private ItemData m_KeyItem;

        #endregion

        #region Properties

        public override string InteractionPrompt => $"Pick up {m_KeyItem?.ItemName ?? "Key"}";
        public override bool CanInteract => true;

        #endregion

        #region Overrides

        public override void OnInteractComplete(GameObject interactor)
        {
            base.OnInteractComplete(interactor);

            if (m_KeyItem != null)
            {
                var inventory = interactor.GetComponent<SimpleInventory>();
                if (inventory != null)
                {
                    inventory.AddItem(m_KeyItem);
                    
                    // Disable the object to simulate "picking it up"
                    gameObject.SetActive(false);
                }
                else
                {
                    Debug.LogWarning("Interactor missing SimpleInventory component.");
                }
            }
        }

        #endregion
    }
}
