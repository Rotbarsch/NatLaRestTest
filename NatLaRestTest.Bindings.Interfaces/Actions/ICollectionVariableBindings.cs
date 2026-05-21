namespace NatLaRestTest.Bindings.Interfaces.Actions;

/// <summary>
/// Step bindings for actions on collection variables (e.g., lists of items).
/// </summary>
public interface ICollectionVariableBindings
{
    void StoreCollectionLengthInVariable(string collectionVariableName, string targetVariableName);
}