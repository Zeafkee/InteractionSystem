using System.Collections.Generic;
using LuduInteraction.Runtime.Core;
using UnityEngine;
using UnityEngine.Events;

namespace LuduInteraction.Runtime.Player
{
    /// <summary>
    /// A simple inventory system for the player to track collected items.
    /// </summary>
    public class SimpleInventory : MonoBehaviour
    {
        #region Fields

        [Tooltip("List of items currently in the inventory.")]
        [SerializeField] private List<ItemData> m_Items = new List<ItemData>();

        #endregion

        #region Events

        /// <summary>
        /// Invoked whenever an item is added or removed.
        /// </summary>
        public UnityEvent OnInventoryChanged;

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an item to the inventory.
        /// </summary>
        public void AddItem(ItemData item)
        {
            if (item == null)
            {
                Debug.LogWarning("Attempted to add a null item to inventory.");
                return;
            }

            m_Items.Add(item);
            Debug.Log($"Collected: {item.ItemName}");
            OnInventoryChanged?.Invoke();
        }

        /// <summary>
        /// Checks if the inventory contains a specific item by reference.
        /// </summary>
        public bool HasItem(ItemData item)
        {
            return m_Items.Contains(item);
        }

        /// <summary>
        /// Checks if the inventory contains an item with a specific ID.
        /// </summary>
        public bool HasItem(string itemID)
        {
            return m_Items.Exists(i => i.ItemID == itemID);
        }

        /// <summary>
        /// Returns a read-only list of items.
        /// </summary>
        public List<ItemData> GetItems()
        {
            // Returning a copy to prevent external modification
            return new List<ItemData>(m_Items);
        }

        #endregion
    }
}
