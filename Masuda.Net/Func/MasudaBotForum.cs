using Masuda.Net.HelpMessage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.Net
{
    public partial class MasudaBot
    {
        #region 帖子API
        /// <summary>
        /// 发表帖子
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public async Task<bool> PostThreadAsync(string channelId, string title, string content, ThreadFormat threadFormat)
        {
            PostThread postThread = new PostThread();
            postThread.Title = title;
            postThread.Content = content;
            postThread.Format = threadFormat;

            var res = await _httpClient.PutAsync($"{_testUrl}/channels/{channelId}/threads", JsonContent.Create(postThread));
            await HttpLogAsync(res);
            return res.IsSuccessStatusCode;
        }

        /// <summary>
        /// 删除帖子
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteThreadAsync(string channelId, string threadId)
        {
            var res = await _httpClient.DeleteAsync($"{_testUrl}/channels/{channelId}/threads/{threadId}");
            await HttpLogAsync(res);
            return res.IsSuccessStatusCode;
        }

        /// <summary>
        /// 获取帖子列表
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public async Task<GetThreadResult?> GetThreadAsync(string channelId)
        {
            var res = await _httpClient.GetAsync($"{_testUrl}/channels/{channelId}/threads");
            if (!await HttpLogAsync(res)) return null;
            return await res.Content.ReadFromJsonAsync<GetThreadResult>();
        }


        /// <summary>
        /// 获取帖子详细
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public async Task<GetThreadInfoResult?> GetThreadInfoAsync(string channelId, string threadId)
        {
            var res = await _httpClient.GetAsync($"{_testUrl}/channels/{channelId}/threads/{threadId}");
            if (!await HttpLogAsync(res)) return null;
            return await res.Content.ReadFromJsonAsync<GetThreadInfoResult>();
        }

        #endregion
    }
}
