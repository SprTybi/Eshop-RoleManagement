namespace EshopMashtiHasan.Models
{
    public class ControllerAndActions
    {
        public ControllerAndActions(string controller, List<string> actions)
        {
            Controller = controller;
            Actions = actions;
        }
        public string Controller { get; }
        public List<string> Actions { get; }
    }
}
