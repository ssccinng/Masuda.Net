using Masuda.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Masuda.Net.HelpMessage;
using System.Net.WebSockets;
using System.Threading;
using System.Net.Http;

namespace Masuda.Net
{
    public partial class MasudaBot
    {


        private static async Task<bool> HttpLog(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage == null) return false;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine(await httpResponseMessage.Content.ReadAsStringAsync());
                return false;
            }
            return true;
        }


        
        #region 频道API
        /// <summary>
        /// 获取频道信息(暂不可用)
        /// </summary>
        /// <returns></returns>
        public async Task<Guild?> GetGuildAsync(string guildId)
        {
            Guild? guild = await _httpClient.GetFromJsonAsync<Guild>($"{_testUrl}/guilds/{guildId}");
            if (guild == null) return null;
            return guild;
        }
        #endregion

        #region 频道身份组API
        /// <summary>
        /// 获取频道身份组
        /// </summary>
        /// <param name="guildId"></param>
        /// <returns></returns>
        public async Task<GuildRoles> GetGuildRolesAsync(string guildId)
        {
            var res = await _httpClient.GetFromJsonAsync<GuildRoles>($"{_testUrl}/guilds/{guildId}/roles");
            
            return res;
        }
        /// <summary>
        /// 创建频道身份组
        /// </summary>
        /// <param name="guildId">频道id</param>
        /// <param name="filter">标识需要设置哪些字段</param>
        /// <param name="info">携带需要设置的字段内容</param>
        /// <returns></returns>
        public async Task<CreateRoleRes> CreateRoleAsync(string guildId, Filter filter, Info info)
        {
            var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/guilds/{guildId}/roles", new { filter = filter, info = info });
            await HttpLog(res);
            return await res.Content.ReadFromJsonAsync<CreateRoleRes>();
        }
        public async Task<ModifyRolesRes> ModifyRolesAsync(string guildId, string roleId, Filter filter, Info info)
        {
            var res = await _httpClient.PatchAsync($"{_testUrl}/guilds/{guildId}/roles", JsonContent.Create(new { filter = filter, info = info }));
            return await res.Content.ReadFromJsonAsync<ModifyRolesRes>();
        }
        /// <summary>
        /// 删除身份组
        /// </summary>
        /// <param name="guildId">频道id</param>
        /// <param name="roleId">身份Id</param>
        /// <returns></returns>
        public async Task DeleteRoleAsync(string guildId, string roleId)
        {
            await _httpClient.DeleteAsync($"{_testUrl}/guilds/{guildId}/roles/{roleId}");
        }
        /// <summary>
        /// 增加频道身份组成员
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="channelId"></param>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task AddMemberToRoleAsync(string guildId, string userId, string roleId, string channelId)
        {
            if (channelId == null)
            {
                await _httpClient.PutAsync($"{_testUrl}/guilds/{guildId}/members/{userId}/roles/{roleId}", null);
            }
            else
            {
                await _httpClient.PutAsJsonAsync($"{_testUrl}/guilds/{guildId}/members/{userId}/roles/{roleId}", new Channel { Id = channelId });
            }
        }

        public async Task DeleteMemberToRoleAsync(string guildId, string userId, string roleId, string channelId = null)
        {
            if (channelId == null)
            {
                await _httpClient.DeleteAsync($"{_testUrl}/guilds/{guildId}/members/{userId}/roles/{roleId}");
            }
            else
            {

            }

        }
        #endregion

        #region 成员API
        public async Task<Member> GetGuildMemberAsync(string guildId, string userId)
        {
            return await _httpClient.GetFromJsonAsync<Member>($"{_testUrl}/guilds/{guildId}/members/{userId}");
        }
        #endregion

        #region 公告API
        /// <summary>
        /// 创建子频道公告 机器人设置消息为指定子频道公告
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public async Task<Announces> CreateAnnouncesAsync(string channelId, string messageId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{channelId}/announces", new { message_id = messageId });
            return await res.Content.ReadFromJsonAsync<Announces>();
        }
        /// <summary>
        /// 创建子频道公告 机器人设置消息为指定子频道公告
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public async Task<Announces> CreateAnnouncesAsync(Message message)
        {
            var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{message.ChannelId}/announces", new { message_id = message.Id });
            return await res.Content.ReadFromJsonAsync<Announces>();
        }
        /// <summary>
        /// 机器人删除指定子频道公告
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task DeleteAnnouncesAsync(string channelId, string messageId)
        {
            await _httpClient.DeleteAsync($"{_testUrl}/channels/{channelId}/announces/{messageId}");
        }

        /// <summary>
        /// 机器人删除指定子频道公告
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task DeleteAnnouncesAsync(Message message)
        {
            await _httpClient.DeleteAsync($"{_testUrl}/channels/{message.ChannelId}/announces/{message.Id}");
        }
        #endregion

        #region 子频道API
        /// <summary>
        /// 获取频道的子频道列表
        /// </summary>
        /// <returns>子频道列表</returns>
        public async Task<List<Channel>> GetChannelsAsync(string guildId)
        {
            var channels = await _httpClient.GetFromJsonAsync<List<Channel>>($"{_testUrl}/guilds/{guildId}/channels");
            return channels;
            //if (guild == null) return null;
            //return guild;
        }

        /// <summary>
        /// 获取频道的子频道列表
        /// </summary>
        /// <returns>子频道列表</returns>
        public async Task<List<Channel>> GetChannelsAsync(string guildId, ChannelType channelType)
        {
            //var channels = await _httpClient.GetFromJsonAsync<List<Channel>>($"{_testUrl}/guilds/{guildId}/channels");
            return (await GetChannelsAsync(guildId)).Where(s => s.Type == channelType).ToList();
            //if (guild == null) return null;
            //return guild;
        }
        /// <summary>
        /// 获取频道的子频道列表
        /// </summary>
        /// <returns>子频道列表</returns>
        public async Task<List<Channel>> GetChannelsAsync(string guildId, ChannelType channelType, ChannelSubType channelSubType)
        {
            return (await GetChannelsAsync(guildId)).Where(s => s.Type == channelType && s.SubType == channelSubType).ToList();
            //if (guild == null) return null;
            //return guild;
        }
        /// <summary>
        /// 获取子频道信息
        /// </summary>
        /// <returns></returns>
        public async Task<Channel> GetChannelAsync(string channelId)
        {
            Channel guild = await _httpClient.GetFromJsonAsync<Channel>($"{_testUrl}/channels/{channelId}");
            return guild;
        }

        #endregion

        #region 子频道权限API
        /// <summary>
        /// 获取用户子频道权限
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ChannelPermissions> GetChannelPermissionsAsync(string channelId, string userId)
        {
            return await _httpClient.GetFromJsonAsync<ChannelPermissions>($"{_testUrl}/channels/{channelId}/members/{userId}/permissions");
        }
        /// <summary>
        /// 修改用户子频道权限
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="userId"></param>
        /// <param name="add"></param>
        /// <param name="remove"></param>
        /// <returns></returns>
        public async Task ModifyChannelPermissionsAsync(string channelId, string userId, string add = "0", string remove = "0")
        {
            await _httpClient.PutAsJsonAsync<object>($"{_testUrl}/channels/{channelId}/members/{userId}/permissions", new { add = add, remove = remove });
        }

        #endregion

        #region 消息API

        /// <summary>
        /// 发送简单消息
        /// 要求操作人在该子频道具有发送消息的权限。
        /// 发送成功之后，会触发一个创建消息的事件。
        /// 被动回复消息有效期为 5 分钟
        /// 主动推送消息每日每个子频道限 2 条
        /// 发送消息接口要求机器人接口需要链接到websocket gateway 上保持在线状态
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<Message> SendMessageAsync(string channelId, string content)
        {
            var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{channelId}/messages", new { content = content });
            return await res.Content.ReadFromJsonAsync<Message>();
        }

        //public async Task<Message> SendMessageAsync(string channelId, string content)
        //{
        //    var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{channelId}/messages", new { content = content });
        //    return await res.Content.ReadFromJsonAsync<Message>();
        //}
        public async Task<Message> SendMessageAsync(Message message, string content)
        {
            return await SendMessageAsync(message.ChannelId, content);
            //var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{message.ChannelId}/messages", new { content = content });
            //return await res.Content.ReadFromJsonAsync<Message>();
        }

        public async Task<Message> SendMessageAsync(Channel channel, string content)
        {
            return await SendMessageAsync(channel.Id, content);
            //var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{channel.Id}/messages", new { content = content });
            //return await res.Content.ReadFromJsonAsync<Message>();
        }

        /// <summary>
        /// 回复消息简洁版
        /// </summary>
        /// <param name="message"></param>
        /// <param name="pmessageBases"></param>
        /// <returns></returns>
        public async Task<Message> SendMessageAsync(Message message, params MessageBase[] pMessageBases)
        {
            message.Id = null;
            return await MessageCoreAsync(message, messageBases: pMessageBases);
        }
        public async Task<Message> SendMessageAsync(string channelId, params MessageBase[] pMessageBases)
        {
            //message.Id = null;
            return await MessageCoreAsync(channelId, null, messageBases: pMessageBases);
        }
        #region TEST

        //public async Task<Message> SendEmbedMessageAsync(Message message, MessageEmbed embed)
        //{
        //    //return await SendMessageAsync(channel.Id, content);
        //    var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{message.ChannelId}/messages", new { embed = embed });
        //    if (!res.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine(await res.Content.ReadAsStringAsync());
        //    }
        //    return await res.Content.ReadFromJsonAsync<Message>();
        //}
        //public async Task<Message> SendArkMessageAsync(Message message, MessageArk ark)
        //{
        //    //return await SendMessageAsync(channel.Id, content);
        //    var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{message.ChannelId}/messages", new { ark = ark });
        //    if (!res.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine(await res.Content.ReadAsStringAsync());
        //    }
        //    return await res.Content.ReadFromJsonAsync<Message>();
        //}
        //public async Task<Message> ReplyArkMessageAsync(Message message, MessageArk ark)
        //{
        //    //return await SendMessageAsync(channel.Id, content);
        //    var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{message.ChannelId}/messages", new { ark = ark, msg_id = message.Id });
        //    if (!res.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine(await res.Content.ReadAsStringAsync());
        //    }
        //    return await res.Content.ReadFromJsonAsync<Message>();
        //}

        //public async Task<Message> ReplyEmbedMessageAsync(Message message, MessageEmbed embed)
        //{
        //    //return await SendMessageAsync(channel.Id, content);
        //    var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{message.ChannelId}/messages", new { embed = embed, msg_id = message.Id });
        //    if (!res.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine(await res.Content.ReadAsStringAsync());
        //    }
        //    return await res.Content.ReadFromJsonAsync<Message>();
        //}


        #endregion


        public async Task<Message> ReplyMessageAsync(string channelId, string content, string msgId)
        {

            var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{channelId}/messages", new { content = content, msg_id = msgId });
            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
            return await res.Content.ReadFromJsonAsync<Message>();
        }

        public async Task<Message> ReplyMessageAsync(Message message, string content)
        {
            return await ReplyMessageAsync(message.ChannelId, content, message.Id);
            //var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{message.ChannelId}/messages", new { content = content, msg_id = message.Id });
            //if (!res.IsSuccessStatusCode)
            //{
            //    Console.WriteLine(await res.Content.ReadAsStringAsync());
            //}
            //return await res.Content.ReadFromJsonAsync<Message>();
        }

        public async Task<Message> ReplyMessageAsync(Message message, string content, ImageMessage imageMessage)
        {
            var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{message.ChannelId}/messages", new {  msg_id = message.Id,  image = imageMessage.Url });
            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
            return await res.Content.ReadFromJsonAsync<Message>();
        }

        private async Task<Message> MessageCoreAsync(string channelId, string msgId, MessageBase[] messageBases = null)
        {
            //if (messageBases.Length == 0) return null;
            MessageSend msg = new MessageSend();
            if (messageBases != null)
            {
                StringBuilder content = new();
                foreach (var messageb in messageBases)
                {
                    switch (messageb)
                    {
                        case AtMessage atMessage:
                            content.Append(atMessage);
                            break;
                        case ImageMessage imageMessage:
                            msg.Image = imageMessage.Url;
                            break;
                        case PlainMessage plainMessage:
                            content.Append(plainMessage);
                            break;
                        case MessageEmbed messageEmbed:
                            msg.Embed = messageEmbed;
                            break;
                        case MessageArk messageArk:
                            msg.Ark = messageArk;
                            break;
                        default:
                            break;
                    }
                }
                if (content.Length > 0)
                    msg.Content = content.ToString();
            }


            if (msgId != null)
                msg.MsgId = msgId;
            var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{channelId}/messages", msg);
            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
            return await res.Content.ReadFromJsonAsync<Message>();
        }

        private async Task<Message> MessageCoreAsync(Message message, MessageBase[] messageBases = null)
        {
            return await MessageCoreAsync(message.ChannelId, message.Id, messageBases);
        }
        /// <summary>
        /// 回复消息简洁版
        /// </summary>
        /// <param name="message"></param>
        /// <param name="pmessageBases"></param>
        /// <returns></returns>
        public async Task<Message> ReplyMessageAsync(Message message, params MessageBase[] pMessageBases)
        {
            return await MessageCoreAsync(message, messageBases: pMessageBases);
        }
        public async Task<Message> ReplyMessageAsync(string channelId, string messageId, params MessageBase[] pMessageBases)
        {
            return await MessageCoreAsync(channelId, messageId, messageBases: pMessageBases);
        }
        /// <summary>
        /// 获取指定Id消息
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public async Task<Message> GetMessageAsync(string channelId, string msgId)
        {
            return await _httpClient.GetFromJsonAsync<Message>($"{_testUrl}/channels/{channelId}/messages/{msgId}");
        }
        #endregion

        #region 音频API
        public async Task AudioControlAsync(string channelId, string url, STATUS STATUS = STATUS.START, string text = "")
        {

            var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{channelId}/audio", new AudioControl { AudioUrl = url, Text = text, Status = STATUS });
            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
            //return await res.Content.ReadFromJsonAsync<Message>();
        }
        #endregion

        #region 用户API 
        /// <summary>
        /// 获取机器人所在频道列表 // 还有其他参数
        /// </summary>
        /// <returns>频道列表</returns>
        public async Task<List<Guild>> GetMeGuildsAsync()
        {
            var guilds = await _httpClient.GetFromJsonAsync<List<Guild>>($"{_testUrl}/users/@me/guilds");
            return guilds;
            //if (guild == null) return null;
            //return guild;
        }
        /// <summary>
        /// 获取机器人所在频道列表 // 还有其他参数
        /// </summary>
        /// <returns>频道列表</returns>
        public async Task<User> GetMeAsync()
        {
            return await _httpClient.GetFromJsonAsync<User>($"{_testUrl}/users/@me");
            //if (guild == null) return null;
            //return guild;
        }
        #endregion

        #region 日程API
        /// <summary>
        /// 获取频道日程列表
        /// </summary>
        /// <returns></returns>
        public async Task <List<Schedule>> GetSchedulesAsync(string channelId, string since = null)
        {
            var tt = await _httpClient.GetAsync($"{_testUrl}/channels/{channelId}/schedules");
            if (!tt.IsSuccessStatusCode)
            {
                Console.WriteLine(await tt.Content.ReadAsStringAsync());
                return null;
            }
            var ddd = await tt.Content.ReadAsStringAsync();
            return await _httpClient.GetFromJsonAsync<List<Schedule>>($"{_testUrl}/channels/{channelId}/schedules");
        }
        public async Task<List<Schedule>> GetSchedulesAsync(Channel channel, string since = null)
        {
            return await GetSchedulesAsync(channel.Id, since);
        }

        /// <summary>
        /// 获取日程信息
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public async Task<Schedule> GetScheduleAsync(string channelId, string scheduleId)
        {
            return await _httpClient.GetFromJsonAsync<Schedule>($"{_testUrl}/channels/{channelId}/schedules/{scheduleId}");
        }
        public async Task<Schedule> GetScheduleAsync(Channel channel, string scheduleId)
        {
            return await GetScheduleAsync(channel.Id, scheduleId);
        }
        /// <summary>
        /// 创建日程
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="schedule">日程对象，不需要带id</param>
        /// <returns></returns>
        public async Task<Schedule> CreateScheduleAsync(string channelId, Schedule schedule)
        {

            var vv = await GetMeAsync();
            var gg = await GetSchedulesAsync(channelId);
            //schedule.Creator = await GetGuildMemberAsync(GuildId, vv.Id);
            //gg[1].Id = null;
            var res = await _httpClient.PostAsJsonAsync($"{_testUrl}/channels/{channelId}/schedules", schedule);
            //var res = await _httpClient.PostAsync($"{_testUrl}/channels/{channelId}/schedules/", JsonContent.Create(schedule));
            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
                return null;
            }
            return await res.Content.ReadFromJsonAsync<Schedule>();
        }

        public async Task<Schedule> CreateScheduleAsync(Channel channel, Schedule schedule)
        {
            return await CreateScheduleAsync(channel.Id, schedule: schedule);
        }

        public async Task<Schedule> ModifyScheduleAsync(string channelId, string scheduleId)
        {
            var res = await _httpClient.PatchAsync($"{_testUrl}/channels/{channelId}/schedules/{scheduleId}", JsonContent.Create(scheduleId) );
            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.Content.ReadAsStringAsync());
            }
            return await res.Content.ReadFromJsonAsync<Schedule>();
        }
        public async Task<Schedule> ModifyScheduleAsync(Channel channel, string scheduleId)
        {
            return await ModifyScheduleAsync(channel.Id, scheduleId);
        }

        public async Task<Schedule> DeleteScheduleAsync(string channelId, string scheduleId)
        {
            var res = await _httpClient.DeleteAsync($"{_testUrl}/channels/{channelId}/schedules/{scheduleId}");
            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.Content.ReadAsStringAsync());
            }
            return await res.Content.ReadFromJsonAsync<Schedule>();
        }
        public async Task<Schedule> DeleteScheduleAsync(Channel channel, string scheduleId)
        {
            return await DeleteScheduleAsync(channel.Id, scheduleId);
        }

        #endregion

        #region WebSocketAPI 
        /// <summary>
        /// 获取Wss链接
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetWssUrl()
        {
            return (await _httpClient.GetFromJsonAsync<JsonElement>($"{_testUrl}/gateway")).GetProperty("url").GetString();
        }
        /// <summary>
        /// 获取Wss链接
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetWssUrlWithShared()
        {
            var res = (await _httpClient.GetFromJsonAsync<JsonElement>($"{_testUrl}/gateway/bot"));
            _shardCnt = res.GetProperty("shards").GetInt32();
            return res.GetProperty("url").GetString();
        }



        #endregion

        #region WebSocket
        private async Task WebSocketInit()
        {
            var WssOption = GetWssUrlWithShared().Result;
            while (true)
            {
                try
                {
                    _webSocket = new ClientWebSocket();
                    if (Uri.TryCreate(WssOption, UriKind.Absolute, out Uri webSocketUri))
                    {
                        await _webSocket.ConnectAsync(webSocketUri, CancellationToken.None);
                    }
                    else
                    {
                        throw new Exception("连接服务器失败");
                        //return;
                    }

                    while (true)
                    {
                        var rcvBytes = new byte[25000];
                        var rcvBuffer = new ArraySegment<byte>(rcvBytes);
                        WebSocketReceiveResult rcvResult = await _webSocket.ReceiveAsync(rcvBuffer, CancellationToken.None);

                        if (rcvResult?.MessageType != WebSocketMessageType.Text)
                        {
                            Console.WriteLine("未知信息");
                            continue;
                        }
                        byte[] msgBytes = rcvBuffer.Skip(rcvBuffer.Offset).Take(rcvResult.Count).ToArray();
                        //Console.WriteLine("转换成功!");
                        await ExcuteCommand(msgBytes);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                    await Task.Delay(10000);
                }
            }
          
        }
        private async Task SendHeartBeatAsync()
        {
            try
            {
                if (_webSocket.State == WebSocketState.Closed) return;
                Console.WriteLine("发送心跳");
                var data = new
                {
                    op = Opcode.Heartbeat,
                    s = _lastS
                };
                await _webSocket.SendAsync(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
        /// <summary>
        /// 鉴权消息
        /// </summary>
        /// <returns></returns>
        private async Task SendIdentifyAsync(Intent[] intents = null)
        {
            intents ??= new[] { Intent.AT_MESSAGES };
            int intent = 0;
            foreach (var it in _intents)
            {
                intent |= (int)it;
            }
            Console.WriteLine("发送鉴权");
            var data = new
            {
                op = Opcode.Identify,
                d = new
                {
                    token = $"{_appId}.{_token}",
                    //这个要读配置
                    //intents = 1 << 30,
                    intents = intent,
                    shared = _shardId == -1 ? new[] { 0, 1 } : new [] {_shardId % _shardCnt, _shardCnt},
                    properties = new {}
                }
            };
            await _webSocket.SendAsync(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        /// <summary>
        /// 鉴权消息
        /// </summary>
        /// <returns></returns>
        private async Task SendReconnectAsync()
        {
            Console.WriteLine("发送重连");
            var data = new
            {
                op = Opcode.Resume,
                d = new
                {
                    token = $"{_appId}.{_token}",
                    seq = _lastS,
                    session_id = _sessionId,
                }
            };
            await _webSocket.SendAsync(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)), WebSocketMessageType.Text, true, CancellationToken.None);
        }
        private async Task ExcuteCommand(byte[] msgBytes)
        {
            JsonElement data = JsonDocument.Parse(msgBytes).RootElement;
            Console.WriteLine((Opcode)data.GetProperty("op").GetInt32());
            switch ((Opcode)data.GetProperty("op").GetInt32())
            {
                case Opcode.Dispatch:
                    _lastS = data.GetProperty("s").GetInt32();
                     if (data.TryGetProperty("t", out var t))
                    {
                        string type = t.GetString();
                        switch (type)
                        {
                            case "READY":
                                _timer?.Dispose();
                                //_timer
                                _sessionId = data.GetProperty("d").GetProperty("session_id").GetString();
                                _timer = new Timer
                               (new TimerCallback(async _ => await SendHeartBeatAsync()),
                               null, 1000, _heartbeatInterval - 1000);
                                break;
                            case "RESUMED":
                                break;
                            case "GUILD_CREATE":
                            case "GUILD_UPDATE":
                            case "GUILD_DELETE":
                                Guild guild = JsonSerializer.Deserialize<Guild>(data.GetProperty("d").GetRawText());
                                // 好像还得给个参数
                                GuildAction?.Invoke(this, guild, (ActionType)Enum.Parse(typeof(ActionType), type));
                                break;
                            case "CHANNEL_CREATE":
                            case "CHANNEL_UPDATE":
                            case "CHANNEL_DELETE":
                                Channel channel = JsonSerializer.Deserialize<Channel>(data.GetProperty("d").GetRawText());
                                // 好像还得给个参数
                                ChannelAction?.Invoke(this, channel, (ActionType)Enum.Parse(typeof(ActionType), type));
                                break;
                            case "GUILD_MEMBER_ADD":
                            case "GUILD_MEMBER_UPDATE":
                            case "GUILD_MEMBER_REMOVE":
                                MemberWithGuildID memberWithGuildID = JsonSerializer.Deserialize<MemberWithGuildID>(data.GetProperty("d").GetRawText());
                                // 好像还得给个参数
                                GuildMembersAction?.Invoke(this, memberWithGuildID, (ActionType)Enum.Parse(typeof(ActionType), type));
                                break;
                            case "MESSAGE_REACTION_ADD":
                            case "MESSAGE_REACTION_REMOVE":
                                MessageReaction messageReaction = JsonSerializer.Deserialize<MessageReaction>(data.GetProperty("d").GetRawText());
                                GuildMessageReAction?.Invoke(this, messageReaction, (ActionType)Enum.Parse(typeof(ActionType), type));
                                break;
                            case "DIRECT_MESSAGE_CREATE":
                                break;
                            case "AUDIO_START":
                            case "AUDIO_FINISH":
                            case "AUDIO_ON_MIC":
                            case "AUDIO_OFF_MIC":
                                AudioAction audioAction = JsonSerializer.Deserialize<AudioAction>(data.GetProperty("d").GetRawText());
                                AudioAction?.Invoke(this, audioAction, (ActionType)Enum.Parse(typeof(ActionType), type));
                                break;
                            case "AT_MESSAGE_CREATE":
                                Message message = JsonSerializer.Deserialize<Message>(data.GetProperty("d").GetRawText());
                                AtMessageAction?.Invoke(this, message, (ActionType)Enum.Parse(typeof(ActionType), type));
                                break;

                            default:
                                Console.WriteLine(type);
                                break;
                        }
                    }
                    //if (_lastS == 1)
                    //{
                    //    _sessionId = data.GetProperty("d").GetProperty("session_id").GetString();
                    //    _timer = new Timer
                    //   (new TimerCallback(async _ => await SendHeartBeatAsync()),
                    //   null, 1000, _heartbeatInterval - 1000);
                    //}
                    //else
                    //{

                    //    if (data.TryGetProperty("t", out var t) && t.GetString() == "RESUMED")
                    //    {

                    //        return;
                    //    }
                    //    Message message = JsonSerializer.Deserialize<Message>(data.GetProperty("d").GetRawText());
                    //    ListenMessage?.Invoke(this, message);
                    //    //string aa = message.Content;
                    //    ////var aaaa = await GetMeGuildsAsync();
                    //    ////foreach (var item in aaaa)
                    //    ////{
                    //    ////    Console.WriteLine(item.Name);
                    //    ////    var cs = await GetChannelsAsync(item.Id);
                    //    ////    foreach (var item1 in cs)
                    //    ////    {
                    //    ////        Console.WriteLine(item1.Name);
                    //    ////    }
                    //    ////}

                    //    //var aaa = await ReplyMessage(message.ChannelId, "muda", message.Id);
                    //    //await ReplyMessage(message.ChannelId, "muda", message.Id);
                    //    //await ReplyMessage(message.ChannelId, "muda", message.Id);
                    //    //var aaa = await SendMessage(message.ChannelId, "muda");
                    //    //var aaa = await SendMessage("746444190235179419", "muda");
                    //}
                    break;
                case Opcode.Heartbeat:
                    break;
                case Opcode.Identify:
                    break;
                case Opcode.Resume:
                    _lastS = data.GetProperty("s").GetInt32();
                    break;
                case Opcode.Reconnect:
                    await SendReconnectAsync();
                    break;
                case Opcode.InvalidSession:
                    break;
                case Opcode.Hello:
                    _heartbeatInterval = data.GetProperty("d")
                        .GetProperty("heartbeat_interval").GetInt32();
                    await SendIdentifyAsync();
                    break;
                case Opcode.HeartbeatACK:
                    break;
                default:
                    break;
            }

        }
        #endregion
    }
}
