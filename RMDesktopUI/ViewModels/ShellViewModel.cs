using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMDesktopUI.EventModels;

namespace RMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private readonly IEventAggregator _events;
        private SalesViewModel _salesVM;
        private SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM,
            SimpleContainer container)
        {
            _events = events;
            _salesVM = salesVM;
            _container = container;

            //Caliburn Micro will remember who's subscribing so when an event is fired up, it'll broadcast to all the subscribers
            //Even when they're not listening to that particular type
            _events.Subscribe(this);

            //Get a new instance of LoginViewModel and place it into _loginVM so it'll be clean and fresh and not contain any sensitive info in it
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
        }
    }
}
