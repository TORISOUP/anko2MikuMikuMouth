using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace anko2SpeachMiku
{
    //コメント情報
    [DataContract]
    class CommentInfo
    {
        DataContractJsonSerializer jsonSerializer;
        public CommentInfo(LibAnko.chat chat)
        {
            jsonSerializer = new DataContractJsonSerializer(typeof(CommentInfo));
            this.Name = chat.Name;
            this.NickName = chat.NickName;
            this.Anonymity = chat.Anonymity;
            this.IsCaster = chat.IsCaster;
            this.Message = chat.Message;
            this.No = chat.No;
            this.Premium = chat.Premium;
            this.ProfName = chat.ProfName;
            this.UserId = chat.UserId;
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

        [DataMember]
        public string Name;
        [DataMember]
        public string NickName;
        [DataMember]
        public bool Anonymity;
        [DataMember]
        public bool IsCaster;
        [DataMember]
        public string Message;
        [DataMember]
        public int No;
        [DataMember]
        public int Premium;
        [DataMember]
        public string ProfName;
        [DataMember]
        public string UserId;
    }
}
