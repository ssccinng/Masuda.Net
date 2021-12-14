# QQ频道机器人官方接口（C#）
实现了一个简易的C#的接口封装，由于目前消息权限卡的很死，需要配置语料才能发送，请注意。
- ~~个人开发者需要用ReplyMessageAsync以回复的方式发送消息，回复的消息目前必须与语料配置完全一致才能发出去(tx你在干什么啊tx)。~~
- 上条作废，在沙箱环境中目前可以任意回复。(niiiice)
- 日程官方似乎还未实装功能
- appid是int类型，appkey，token是string类型，目前appkey不是必须要的值可以随意填入。其他两个按自己的bot信息填入。
- 未来接口可能还会有比较大的改动，请注意。
- 有疑问欢迎提出issue或联系QQ1078995020

## 说明
目前本项目依赖于.NET6，未来可能考虑加入之前版本的包。  
本项目力图提供极简风格的api，以实现尽可能少的代码完成bot配置，可参考以下例子。  
由于目前很多接口由于过于严格的审核机制导致测试起来很麻烦，目前关于消息方面仅提供简单的文字回复接口，未来测试完毕后会更新。

## 如何安装
1. VS2022通过Nuget包管理器搜索Masuda.Net即可安装
2. 在项目命令行中输入(需要.net环境)
``` ps
dotnet add package Masuda.Net
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
    = new(appid, appkey, token, true);
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

