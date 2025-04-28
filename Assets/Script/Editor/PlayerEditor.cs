using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    // Player script variable
    Player player;

    // Visuals for Player variables
    SerializedProperty m_canJump;
    SerializedProperty m_jumpHeight;
    SerializedProperty m_doubleJumpHeight;

    private void OnEnable()
    {
        // Assigning target to player script
        player = (Player)target;

        // Assigning/linking player's variables to editor script
        m_canJump = serializedObject.FindProperty("canJump");
        m_jumpHeight = serializedObject.FindProperty("jumpHeight");
        m_doubleJumpHeight = serializedObject.FindProperty("doubleJumpHeight");
    }

    // Draw Inspector window
    public override void OnInspectorGUI()
    {
        // Begin checking if there are any changes on variables
        EditorGUI.BeginChangeCheck();

        // Draw PlayerEditor.m_canJump for Player.canJump
        EditorGUILayout.PropertyField(m_canJump);
        if(m_canJump.boolValue)
        {
            // If player can jump,
            // Draw PlayerEditor.m_JumpHeight for Player.jumpHeight
            EditorGUILayout.PropertyField(m_jumpHeight);

            if(m_jumpHeight.floatValue > 10f)
            {
                // if player can jump more than 10 units,
                // Draw PlayerEditor.m_doubleJumpHeight for Player.doubleJumpHeight
                EditorGUILayout.PropertyField(m_doubleJumpHeight);
            }
        }

        if(EditorGUI.EndChangeCheck())
        {
            // If any serialized variable changed,
            // Apply modified values to the serialized properties
            serializedObject.ApplyModifiedProperties();
        }
    }
}