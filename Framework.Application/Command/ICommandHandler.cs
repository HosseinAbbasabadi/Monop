using Framework.Core;

namespace Framework.Application.Command
{
    public interface ICommandHandler<in T, out TH> : IService where T : ICommand
    {
        TH Handle(T command);
        //List<TH> Handle<TH>(T command);
    }

    public interface ICommandHandler<in T> : IService where T : ICommand
    {
        void Handle(T command);
    }
}