using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace anko2MikuMikuMouth
{
    [DataContract]
    public class RequestDataPackage
    {

        /// <summary>
        /// キャラクタのアニメーション
        /// </summary>
        [DataMember]
        public string emotion;
        /// <summary>
        /// コメントのカラー
        /// </summary>
        [DataMember]
        public string tag;
        /// <summary>
        /// 読み上げるメッセージ
        /// </summary>
        [DataMember]
        public string text;
        /// <summary>
        /// コメント投稿者
        /// </summary>
        [DataMember]
        public string name;
        /// <summary>
        /// 運営コメントかどうか
        /// </summary>
        [DataMember]
        public bool isInterrupted;

        DataContractJsonSerializer jsonSerializer;
        public RequestDataPackage(LibAnko.chat chat)
        {
            jsonSerializer = new DataContractJsonSerializer(typeof(RequestDataPackage));
            this.name = chat.userinfo != null ? chat.userinfo.CharaName : chat.NickName;
            this.isInterrupted = chat.IsCaster;
            this.text = chat.Message;
            this.tag = chat.Mail;
            this.emotion = ""; //アニメーションは指定しない
        }

        /// <summary>
        /// コメント情報をJSON化する
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            string result = "";
            using (var stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, this);

                stream.Position = 0;
                var reader = new StreamReader(stream);
                result = reader.ReadToEnd();
            }
            return result;
        }


        
    }
}
