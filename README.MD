# QQ频道机器人官方接口（C#）
实现了一个简易的C#的接口封装，由于目前消息权限卡的很死，需要配置语料才能发送，请注意

## 例子
以下为回复一条消息的简单实现
``` C#
MasudaBot MasudaBot
    = new MasudaBot(appid, appkey, token);

MasudaBot.ListenMessage += async (bot, msg) => { 
    await bot.ReplyMessageAsync(msg, "muda");
};
```