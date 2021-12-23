using Masuda.Net;
using Masuda.Net.Models;
using System.Text.RegularExpressions;
using Masuda.Net.HelpMessage;
// 000换成你的机器人id
// you token换成你的机器人token
MasudaBot MasudaBot
    = new MasudaBot(000, "", "you token", BotType.Public);

MasudaBot.AtMessageAction += async (bot, msg, type) =>
{
    string pureMsg = MessageHelper.GetPureMessage(msg.Content);
    switch (pureMsg)
    {
        case "来点图":
            await bot.ReplyMessageAsync(msg, new ImageMessage("https://img0.baidu.com/it/u=3329014026,3552557889&fm=26&fmt=auto"));
            break;
        case "来点图文":
            await bot.ReplyMessageAsync(msg, new PlainMessage("西狮海壬"), new ImageMessage("https://img0.baidu.com/it/u=3329014026,3552557889&fm=26&fmt=auto"));
            break;
        case "atme":
            await bot.ReplyMessageAsync(msg, new AtMessage(msg), new PlainMessage("我来了"));
            break;
        case string x when x.StartsWith("复读"):
            await bot.ReplyMessageAsync(msg, pureMsg[2..].Trim());
            break;
        default:
            break;
    }
};
MasudaBot.GuildMembersAction += async (bot, member, type) =>
{
    switch (type)
    {
        case ActionType.GUILD_MEMBER_ADD:
            var cs = await bot.GetChannelsAsync(member.GuildId);
            // 在第一个名字有hello的频道欢迎新成员
            await bot.SendMessageAsync(cs.First(s => s.Name.Contains("Hello")).Id, new AtMessage(member.User.Id), new PlainMessage($"欢迎{member.User.Username}来玩"));
            break;
        case ActionType.GUILD_MEMBER_UPDATE:
            break;
        case ActionType.GUILD_MEMBER_REMOVE:
            var cs1 = await bot.GetChannelsAsync(member.GuildId);
            await bot.SendMessageAsync(cs1.First(s => s.Name.Contains("小黑屋")).Id, new AtMessage(member.User.Id), new PlainMessage($"{member.User.Username}被踢出"));
            // 在第一个名字有hello的频道欢迎新成员
            break;       
        default:
            break;
    }
};
while (true)
{
    await Task.Delay(10000);
}