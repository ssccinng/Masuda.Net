# QQ频道机器人官方接口（C#） (.net6/.net5/.net framework 4.7.2) 
实现了一个简易的C#的接口封装，由于目前消息权限卡的很死，需要配置语料才能发送，请注意。
- ~~个人开发者需要用ReplyMessageAsync以回复的方式发送消息，回复的消息目前必须与语料配置完全一致才能发出去(tx你在干什么啊tx)。~~
- 上条作废，在沙箱环境中目前可以任意回复。(niiiice)
- 如果不行请在官方管理平台 [https://bot.q.qq.com/] 完成语料配置再测试
- ~~日程官方似乎还未实装功能~~
- appid是int类型，appkey，token是string类型，目前appkey不是必须要的值可以随意填入。其他两个按自己的bot信息填入。
- 如果遇到权限问题请尝试踢出机器人再重新加入
- ~~未来接口可能还会有比较大的改动，请注意。~~
- 有疑问欢迎提出issue或联系QQ1078995020

__注意，使用沙箱模式时有可能会遇到 websocket link not exist 的报错，此时切换成正式模式大概率能恢复正常__

## 说明
目前本项目依赖于.NET6/.NET5/.NET Framework 4.7.2。  
大部分C#项目均可兼容使用本包   
本项目力图提供极简风格的api，以实现尽可能少的代码完成bot配置，可参考以下例子段落。  


## 小功能
- api中所用的时间戳，可以通过以下方法获取
``` C#
    DateTime.Now.ToMillisecond();
```
- uint类型的Color可以用类似
__0x1AC456__
这样赋值，本SDK中也提供了HexColor的属性值来通过字符串设定
__"1AC456"__
- 收到了AT消息后可以通过以下函数获取去除at消息后的内容
``` C#
    // GetPureMessage自动实现该过程 <@!xxxxxx> 123 -> 123;
    var pureMessage = MessageHelper.GetPureMessage(msg.Content);
```
-  x.0.3及版之后可以直接传入msg进行at
``` C#
    // 直接传入msg以自动填充ChannelId和MsgId
    await bot.ReplyMessageAsync(msg, new AtMessage(msg));
```
## 如何安装
1. VS2022/19通过Nuget包管理器搜索Masuda.Net即可安装。vs19推荐使用5.x.x版本, vs22推荐使用6.x.x版本。更之前的版本推荐使用4.7.x.x版本的包
2. 在项目命令行中输入(需要.net环境)
``` ps
# .net5
dotnet add package Masuda.Net --version 5.0.10
# .net6
dotnet add package Masuda.Net --version 6.0.10
# .net framework 472
dotnet add package Masuda.Net --version 4.7.3.10
```

## 例子


以下为回复一条消息的简单实现
``` C#
using Masuda.Net;
using Masuda.Net.Models;
using Masuda.Net.HelpMessage;

MasudaBot MasudaBot
    = new(appid, appkey, token);

// 现以加入默认配置 私域 简洁初始化
MasudaBot MasudaBot2
    = new(appid, appkey, token, BotType.Private);



// 配置回复事件模板
MasudaBot.AtMessageAction += async (bot, msg, type) => 
{ 
    // 回复文本
    await bot.ReplyMessageAsync(msg, "muda");
    // 组合消息
    await bot.ReplyMessageAsync(msg, new AtMessage(msg), new PlainMessage("muda"));
    
    // 多个参数自动拼接
    await bot.ReplyMessageAsync(msg, new AtMessage(msg), new PlainMessage("muda"), new AtMessage(msg));
    // 图片和文字目前不能一起传，若以后支持可向上面那样拼接, 另外一个消息只能带一张图，传入多个ImageMessage会覆盖
    await bot.ReplyMessageAsync(msg, new ImageMessage("imgurl"));
    //
};

// 阻塞程序，可以用其他任何方法
while (true)
{
    await Task.Delay(10000);
}
```
### __配置bot的方法__
以下方式均可启动bot
``` C#
// 现以加入默认配置 公域
MasudaBot MasudaBot
    = new(appid, appkey, token, BotType.Public);

// 现以加入默认配置 私域
MasudaBot MasudaBot
    = new(appid, appkey, token, BotType.Private);

// 指定log位置

// 指定输出到文件
MasudaBot MasudaBot
    = new(appid, appkey, token, BotType.Public).LogTo((log) => File.AppendAllText("bot.log", log));
    
// 指定输出到Console
MasudaBot MasudaBot
    = new(appid, appkey, token, BotType.Public).LogTo(Console.WriteLine);

// 通过botsetting配置bot
BotSetting BotSetting = new BotSetting
{
    AppId = 0,
    AppKey = "",
    Token = "",
    Intents = new[] { Intent.AT_MESSAGES },
    SandBox = false,
    Log = true,
    // 为-1则默认不分片
    ShardId = -1
};
MasudaBot masudaBot = new MasudaBot(BotSetting);

// 直接通过缺省进行配置
MasudaBot MasudaBot1
    = new(appid, appkey, token, sandBox: true);
// 带命令行log输出
MasudaBot MasudaBot
    = new(appid, appkey, token, log: true);
    
// 指定权限配置
// 默认会请求Intent.AT_MESSAGES, Intent.GUILDS, Intent.GUILD_MEMBERS, Intent.GUILD_MESSAGE_REACTIONS四个权限, 如已开启了私域，可再请求Intent.NORMAL_MESSAGES权限
MasudaBot MasudaBot
    = new(appid, appkey, token, intents: new[] { Intent.GUILDS, Intent.AT_MESSAGES});

// 缺省参数也可以混用
MasudaBot MasudaBot
    = new(appid, appkey, token, log: true, intents: new[] { Intent.GUILDS, Intent.AT_MESSAGES, Intent.NORMAL_MESSAGES});
```
### __消息事件注册__
```C#

// 普通消息事件注册(需要私域)
MasudaBot.MessageAction += async (bot, msg, type) => 
{ 
    // 回复文本
    await bot.ReplyMessageAsync(msg, "muda");
    // 组合消息
    await bot.ReplyMessageAsync(msg, new PlainMessage("muda"), new AtMessage(msg.Author.Id));
    //
};
```

```C#

// 成员更新事件注册
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
```


## Intent表
``` C#
public enum Intent
{
    GUILDS = 1 << 0,
    GUILD_MEMBERS = 1 << 1,
    NORMAL_MESSAGES = 1 << 9,
    GUILD_MESSAGE_REACTIONS = 1 << 10,
    DIRECT_MESSAGE = 1 << 12,
    FORUM_EVENT = 1 << 28,
    AUDIO_ACTION = 1 << 29,
    AT_MESSAGES = 1 << 30,
}
```


# Q&A
- Q. 我想发一张图片应该要怎么写?  
- A. 
```C#
// url为图片网络地址 目前暂时不能发本地图片 
await bot.ReplyMessageAsync(msg, new ImageMessage(url));
```
当然，也支持这样
```C#
// url为图片网络地址 目前暂时不能发本地图片 
await bot.ReplyMessageAsync(msg, new AtMessage(msg), new ImageMessage(url));
```
- Q. 我想获取非at消息应该怎么样申请权限?  
- A. 
```C#
// 权限列表可以按需添加 
MasudaBot MasudaBot
    = new(appid, appkey, token, intents: new[] { Intent.GUILDS, Intent.AT_MESSAGES, Intent.NORMAL_MESSAGES});
```
- Q. 我想@人并发消息应该怎么写?
- A. 
```C#
await bot.ReplyMessageAsync(msg, new AtMessage(msg), new PlainMessage("muda"));
```

- Q. 我想发送QQ表情应该怎么做
- A. emoji可以直接用字符发送例如"♥", QQ表情官方还不支持发送。
   

- Q. 我想输出Log到文件应该怎么做
- A. 

```C#
MasudaBot MasudaBot3
    = new(appid, appkey, token, BotType.Public).LogTo((log) => File.AppendAllText("bot.log", log));
```