namespace OOP_Examples
{
    /// <summary>
    /// Bad inheratance example
    /// because Traffic light and person
    /// are two different entities
    /// </summary>
    public class Inheritance2
    {
        class TrafficLight
        {
            protected string[] _trafficLightState = {"Green", "Yellow", "Red"};
            protected int _currentState = 0;
        }

        class Person : TrafficLight
        {
            public int Salary { get; set; }
        }

    }
}