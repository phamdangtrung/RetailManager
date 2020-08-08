using Caliburn.Micro;
using RMDesktopUI.Helpers;
using RMDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            //EventAggregator handles events
            //Singleton should be used wisely
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAPIHelper, APIHelper>();

            //Get all types of the currect project (aka Assembly). 
            //The current project then proceeds to get all types which are classes
            //Then further limits it with classes ended with "ViewModel"
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList() //Then add those classes to an IEnumerable list to do a foreach loop below
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));

        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();

        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
        
        protected override IEnumerable<Object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance); 
        }
    }
}
