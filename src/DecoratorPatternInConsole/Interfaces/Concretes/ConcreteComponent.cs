namespace DecoratorPatternInConsole.Interfaces.Concretes;

// The Concrete Component provides the default implementation of the operations.
// There might be several variations of these classes.

public class ConcreteComponent : Component
{
    public override string Operation()
    {
        return "ConcreteComponent";
    }
}
