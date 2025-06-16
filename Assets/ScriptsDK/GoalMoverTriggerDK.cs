using UnityEngine;

public class GoalMoverTriggerDK : MonoBehaviour
{
    [Header("Shared Settings")]
    [Tooltip("Assign the goal GameObject that should be moved.")]
    public GameObject goal;

    [Tooltip("Assign the list of target positions (as empty GameObjects in the scene).")]
    public Transform[] goalPositions;

    private static int currentGoalIndex = 1; // Shared across all instances
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTriggered) return;

        if (collision.CompareTag("Player"))
        {
            MoveGoalToNextPosition();
            hasTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasTriggered = false;
        }
    }

    private void MoveGoalToNextPosition()
    {
        if (goal == null || goalPositions == null || goalPositions.Length == 0)
        {
            Debug.LogWarning("GoalMoverTriggerDK: Missing goal or goal positions.");
            return;
        }

        // Move the goal to the next position in the list
        goal.transform.position = goalPositions[currentGoalIndex].position;

        // Advance and wrap the index
        currentGoalIndex = (currentGoalIndex + 1) % goalPositions.Length;
    }
}
