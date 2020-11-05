using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

public class LoggingService
{
	public LoggingService(DiscordSocketClient client, CommandService command)
	{
		client.Log += LogAsync;
		command.Log += LogAsync;
	}
	private Task LogAsync(LogMessage message)
	{
		if (message.Exception is CommandException cmdException)
		{
			Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Command/{ message.Severity}] { cmdException.Command.Aliases.First()}" + $" failed to execute in { cmdException.Context.Channel}.");
            Console.ResetColor();
            Console.WriteLine(cmdException);
		}
        else
        {
			if (message.Severity is LogSeverity.Error)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"[General/{message.Severity}] {message}");
				Console.ResetColor();
			}
			else if (message.Severity is LogSeverity.Warning)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"[General/{message.Severity}] {message}");
				Console.ResetColor();
			}
			else if (message.Severity is LogSeverity.Critical)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"[General/{message.Severity}] {message}");
				Console.ResetColor();
			}
			else if (message.Severity is LogSeverity.Info)
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine($"[General/{message.Severity}] {message}");
				Console.ResetColor();
			}
			else if (message.Severity is LogSeverity.Verbose)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine($"[General/{message.Severity}] {message}");
				Console.ResetColor();
			}
		}
			

		return Task.CompletedTask;
	}
}