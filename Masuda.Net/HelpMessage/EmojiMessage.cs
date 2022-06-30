﻿using Masuda.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.Net.HelpMessage
{
    public class EmojiMessage: MessageBase
    {

        /// <summary>
        /// 表情 id 系统表情使用数字为ID，emoji使用emoji本身为id，参考 EmojiType 列表
        /// </summary>

        public string Id { get; set; }
        /// <summary>
        /// 表情类型
        /// </summary>
        public EmojiType Type { get; set; }
        public override string ToString()
        {
            if (Type == EmojiType.Default)
            {
                return $"<emoji:{Id}>";
            }
            else
            {
                return Id;
            }
        }
        private static Dictionary<string, string> _sDefautEmoji = DefaultEmojiInit();
        private static Dictionary<string, string> _sEmoji = EmojiInit();

        public static Dictionary<string, string> EmojiInit()
        {
            string a = @"👗	连衣裙
😏	哼哼
😄	高兴
😔	失落
😍	花痴
😉	媚眼
☺	可爱
😜	淘气
😁	呲牙
😝	吐舌
😰	紧张
😓	汗
😚	亲亲
😌	羞涩
😊	嘿嘿
❔	问好
❕	叹号
❌	错误
☎	电话
📷	相机
📠	传真
💻	电脑
🎥	摄影机
🎤	话筒
🔫	手枪
💿	光碟
💓	爱心
✨	闪光
♣	扑克
🀄	麻将
〽	股票
🎰	老虎机
🚥	信号灯
🚧	路障
🎸	吉他
💈	理发厅
🛀	浴缸
🚽	马桶
🏠	家
⛪	教堂
⭕	正确
⛄	雪人
🌙	月亮
☔	雨天
☀	晴天
☁	云朵
💄	口红
👟	鞋子
👕	衣服
👙	内衣
👜	包
🌂	雨伞
👢	鞋子
👠	高跟鞋
🏦	银行
👒	帽子
🐭	老鼠
🐳	海豚
🐧	企鹅
👼	天使
🐯	老虎
🐶	狗
🐠	鱼
🐛	虫
👻	幽灵
🐸	青蛙
🐔	公鸡
🐮	牛
🐨	树懒
🐤	小鸡
💀	骷髅
🐷	猪
🐙	章鱼
🐵	猴
👦	男孩
👧	女孩
👨	爸爸
👩	妈妈
⛵	船
🚌	公交
🚀	火箭
🐎	骑马
🚲	自行车
🚤	快艇
🚗	汽车
🚄	列车
✈	飞机
🔒	锁
🔑	钥匙
📫	文件
♨	热
💉	打针
💩	便便
👣	脚印
🏥	医院
⚡	闪电
💤	睡觉
💰	钱
🏆	奖杯
🔥	火
🏨	酒店
🏧	取款机
🏪	超市
🚹	男性
💦	水
🚺	女性
💨	吹气
📱	手机
⭐	星星
🔔	铃铛
👑	皇冠
💣	炸弹
💍	戒指
🐚	海螺
🎈	气球
🎀	蝴蝶结
💝	礼物
🌴	椰子树
🎉	庆祝
🌹	玫瑰
🎄	圣诞树
🚬	吸烟
💊	药丸
🍉	西瓜
🍓	草莓
🍊	橙子
🍎	苹果
☕	咖啡
🍸	高脚杯
🍻	干杯
🍺	啤酒
🍟	薯条
🍳	煎蛋
🙏	合十
🍔	汉堡
🍞	起司
🎂	蛋糕
🍣	寿司
🍧	刨冰
🍙	饭团
🍜	拉面
🍝	意面
🍚	米饭
👂	耳朵
👄	嘴唇
👃	鼻子
👀	眼睛
👇	向下
👆	向上
👉	向右
👈	向左
👌	好的
👎	鄙视
✌	胜利
👏	鼓掌
☝	向上
👍	厉害
👊	拳头
💪	肌肉
😂	激动
😱	害怕
😭	大哭
😘	飞吻
😳	瞪眼
😒	不屑";
            return a.Split('\n').ToDictionary(x => x.Split('\t')[0], x => x.Split('\t')[1]);
        }
        public static Dictionary<string, string> DefaultEmojiInit()
        {
            string a = @"0	惊讶
1	撇嘴
2	色
3	发呆
4	得意
5	流泪
6	害羞
7	闭嘴
8	睡
9	大哭
10	尴尬
11	发怒
12	调皮
13	呲牙
14	微笑
15	难过
16	酷
18	抓狂
19	吐
20	偷笑
21	可爱
22	白眼
23	傲慢
24	饥饿
25	困
26	惊恐
27	流汗
28	憨笑
29	悠闲
30	奋斗
31	咒骂
32	疑问
33	嘘
34	晕
35	折磨
36	衰
37	骷髅
38	敲打
39	再见
41	发抖
42	爱情
43	跳跳
46	猪头
49	拥抱
53	蛋糕
54	闪电
55	炸弹
56	刀
57	足球
59	便便
60	咖啡
61	饭
63	玫瑰
64	凋谢
66	爱心
67	心碎
69	礼物
74	太阳
75	月亮
76	赞
77	踩
78	握手
79	胜利
85	飞吻
86	怄火
89	西瓜
96	冷汗
97	擦汗
98	抠鼻
99	鼓掌
100	糗大了
101	坏笑
102	左哼哼
103	右哼哼
104	哈欠
105	鄙视
106	委屈
107	快哭了
108	阴险
109	亲亲
110	吓
111	可怜
112	菜刀
113	啤酒
114	篮球
115	乒乓
116	示爱
117	瓢虫
118	抱拳
119	勾引
120	拳头
121	差劲
122	爱你
123	NO
124	OK
125	转圈
126	磕头
127	回头
128	跳绳
129	挥手
130	激动
131	街舞
132	献吻
133	左太极
134	右太极
136	双喜
137	鞭炮
138	灯笼
140	K歌
144	喝彩
145	祈祷
146	爆筋
147	棒棒糖
148	喝奶
151	飞机
158	钞票
168	药
169	手枪
171	茶
172	眨眼睛
173	泪奔
174	无奈
175	卖萌
176	小纠结
177	喷血
178	斜眼笑
179	doge
180	惊喜
181	骚扰
182	笑哭
183	我最美
184	河蟹
185	羊驼
187	幽灵
188	蛋
190	菊花
192	红包
193	大笑
194	不开心
197	冷漠
198	呃
199	好棒
200	拜托
201	点赞
202	无聊
203	托脸
204	吃
205	送花
206	害怕
207	花痴
208	小样儿
210	飙泪
211	我不看
212	托腮
214	啵啵
215	糊脸
216	拍头
217	扯一扯
218	舔一舔
219	蹭一蹭
220	拽炸天
221	顶呱呱
222	抱抱
223	暴击
224	开枪
225	撩一撩
226	拍桌
227	拍手
228	恭喜
229	干杯
230	嘲讽
231	哼
232	佛系
233	掐一掐
234	惊呆
235	颤抖
236	啃头
237	偷看
238	扇脸
239	原谅
240	喷脸
241	生日快乐
242	头撞击
243	甩头
244	扔狗
245	加油必胜
246	加油抱抱
247	口罩护体
260	办公
261	忙碌
262	心累
263	沧桑
264	捂脸
265	刷手机
266	嫌弃
267	头秃
268	问号
269	暗中观察
270	尴尬
271	吃瓜
272	呵呵
273	柠檬
274	南";
            return a.Split('\n').ToDictionary(x => x.Split('\t')[0], x => x.Split('\t')[1]);
        }

        public static EmojiMessage CreateEmojiMessage(string id)
        {
            return new EmojiMessage
            {
                Type = EmojiType.Emoji, Id = id
            };
        }

        public static EmojiMessage CreatDefaultEmojiMessage(string id)
        {
            return new EmojiMessage
            {
                Type = EmojiType.Default, Id = id
            };
        }
    }
}
