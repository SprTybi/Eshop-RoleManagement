using EshopMashtiHasan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using System.Reflection;

namespace EshopMashtiHasan.Controllers
{
    public class ReflectorController : Controller
    {
        private readonly IProjectActionBuss actionBuss;
        private readonly IProjectControllerBuss controllerBuss;
        public ReflectorController(IProjectActionBuss actionBuss, IProjectControllerBuss controllerBuss)
        {
            this.actionBuss = actionBuss;
            this.controllerBuss = controllerBuss;
        }

        public List<AreaControllerActionList> Ref()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var ACAList = assembly.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Select(x => new
                    {
                        Controller = x.DeclaringType.Name,
                        Action = x.Name,
                        Area = x.DeclaringType.CustomAttributes.Where(c => c.AttributeType == typeof(AreaAttribute))

                    }).ToList();
            var list = new List<AreaControllerActionList>();
            foreach (var item in ACAList)
            {
                if (item.Area.Count() != 0)
                {
                    list.Add(new AreaControllerActionList()
                    {
                        ControllerName = item.Controller,
                        ActionName = item.Action,
                        AreaName = item.Area.Select(v => v.ConstructorArguments[0].Value.ToString()).FirstOrDefault()
                    });
                }
                else
                {
                    list.Add(new AreaControllerActionList()
                    {
                        ControllerName = item.Controller,
                        ActionName = item.Action,
                        AreaName = null,
                    });
                }
            }
            return list;
        }

        public static List<ControllerAndActions> GetAllControllersAndActions()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> controllers = assembly.GetTypes().Where(type => type.Name.EndsWith("Controller"));
            var theList = new List<ControllerAndActions>();

            foreach (Type curController in controllers)
            {
                List<string> actions = curController.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                    .Where(m => m.CustomAttributes.Any(a => typeof(HttpMethodAttribute).IsAssignableFrom(a.AttributeType)))
                    .Select(x => x.Name)
                    .ToList();

                theList.Add(new ControllerAndActions(curController.Name, actions));
            }

            return theList;
        }

        public IActionResult AddAll()
        {
            var q = GetAllControllersAndActions();
            foreach (var item in q)
            {
                var cont = new ProjectControllerAddModel
                {
                    ProjectControllerName = item.Controller,
                    ProjectAreaID = 1
                };
                controllerBuss.Register(cont);
            }
            var d = Ref();
            foreach (var item in d)
            {
                var Act = new ProjectActionAddModel
                {
                    ProjectActionName = item.ActionName,
                    ProjectControllerID = actionBuss.GetProjectController(item.ControllerName),

                };
                actionBuss.Register(Act);
            }

            return View();
        }

        public IActionResult Index()
        {
            var r = Ref();
            return View(r);
        }
    }
}
