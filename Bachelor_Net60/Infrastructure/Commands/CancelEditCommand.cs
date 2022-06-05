using Bachelor_Net60.Infrastructure.Commands.Base;
using System;

namespace Bachelor_Net60.Infrastructure.Commands
{
    class CancelEditCommand : Command
    {
        public bool? DialogResult { get; set; }
        protected override bool CanExecute(object p) => true;
        protected override void Execute(object p)
        {
            
        }
    }
}
