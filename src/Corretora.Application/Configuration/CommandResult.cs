namespace Corretora.Application.Configuration
{
    public struct CommandResult
    {
        public bool Sucess { get; }

        public readonly dynamic Value { get; }

        public CommandResult(bool sucess, dynamic value = null)
        {
            this.Sucess = sucess;
            this.Value = value;
        }

        public static CommandResult Ok(dynamic value = null)
        {
            return new CommandResult(true, value);
        }

        public static CommandResult Fail()
        {
            return new CommandResult(false);
        }

    }
}
