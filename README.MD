# QQ频道机器人官方接口（C#）
实现了一个简易的C#的接口封装，由于目前消息权限卡的很死，需要配置语料才能发送，请注意。
- ~~个人开发者需要用ReplyMessageAsync以回复的方式发送消息，回复的消息目前必须与语料配置完全一致才能发出去(tx你在干什么啊tx)。~~
- 上条作废，在沙箱环境中目前可以任意回复。(niiiice)
- 如果不行请在官方管理平台 [https://bot.q.qq.com/] 完成语料配置再测试
- 日程官方似乎还未实装功能
- appid是int类型，appkey，token是string类型，目前appkey不是必须要的值可以随意填入。其他两个按自己的bot信息填入。
- 如果遇到权限问题请尝试踢出机器人再重新加入
- 未来接口可能还会有比较大的改动，请注意。
- 有疑问欢迎提出issue或联系QQ1078995020

## 说明
目前本项目依赖于.NET6/.NET5，未来可能考虑加入之前版本的包。  
本项目力图提供极简风格的api，以实现尽可能少的代码完成bot配置，可参考以下例子。  
~~由于目前很多接口由于过于严格的审核机制导致测试起来很麻烦，目前关于消息方面仅提供简单的文字回复接口，未来测试完毕后会更新。~~

## 小功能
- api中所用的时间戳，可以通过以下方法获取
``` C#
DateTime.Now.ToMillisecond();
```
- uint类型的Color可以用类似0x1AC456这样赋值，本SDK中也提供了HexColor的属性值来通过字符串设定
- 收到了AT消息后可以通过以下函数获取去除at消息后的内容
``` C#
GetPureMessage(msg.Content);
```
## 如何安装
1. VS2022/19通过Nuget包管理器搜索Masuda.Net即可安装。vs19推荐使用5.x.x版本, vs22推荐使用6.x.x版本
2. 在项目命令行中输入(需要.net环境)
``` ps
# .net5
dotnet add package Masuda.Net --version 5.0.1
# .net6
dotnet add package Masuda.Net --version 6.0.1
```

## 例子
以下为回复一条消息的简单实现
``` C#
using Masuda.Net;
using Masuda.Net.HelpMessage;

MasudaBot MasudaBot
    = new(appid, appkey, token);
// 沙箱环境
MasudaBot MasudaBot1
    = new(appid, appkey, token, sandBox: true);

// 配置回复事件模板
MasudaBot.AtMessageAction += async (bot, msg, type) => 
{ 
    // 回复文本
    await bot.ReplyMessageAsync(msg, "muda");
    // 组合消息
    await bot.ReplyMessageAsync(msg, new PlainMessage("muda"), new AtMessage(msg.Author.Id));
    //
};

// 阻塞程序，可以用其他任何方法
while (true)
{
    await Task.Delay(10000);
}
```
### 另有其他几种启动模式
``` C#
// 带命令行log输出
MasudaBot MasudaBot
    = new(appid, appkey, token, log: true);
    
// 指定权限
// 默认会请求Intent.AT_MESSAGES, Intent.GUILDS, Intent.GUILD_MEMBERS三个权限, 如已开启了私域，可再请求Intent.NORMAL_MESSAGES权限
MasudaBot MasudaBot
    = new(appid, appkey, token, intents: new[] { Intent.GUILDS, Intent.AT_MESSAGES});

// 缺省参数也可以混用
MasudaBot MasudaBot
    = new(appid, appkey, token, log: true, intents: new[] { Intent.GUILDS, Intent.AT_MESSAGES});


// 普通消息事件注册
MasudaBot.MessageAction += async (bot, msg, type) => 
{ 
    // 回复文本
    await bot.ReplyMessageAsync(msg, "muda");
    // 组合消息
    await bot.ReplyMessageAsync(msg, new PlainMessage("muda"), new AtMessage(msg.Author.Id));
    //
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


