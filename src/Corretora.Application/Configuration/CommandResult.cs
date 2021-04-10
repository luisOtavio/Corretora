namespace Corretora.Application.Configuration
{
    public struct CommandResult
    {
        public bool Sucess { get; }

        public CommandResult(bool sucess)
        {
            this.Sucess = sucess;
        }

        public static CommandResult Ok()
        {
            return new CommandResult(true);
        }

        public static CommandResult Fail()
        {
            return new CommandResult(false);
        }

    }
}
