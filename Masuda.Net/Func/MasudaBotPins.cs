using Masuda.Net.HelpMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.Net
{
    public partial class MasudaBot
    {


        /// <summary>
        /// 添加精华消息
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public async Task<bool> AddPinsMessageAsync(string channelId, string msgId)
        {
            var res = await _httpClient.PutAsync($"{_testUrl}/channels/{channelId}/pins/{msgId}", null);
            await HttpLogAsync(res);
            return res.IsSuccessStatusCode;
        }

        /// <summary>
        /// 删除精华消息
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public async Task<bool> DeletePinsMessageAsync(string channelId, string msgId)
        {
            var res = await _httpClient.DeleteAsync($"{_testUrl}/channels/{channelId}/pins/{msgId}");
            await HttpLogAsync(res);
            return res.IsSuccessStatusCode;
        }

        /// <summary>
        /// 获取精华消息
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public async Task<PinsMessageResult?> GetPinsMessageAsync(string channelId, string msgId)
        {
            var res = await _httpClient.GetAsync($"{_testUrl}/channels/{channelId}/pins");
            if (!await HttpLogAsync(res)) return null;
            return await res.Content.ReadFromJsonAsync<PinsMessageResult>();
        }

    }
}
