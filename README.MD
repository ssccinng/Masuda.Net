# QQ频道机器人官方接口（C#）
实现了一个简易的C#的接口封装，由于目前消息权限卡的很死，需要配置语料才能发送，请注意

## 例子
以下为回复一条消息的简单实现
``` C#
using Masuda.Net;

MasudaBot MasudaBot
    = new(appid, appkey, token);

MasudaBot.AtMessageAction += async (bot, msg) => 
{ 
    await bot.ReplyMessageAsync(msg, "muda");
};
while (true)
{
    await Task.Delay(10000);
}

