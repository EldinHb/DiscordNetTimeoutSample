using Discord;
using Discord.WebSocket;

var client = new DiscordSocketClient();
client.InteractionCreated += async interaction =>
{
	await interaction.RespondAsync("hello world");
};

client.Ready += async () =>
{
	var slashCommand = new SlashCommandBuilder()
	.WithName("atestcommand")
	.WithDescription("adescriptionfortestcommand");
	// await client.CreateGlobalApplicationCommandAsync(slashCommand.Build());
	var guild = client.GetGuild(1);
	await guild.CreateApplicationCommandAsync(slashCommand.Build());
};

await client.LoginAsync(TokenType.Bot, "bottokn");
await client.StartAsync();

await Task.Delay(-1);

await client.DisposeAsync();